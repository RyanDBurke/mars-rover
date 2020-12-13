
/* 
    A Rover holds:
        * its current (xPos, yPos) position on the grid
        * its current direction (N, S, E, W)
        * char-array of instructions left to execute
*/

using System;
using System.Collections.Generic;

namespace Ryan.Burke {
    class Rover {

        public int id {get; set;}
        public int xPos {get; set;}
        public int yPos {get; set;}
        public Directions direction {get; set;}
        public List<char> instructions;

        public Rover(int id, int xPos, int yPos, Directions direction, List<char> instructions) {
            this.id = id;
            this.xPos = xPos;
            this.yPos = yPos;
            this.direction = direction;
            this.instructions = instructions;
        }

        public bool completed() {
            return (instructions.Count == 0);
        }

        public void move() {
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
        }
    }
}