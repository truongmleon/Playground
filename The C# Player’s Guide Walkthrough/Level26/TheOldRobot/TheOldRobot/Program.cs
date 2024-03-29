﻿Robot r1 = new Robot();

for (int i = 0; i < 3; i++) {
    Console.Write("Enter a command: ");
    string command = Console.ReadLine();

    RobotCommand c1 = command switch {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    };

    r1.Commands[i] = c1;
}

Console.WriteLine();
r1.Run();

public abstract class RobotCommand {
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand {
    public override void Run(Robot robot) {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand {
    public override void Run(Robot robot) {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered) {
            robot.Y += 1;
        }
    }
}

public class SouthCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered) {
            robot.Y -= 1;
        }
    }
}

public class WestCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered) {
            robot.X -= 1;
        }
    }
}

public class EastCommand : RobotCommand {
    public override void Run(Robot robot) {
        if (robot.IsPowered) {
            robot.X += 1;
        }
    }
}

public class Robot {
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run() {
        foreach (RobotCommand? command in Commands) {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}