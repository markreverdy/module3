using System;
using System.Collections.Generic;
using System.Linq;

public delegate int CalculateDelegate(int a, int b);

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class MathOperation
{
    public event CalculateDelegate CalculateEvent;

    public int Calculate(int a, int b)
    {
        return CalculateEvent?.Invoke(a, b) ?? 0;
    }

    public void SumLogicWrapper(int a, int b)
    {
        int result = SafeExecute(() => Calculate(a, b));
        Console.WriteLine($"The result is: {result}");
    }

    public T SafeExecute<T>(Func<T> action)
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default;
        }
    }
}

public class Mod3_Ex4
{
    public static void Main()
    {
        var mathOp = new MathOperation();

        mathOp.CalculateEvent += (a, b) => a + b;  // Subscribe once
        mathOp.CalculateEvent += (a, b) => a + b;  // Subscribe twice

        mathOp.SumLogicWrapper(5, 7);


        List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "John" },
            new Contact { Id = 2, Name = "Jane" },
            new Contact { Id = 3, Name = "Doe" },
        };

        var firstContact = contacts.FirstOrDefault();
        Console.WriteLine($"First contact: {firstContact.Name}");

        var filteredContacts = contacts.Where(c => c.Name.StartsWith("J"));
        Console.WriteLine("Contacts starting with J:");
        foreach (var contact in filteredContacts)
        {
            Console.WriteLine(contact.Name);
        }

        var names = contacts.Select(c => c.Name);
        Console.WriteLine("All names:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        var anyJohn = contacts.Any(c => c.Name == "John");
        Console.WriteLine($"Any contact named John? {anyJohn}");

        var allStartWithJ = contacts.All(c => c.Name.StartsWith("J"));
        Console.WriteLine($"All contacts start with J? {allStartWithJ}");

        var countOfJs = contacts.Count(c => c.Name.StartsWith("J"));
        Console.WriteLine($"Number of contacts starting with J: {countOfJs}");
    }
}