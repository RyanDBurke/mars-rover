

namespace Ryan.Burke
{
    public enum Directions
    {
        NORTH,
        WEST,
        SOUTH,
        EAST
    }

    // handling turning left and right
    public Directions left(Directions d)
    {
        Directions res = d;
        switch (d)
        {
            case "N":
                res = Directions.WEST;
                break;
            case "S":
                res = Directions.EAST;
                break;
            case "E":
                res = Directions.NORTH;
                break;
            case "W":
                res = Directions.SOUTH;
                break;
            default:
                Console.WriteLine("Invalid Direction provided: {0}.", Int32.Parse(roverPosition[2]));
                System.Environment.Exit(1);
                break;
        }

        return res;
    }

    public Directions right(Directions d)
    {
        Directions res = d;
        switch (d)
        {
            case "N":
                res = Directions.EAST;
                break;
            case "S":
                res = Directions.WEST;
                break;
            case "E":
                res = Directions.SOUTH;
                break;
            case "W":
                res = Directions.NORTH;
                break;
            default:
                Console.WriteLine("Invalid Direction provided: {0}.", Int32.Parse(roverPosition[2]));
                System.Environment.Exit(1);
                break;
        }

        return res;
    }
}