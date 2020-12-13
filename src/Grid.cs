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

            //if (inGrid(rover.xPos, rover.yPos)) {
           //     grid[rover.xPos, rover.yPos] += 1;  // update rover's position on grid
           // }
            
        }

        // get x and y
        public Tuple<int, int> getDimensions() {
            return new Tuple<int, int>(this.grid.GetLength(0), this.grid.GetLength(1));
        }

        public void move(int xPrev, int yPrev, int xCurr, int yCurr) {

            // only update prev position if its within our grid-bounds
            if (inGrid(xPrev, yPrev)) {
                grid[xPrev, yPrev] -= 1;
            }

            // only update curr position if its within our grid-bounds
            if (inGrid(xCurr, yCurr)) {
                grid[xCurr, yCurr] += 1;
            }        
        }

        public bool inGrid(int xCurr, int yCurr) {

            // get (x, y) bounds of grid
            int x = this.grid.GetLength(0);
            int y = this.grid.GetLength(1);

            return (xCurr < x && xCurr >= 0 && yCurr < y && yCurr >= 0);
        }

        // serialization of grid with correct cardinal orientation
        public void printGrid() {

            // limit size of grid display
            int sizeLimit = 12;

            // get (x, y) bounds of grid
            int x = this.grid.GetLength(0);
            int y = this.grid.GetLength(1);

            if (x > sizeLimit || y > sizeLimit) {
                Console.WriteLine("Grid is a little too big to display.. (SIZE LIMIT: {0})", sizeLimit);
                return;
            }

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

            // print with correct orientation (i.e SW corner in the bottom-left)
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