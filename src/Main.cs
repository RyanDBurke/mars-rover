// make
// ./main.exe

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ryan.Burke {
    class main {
       static void Main(string[] args) {

            // holds all updated positions of each rover after all are completed
            string positionResults = "";

            // establish results-output filepath and clear it
            string resultsPath = "results.txt";
            File.WriteAllText(resultsPath, String.Empty);
            
            // holds input file as array of text-lines
            string[] input = new string[1];

            // if true, stdout is more detailed during program execution
            bool verbose = false;

            // checking for invalid args/file-input and setting verbose
            if (args.Length == 0) {
                Console.WriteLine("Please include input in command-args.");
                Console.WriteLine("EX: ./Main.exe input.txt");
                Console.WriteLine("EX: ./Main.exe input.txt --verbose");
                System.Environment.Exit(1);
            } else if (args.Length >= 1 || args.Length == 2) {
                if (!File.Exists(args[0])) {
                    Console.WriteLine("File: {0} does NOT exist.", args[0]);
                    System.Environment.Exit(1);
                } else {
                    input = System.IO.File.ReadAllLines(args[0]);
                }

                // set verbose given command-line arg
                if (args.Length >= 2) {
                    verbose = (args[1] == "--verbose");
                }
            } 

            // parsing input file for relevant data
            if (verbose) {
                Console.WriteLine("Parsing Input from {0}\n", args[0]);
            }

            // initialize our grid
            string[] gridSize = input[0].Split(' ');
            Grid plateau = new Grid(Int32.Parse(gridSize[0]), Int32.Parse(gridSize[1]));

            // initalizing all rovers, adding them to grid
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

                // execute each of the current rover's instructions
                while (!rover.completed()) {

                    // get next instruction, and remove from queue
                    char instruction = (rover.instructions)[0];
                    rover.instructions.RemoveAt(0);

                    // rover's current direction
                    Directions currDirection = rover.direction;

                    // execute move/turn on our grid and rover
                    switch (instruction) {
                        case 'L':
                            rover.direction = DirectionsUtil.turn(currDirection, 'L');
                            break;
                        case 'R':
                            rover.direction = DirectionsUtil.turn(currDirection, 'R');
                            break;
                        case 'M':
                            int xPrev = rover.xPos;
                            int yPrev = rover.yPos;

                            rover.move();

                            int xCurr = rover.xPos;
                            int yCurr = rover.yPos;

                            // plateau.move(xPrev, yPrev, xCurr, yCurr);
                            break;
                        default:
                            Console.WriteLine("Invalid instruction provided: {0}", instruction);
                            break;

                    }
                }

                // write results to output
                using (StreamWriter sw = File.AppendText(resultsPath)) {
                    sw.WriteLine(String.Format("{0} {1} {2}",
                    rover.xPos, 
                    rover.yPos, 
                    (char) rover.direction));
                }

                // add result string for stdout later
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