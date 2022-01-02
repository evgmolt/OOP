using Houses;

EntityCreator creator = EntityCreatorExtensions.CreateCreator();
House house1 = creator.Build(50, 4, 5, 100);
House house2 = creator.Build(80, 6, 5, 100);
House house3 = creator.Build(50, 2, 5, 100);

var list = creator.GetList();
foreach (var house in list)
{
    Console.WriteLine(house.ToString());
}
Console.WriteLine();
creator.RemoveByNumber(2);

list = creator.GetList();
foreach (var house in list)
{
    Console.WriteLine(house.ToString());
}
