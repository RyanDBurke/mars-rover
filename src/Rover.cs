
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

        public int xPos, yPos;
        public Directions direction;
        public List<char> instructions;


        public Rover(int xPos, int yPos, Directions direction, List<char> instructions) {
            this.xPos = xPos;
            this.yPos = yPos;
            this.direction = direction;
            this.instructions = instructions;
        }

        public bool completed() {
            return (instructions.Count == 0);
        }
    }
}