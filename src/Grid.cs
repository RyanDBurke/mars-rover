

using System;
using System.Collections.Generic;

namespace Ryan.Burke {
    class Grid {

        public int[][] grid;    // matrix-representation of grid
        List<Rover> rovers;     // list of rovers currently on grid

        public Grid(int xBounds, int yBounds, List<Rover> rovers) {
            this.grid = new Int[xBounds][yBounds];
            this.rovers = rovers;
        }

        // add rover to grid
        public void addRover(Rover rover) {
            this.rovers.add(rover);
        }
    }
}