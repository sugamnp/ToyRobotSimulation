using System;

namespace ToyRobotSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToyRobot robot = new ToyRobot();

            Console.WriteLine("---Toy Simulation---");

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                if (command.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                ExecuteCommand(command, robot);
            }
            Console.WriteLine("Exiting the Toy Robot Simulation.");
        }

        static void ExecuteCommand(string command, ToyRobot robot)
        {
            string[] parts = command.Trim().Split(' '); // seperating action and arguments 
            string action = parts[0];
            string[] args = parts.Length > 1 ? parts[1].Split(',') : null; //set arguments to null if there arent any 

            switch (action.ToUpper())
            {
                case "PLACE":
                    if (args != null && args.Length == 3 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
                    {
                        robot.Place(x, y, args[2].ToUpper());
                    }
                    else
                    {
                        Console.WriteLine("Invalid PLACE command.");
                    }
                    break;
                case "MOVE":
                    robot.Move();
                    break;
                case "LEFT":
                    robot.Left();
                    break;
                case "RIGHT":
                    robot.Right();
                    break;
                case "REPORT":
                    robot.Report();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
