using Single_Responsibility;
using Open_Closed;
using Liskov_Substitution;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Dependency_Inversion;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        //Single_Responsibility_Demo();
        //Open_Closed_Demo();
        //Liskov_Substitution_Demo();
        Dependency_Inversion_Demo();
    }

    private static void Dependency_Inversion_Demo()
    {
        Person parent = new Person { Name = "John" };
        Person child1 = new Person { Name = "Mike" };
        Person child2 = new Person { Name = "Mary" };

        BadRelationships badRelationship = new BadRelationships();
        badRelationship.AddParentAndChild(parent, child1);
        badRelationship.AddParentAndChild(parent, child2);
        //依賴原始資料格式，不易改動
        foreach (var p in badRelationship.Relations.Where(x => x.Item1.Name == "John" && x.Item2 == RelationType.Parent))
        {
            Console.WriteLine($"John has a child called {p.Item3.Name}.");
        }

        GoodRelationships goodRelationship = new GoodRelationships();
        goodRelationship.AddParentAndChild(parent, child1);
        goodRelationship.AddParentAndChild(parent, child2);
        //呼叫方法，以降低依賴性
        foreach (var p in goodRelationship.FindAllChildrenOf("John"))
        {
            Console.WriteLine($"John has a child called {p.Name}.");
        };
        Console.ReadLine();
    }

    private static void Liskov_Substitution_Demo()
    {
        Rectangle rectangle = new Rectangle(10, 5);
        Console.WriteLine($"{rectangle}, Area: {rectangle.CalculateArea()}");
        Rectangle square = new Square();
        square.Width = 4;
        Console.WriteLine($"{square}, Area: {square.CalculateArea()}");
        Rectangle betterSquare = new BetterSquare();
        betterSquare.Width = 4;
        Console.WriteLine($"{betterSquare}, Area: {betterSquare.CalculateArea()}");
        Console.ReadLine();
    }

    private static void Single_Responsibility_Demo()
    {
        string fileName = @"D:\Udemy\Design Patterns in C# and .NET\SOLID\Journal.txt";
        Journal journal = new Journal();
        journal.AddEntry("This is first entry.");
        journal.AddEntry("This is second entry.");
        Presistence.SaveToFile(journal, fileName, overwrite: true);
        Process.Start(fileName);
        Console.WriteLine(journal);
        Console.ReadLine();
    }
    private static void Open_Closed_Demo()
    {
        Product car = new Product("Car", Color.Green, Size.Large);
        Product book = new Product("Book", Color.Green, Size.Medium);
        Product clock = new Product("Clock", Color.Blue, Size.Small);
        Product pencil = new Product("Pencil", Color.Green, Size.Small);
        Product[] products = new Product[] { car, book, clock, pencil };

        Console.WriteLine("Product Filter (old):");
        ProductFilter ProdFilter = new ProductFilter();
        foreach (Product p in ProdFilter.FilterBySize(products, Size.Small))
        {
            Console.WriteLine($" - {p.Name} is small.");
        }

        Console.WriteLine("Open_Closed Filter (new):");
        Open_Closed_Filter OCFilter = new Open_Closed_Filter();
        foreach (Product product in OCFilter.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($" - {product.Name} is Green.");
        };
        foreach (Product product in OCFilter.Filter(products,
            new AndSpecification<Product>(new SizeSpecification(Size.Small), new ColorSpecification(Color.Green))))
        {
            Console.WriteLine($" - {product.Name} is Green and small.");
        };
        Console.ReadLine();
    }


}
