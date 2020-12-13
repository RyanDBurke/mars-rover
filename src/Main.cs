// make
// ./main.exe

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lib;

namespace Ryan.Burke {
    class main {
       static void Main(string[] args) {

            // holds all updated positions of each rover after all are completed
            string positionResults = "";

            // establish results-output filepath and clear it
            string resultsPath = "results.txt";
            File.WriteAllText(resultsPath, String.Empty);
            
            // holds input file as array of text-lines (handleInput handles invalid args)
            string[] input = (MainUtil.handleInput(args)) ? System.IO.File.ReadAllLines(args[0]) : new string[1];

            // if true, stdout is more detailed during program execution
            bool verbose = MainUtil.handleVerbose(args);

            // parsing input file for relevant data
            if (verbose) {
                Console.WriteLine("Parsing Input from {0}\n", args[0]);
            }

            // initialize our grid
            string[] gridSize = input[0].Split(' ');
            Grid plateau = new Grid(Int32.Parse(gridSize[0]), Int32.Parse(gridSize[1]));

            // initalizing all rovers, adding them to grid, and executing their instructions
            for (int line = 1; line < input.Length - 1; line += 2) {

                // rover ID
                int roverID = plateau.rovers.Count + 1;

                // deploying rover
                if (verbose) {
                    Console.WriteLine("Deploying Rover [{0}]", roverID);
                }

                // parse lines
                string[] roverPosition = input[line].Split(' ');
                List<char> roverInstructions = new List<Char>();
                roverInstructions.AddRange(input[line + 1]);
                roverInstructions.Remove(' ');

                // extract rover constructor params
                int xPos = Int32.Parse(roverPosition[0]);
                int yPos = Int32.Parse(roverPosition[1]);
                
                // get current facing direction
                Directions direction = Directions.NORTH;
                switch (roverPosition[2]) {
                    case "N":
                        direction = Directions.NORTH;
                        break;
                    case "S":
                        direction = Directions.SOUTH;
                        break;
                    case "E":
                        direction = Directions.EAST;
                        break;
                    case "W":
                        direction = Directions.WEST;
                        break;
                    default:
                        Console.WriteLine("Invalid Direction provided: {0}.", Int32.Parse(roverPosition[2]));
                        System.Environment.Exit(1);
                        break;
                }

                // init rover
                Rover rover = new Rover(roverID, xPos, yPos, direction, roverInstructions);

                // add rover to grid
                plateau.addRover(rover);

                // execute each of the rover's instructions and move accordingly
                rover.move();

                // write results to output
                using (StreamWriter sw = File.AppendText(resultsPath)) {
                    sw.WriteLine(String.Format("{0} {1} {2}",
                    rover.xPos, 
                    rover.yPos, 
                    (char) rover.direction));
                }

                // add result string for stdout later (if verbose flag is true)
                positionResults += String.Format("Rover [{0}]'s Completed Position: {1} {2} {3}\n",
                    rover.id,
                    rover.xPos, 
                    rover.yPos, 
                    (char) rover.direction);
            }

            // print some cool info about each rover and their position
            if (verbose) {
                Console.WriteLine("\n" + positionResults);
                plateau.printGrid();
            }            

            // where you can find results
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can find the results in: " + resultsPath);
        }
    }
}