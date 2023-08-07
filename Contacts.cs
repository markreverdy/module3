using System;
using System.Globalization;

public class ContactCollection
{
    public class Contact
    {
        public string Name { get; set; }
        public string AlphabetKey { get; set; }
    }

    private SortedDictionary<string, List<Contact>> contacts;
    private Func<Contact, string> alphabetSelector;

    public ContactCollection(Func<Contact, string> alphabetSelector = null)
    {
        this.alphabetSelector = alphabetSelector ?? (contact => contact.Name);
        this.contacts = new SortedDictionary<string, List<Contact>>();
    }

    public void Add(Contact contact, CultureInfo cultureInfo)
    {
        if (cultureInfo != new CultureInfo("en-US") && cultureInfo != new CultureInfo("uk-UA"))
        {
            cultureInfo = new CultureInfo("en-US"); // default to English
        }

        string key;
        char firstChar = this.alphabetSelector(contact).FirstOrDefault();

        if (char.IsDigit(firstChar))
        {
            key = "0-9";
        }
        else if (char.IsLetter(firstChar))
        {
            if (cultureInfo.Equals(new CultureInfo("uk-UA")) && firstChar >= 'А' && firstChar <= 'Я' || firstChar >= 'а' && firstChar <= 'я' || firstChar == 'Ї' || firstChar == 'ї' || firstChar == 'І' || firstChar == 'і' || firstChar == 'Є' || firstChar == 'є')
            {
                key = firstChar.ToString().ToUpper(cultureInfo);
            }
            else if (cultureInfo.Equals(new CultureInfo("en-US")) && firstChar >= 'A' && firstChar <= 'Z' || firstChar >= 'a' && firstChar <= 'z')
            {
                key = firstChar.ToString().ToUpper(cultureInfo);
            }
            else
            {
                key = "#";
            }
        }
        else
        {
            key = "#";
        }

        if (!contacts.ContainsKey(key))
        {
            contacts[key] = new List<Contact>();
        }

        contacts[key].Add(contact);
    }

    public void DisplayContacts()
    {
        foreach (KeyValuePair<string, List<Contact>> entry in contacts)
        {
            Console.WriteLine($"{entry.Key}:");
            foreach (Contact contact in entry.Value)
            {
                Console.WriteLine($"\t{contact.Name}");
            }
        }
    }
    static void Main(string[] args)
    {
        var contactCollection = new ContactCollection(c => c.AlphabetKey);
        contactCollection.Add(new Contact { Name = "Alice", AlphabetKey = "A" }, new CultureInfo("en-US"));
        contactCollection.Add(new Contact { Name = "Bob", AlphabetKey = "B" }, new CultureInfo("en-US"));
        contactCollection.Add(new Contact { Name = "Charlie", AlphabetKey = "C" }, new CultureInfo("en-US"));
        contactCollection.Add(new Contact { Name = "Борис", AlphabetKey = "А" }, new CultureInfo("uk-UA"));
        contactCollection.Add(new Contact { Name = "Андрій", AlphabetKey = "Б" }, new CultureInfo("uk-UA"));
        contactCollection.Add(new Contact { Name = "Віктор", AlphabetKey = "В" }, new CultureInfo("uk-UA"));
        contactCollection.Add(new Contact { Name = "2Fast", AlphabetKey = "0" }, new CultureInfo("en-US"));
        contactCollection.DisplayContacts();
    }
}
