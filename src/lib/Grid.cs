/*******************************************************************
    A Grid holds:
        * a X-by-Y matrix-representation of grid
            * 0 denotes rover does NOT exist at position
            * 1+ denotes how many rover exists at position
        * list of all rovers that did or will traverse the grid
*******************************************************************/

using System;
using System.Collections.Generic;

namespace Lib {
    class Grid {

        public int[,] grid;             // matrix-representation of grid
        public List<Rover> rovers;      // list of rovers currently on grid

        public Grid(int x, int y) {
            this.grid = new int[x, y];
            this.rovers = new List<Rover>();
        }

        //// add rover to grid
        public void addRover(Rover rover) {
            this.rovers.Add(rover);             // add rover to list            
        }

        //// returns true if (x, y) given are within grid bounds
        public bool inGrid(int xCurr, int yCurr) {

            // get (x, y) bounds of grid
            int x = this.grid.GetLength(0);
            int y = this.grid.GetLength(1);

            return (xCurr < x && xCurr >= 0 && yCurr < y && yCurr >= 0);
        }

        //// serialization of grid with correct cardinal orientation (i.e SW on bottom-left)
        public void printGrid() {

            // limit size of grid display
            int sizeLimit = 12;

            // get (x, y) bounds of grid
            int x = this.grid.GetLength(0);
            int y = this.grid.GetLength(1);

            // if over size limit, don't display (its gonna look weird lol)
            if (x > sizeLimit || y > sizeLimit) {
                Console.WriteLine("Grid is a little too big to display.. (SIZE LIMIT: {0})", sizeLimit);
                return;
            }

            // filling in 0 or 1+ within grid given rover positions
            // also building a string to print to stdout
            string roverPositions = "";
            roverPositions += "All Rover Coordinates:\n";
            foreach (Rover rover in this.rovers) {
                if (!inGrid(rover.xPos, rover.yPos)) {
                    roverPositions += String.Format("Rover [{0}]: ({1}, {2}) OFF GRID\n", rover.id, rover.xPos, rover.yPos);
                } else {
                    this.grid[rover.xPos, rover.yPos] += 1;
                    roverPositions += String.Format("Rover [{0}]: ({1}, {2})\n", rover.id, rover.xPos, rover.yPos);
                }
            }

            Console.WriteLine("   Final Rover Positions:");

            // print grid with correct cardinal orientation (i.e SW on bottom-left)
            for (int j = y- 1; j >= 0; j--) {
                if (j == 0) {
                    Console.Write("North ^ ");
                } else {
                    Console.Write("        ");
                }
                for (int i = 0; i < x; i++) {
                    int entry = grid[i, j];
                    Console.Write("{0} ", entry);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("         East >\n");
            Console.WriteLine(roverPositions);
        }
    }
}