/* 
    A Grid holds:
        * a X-by-Y matrix-representation of grid
            * 0 denotes rover does NOT exist at position
            * 1 denotes rover exists at position
        * list of all rovers that are (or will) traverse the grid
*/

using System;
using System.Collections.Generic;

namespace Ryan.Burke {
    class Grid {

        public int[,] grid;             // matrix-representation of grid
        public List<Rover> rovers;      // list of rovers currently on grid

        public Grid(int x, int y) {
            this.grid = new int[x, y];
            this.rovers = new List<Rover>();
        }

        // add rover to grid
        public void addRover(Rover rover) {
            this.rovers.Add(rover);             // add rover to list
            grid[rover.xPos, rover.yPos] = 1;   // update rover's position on grid
        }

        // get x and y
        public Tuple<int, int> getDimensions() {
            return new Tuple<int, int>(this.grid.GetLength(0), this.grid.GetLength(1));
        }

        // serialization of grid with correct cardinal orientation
        public void printGrid() {

            // get (x, y) bounds of grid
            int x = this.grid.GetLength(0);
            int y = this.grid.GetLength(0);

            // print with correct orientation (i.e SW corner in the bottom-left)
            for (int i = x - 1; i >= 0; i--) {
                for (int j = 0; j < y; j++) {
                    int entry = grid[i, j];
                    Console.Write("{0} ", entry);
                }
                Console.WriteLine("");
            }
        }
    }
}