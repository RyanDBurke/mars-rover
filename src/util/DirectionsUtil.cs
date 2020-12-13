/***************************************************************************
    DirectionUtil
        * just holds a method for handling turns
        * honestly, could've kept this in CardinalDirection.cs, but its ok
***************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;

namespace Lib {

    class DirectionsUtil {

        // handles turning rover left/right, returns new facing direction
        public static Directions turn(Directions d, char turnDirection) {
            Directions res = d;
            switch (turnDirection) {

                /// handle LEFT
                case 'L':
                    switch (d) {
                        case Directions.NORTH:
                            res = Directions.WEST;
                            break;
                        case Directions.SOUTH:
                            res = Directions.EAST;
                            break;
                        case Directions.EAST:
                            res = Directions.NORTH;
                            break;
                        case Directions.WEST:
                            res = Directions.SOUTH;
                            break;
                        default:
                            MainUtil.argError(String.Format("\nInvalid Direction provided: {0}.", d));
                            break;
                    }

                    break;
                
                /// handle RIGHT
                case 'R':
                    switch (d) {
                        case Directions.NORTH:
                            res = Directions.EAST;
                            break;
                        case Directions.SOUTH:
                            res = Directions.WEST;
                            break;
                        case Directions.EAST:
                            res = Directions.SOUTH;
                            break;
                        case Directions.WEST:
                            res = Directions.NORTH;
                            break;
                        default:
                            MainUtil.argError(String.Format("\nInvalid Direction provided: {0}.", d));
                            break;
                    }

                    break;
                default:
                    MainUtil.argError(String.Format("\nInvalid turn direction: {0}.", turnDirection));
                    break;
            }

            return res;
        }
    }
}