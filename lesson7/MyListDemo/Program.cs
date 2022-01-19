
using MyListDemo;

void ShowList(MyList<int> list)
{
    foreach (int item in list) //Проверка GetEnumerator 
    {
        Console.Write(item.ToString() + " ");
    }
    Console.WriteLine();
    for (int i = 0; i < list.Count; i++)//Проверка индексатора
    {
        Console.Write(list[i].ToString() + " ");
    }
    Console.WriteLine();
}

MyList<int> list = new();
for (int i = 0; i < 15; i++)
{
    list.Add(i);
}

ShowList(list);
list.Remove(5);
ShowList(list);
list.RemoveAt(1);
ShowList(list);
list.Insert(1, 111);
ShowList(list);
Console.WriteLine("Hello, MyList!");
