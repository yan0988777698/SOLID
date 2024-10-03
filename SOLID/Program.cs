using Single_Responsibility;
using Open_Closed;
using System;
using System.Diagnostics;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        //Single_Responsibility_Demo();
        Open_Closed_Demo();
    }

    private static void Open_Closed_Demo()
    {
        Product car = new Product("Car", Color.Red, Size.Large);
        Product book = new Product("Book", Color.Green, Size.Medium);
        Product clock = new Product("Clock", Color.Blue, Size.Small);
        Product pencil = new Product("Pencil", Color.Black, Size.Small);
        Product[] products = new Product[] { car, book, clock, pencil };
        foreach (Product p in ProductFilter.FilterBySize(products, Size.Small))
        {
            Console.WriteLine($"{p.Name} is medium.");
        }
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
}
