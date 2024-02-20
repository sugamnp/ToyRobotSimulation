using System;

namespace ToyRobotSimulation
{
    public class ToyRobot
    {
        private int x;
        private int y;
        private string direction;
        private bool placed;

        public ToyRobot()
        {
            x = -1;
            y = -1;
            direction = "";
            placed = false;
        }
        public void Place(int x, int y, string direction)
        {
            if (IsValidPosition(x, y) && IsValidDirection(direction))
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
                placed = true;
                Console.WriteLine($"Placed toy robot at {this.x},{this.y},{this.direction}");
            }
            else
            {
                Console.WriteLine("Invalid PLACE command.");
            }
        }

        public void Move()
        {
            if (!placed)
            {
                Console.WriteLine("Toy robot has not been placed yet.");
                return;
            }

            int newX = x;
            int newY = y;

            switch (direction)
            {
                case "NORTH":
                    newY++;
                    break;
                case "EAST":
                    newX++;
                    break;
                case "SOUTH":
                    newY--;
                    break;
                case "WEST":
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                x = newX;
                y = newY;
                Console.WriteLine($"Moved toy robot to {x},{y},{direction}");
            }
            else
            {
                Console.WriteLine("Cannot move. Toy robot will fall off the table.");
            }
        }

        public void Left()
        {
            if (!placed)
            {
                Console.WriteLine("Toy robot has not been placed yet.");
                return;
            }

            switch (direction)
            {
                case "NORTH":
                    direction = "WEST";
                    break;
                case "EAST":
                    direction = "NORTH";
                    break;
                case "SOUTH":
                    direction = "EAST";
                    break;
                case "WEST":
                    direction = "SOUTH";
                    break;
            }
            Console.WriteLine($"Rotated toy robot to {direction}");
        }

        public void Right()
        {
            if (!placed)
            {
                Console.WriteLine("Toy robot has not been placed yet.");
                return;
            }

            switch (direction)
            {
                case "NORTH":
                    direction = "EAST";
                    break;
                case "EAST":
                    direction = "SOUTH";
                    break;
                case "SOUTH":
                    direction = "WEST";
                    break;
                case "WEST":
                    direction = "NORTH";
                    break;
            }
            Console.WriteLine($"Rotated toy robot to {direction}");
        }

        public void Report()
        {
            if (!placed)
            {
                Console.WriteLine("Toy robot has not been placed yet.");
                return;
            }
            Console.WriteLine($"Toy robot is at {x},{y},{direction}");
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= 4 && y >= 0 && y <= 4;
        }

        private bool IsValidDirection(string direction)
        {
            return direction == "NORTH" || direction == "EAST" || direction == "SOUTH" || direction == "WEST";
        }
    }
}
