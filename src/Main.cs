// make
// ./main.exe

using System;
using System.IO;
using System.Collections.Generic;

namespace Ryan.Burke {
    class main {
       static void Main(string[] args) {

            // holds input file as array of text-lines
            string[] input = new string[1];

            // checking for invalid args/file-input
            if (args.Length != 1) {
                Console.WriteLine("Please include input in command-args.");
                Console.WriteLine("EX: ./Main.exe input.txt");
                System.Environment.Exit(1);
            } else if (!File.Exists(args[0])) {
                Console.WriteLine("File: {0} does NOT exist.", args[0]);
                System.Environment.Exit(1);
            } else {
                input = System.IO.File.ReadAllLines(args[0]);
            }

            // parsing input file for relevant data
            Console.WriteLine("Parsing Input from {0}\n", args[0]);

            // initialize our grid
            string[] gridSize = input[0].Split(' ');
            Grid plateau = new Grid(Int32.Parse(gridSize[0]), Int32.Parse(gridSize[1]));

            // initalizing all rovers, adding them to grid
            for (int line = 1; line < input.Length - 1; line += 2) {

                // deploying rover
                Console.WriteLine("Deploying Rover #{0}", plateau.rovers.Count + 1);

                // parse lines
                string[] roverPosition = input[line].Split(' ');
                List<char> roverInstructions = new List<Char>();
                roverInstructions.AddRange(input[line + 1]);

                // extarct rover constructor params
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
                Rover rover = new Rover(xPos, yPos, direction, roverInstructions);

                // add rover to grid
                plateau.addRover(rover);

                // execute each of the current rover's instructions
                while (!rover.completed()) {
                    char instruction = rover.instructions[0];
                    rover.instructions.RemoveAt(0);

                    // execute move on grid and rover
                    switch (instruction) {
                        case 'L':
                            break;
                        case 'R':
                            break;
                        case 'M':
                            break;
                        default:
                            Console.WriteLine("Invalid instruction provided: {0}.", instruction);
                            break;

                    }
                }
            }

            // print grid
            plateau.printGrid();
        }
    }
}