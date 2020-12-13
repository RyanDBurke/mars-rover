
using System;
using System.IO;
using System.Collections.Generic;

namespace Ryan.Burke
{
    public enum Directions
    {
        NORTH = 'N',
        WEST = 'W',
        SOUTH = 'S',
        EAST = 'E'
    }

    class DirectionsUtil {

        /*
        public static string toString(Directions d) {
            switch (d) {
                case Directions.NORTH:
                    return "N";
                case Directions.SOUTH:
                    return "S";
                case Directions.EAST:
                    return "E";
                case Directions.WEST:
                    return "W";
                default:
                    Console.WriteLine("Invalid Direction provided: {0}.", d);
                    System.Environment.Exit(1);
                    break;
            }
        }
        */

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
                            Console.WriteLine("Invalid Direction provided: {0}.", d);
                            System.Environment.Exit(1);
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
                            Console.WriteLine("Invalid Direction provided: {0}.", d);
                            System.Environment.Exit(1);
                            break;
                    }

                    break;
                default:
                    Console.WriteLine("Invalid turn direction: {0}.", turnDirection);
                    System.Environment.Exit(1);
                    break;
            }

            return res;
        }
    }
}