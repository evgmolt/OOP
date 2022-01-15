using Geometric;

Point p = new();
p.Color = ConsoleColor.Green;
p.Draw();
p.Move(10, -55);
p.Draw();

Circle c = new(10);
c.Color = ConsoleColor.Red;
c.Draw();
Console.WriteLine(c.Square());

Rectangle r = new Rectangle(5, 9);
r.Move(100, 200);
r.Color = ConsoleColor.Yellow;
r.Draw();
Console.WriteLine(r.GetSides());