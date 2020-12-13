
/**********************************************************
    A Rover holds:
        * it's ID #
        * its current (xPos, yPos) position on the grid
        * its current direction (N, S, E, W)
        * char-array of instructions left to execute
**********************************************************/

using System;
using System.Collections.Generic;
using static Lib.DirectionsUtil;

namespace Lib {
    class Rover {

        public int id {get; set;}                   // Rover's ID #
        public int xPos {get; set;}                 // Rover's x-position on grid
        public int yPos {get; set;}                 // Rover's y-position
        public Directions direction {get; set;}     // Rover's current facing direction
        public List<char> instructions;             // list of instruction(s) YET to be executed

        public Rover(int id, int xPos, int yPos, Directions direction, List<char> instructions) {
            this.id = id;
            this.xPos = xPos;
            this.yPos = yPos;
            this.direction = direction;
            this.instructions = instructions;
        }

        //// return true if rover's instructions are complete
        public bool completed() {
            return (instructions.Count == 0);
        }

        //// execute each of the rover's instructions and move accordingly
        public void move() {
            while (!completed()) {

                // get next instruction, and remove from queue
                char instruction = instructions[0];
                instructions.RemoveAt(0);

                // rover's current direction
                Directions currDirection = direction;

                // execute move/turn on our grid and rover
                switch (instruction) {
                    case 'L':
                        direction = turn(currDirection, 'L');
                        break;
                    case 'R':
                        direction = turn(currDirection, 'R');
                        break;
                    case 'M':
                        switch (this.direction) {
                            case Directions.NORTH:
                                this.yPos += 1;
                                break;
                            case Directions.SOUTH:
                                this.yPos -= 1;
                                break;
                            case Directions.EAST:
                                this.xPos += 1;
                                break;
                            case Directions.WEST:
                                this.xPos -= 1;
                                break;
                            default:
                                Console.WriteLine("error in Rover.move()");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid instruction provided: {0}", instruction);
                        break;

                }
            }
        }
    }
}