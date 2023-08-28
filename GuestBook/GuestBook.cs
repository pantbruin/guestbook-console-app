using System;
namespace GuestBookUtilities;

public static class GuestBook
{
    private static Dictionary<string, int> guestBookDictionary = new();
    public static void BuildGuestBook()
    {
        Console.WriteLine("Welcome to Build a Guestbook App!");
        Console.WriteLine("To begin, push the enter key...");
        Console.ReadLine();
        Console.Clear();

        while (true)
        {
            string? familyName = GetFamilyName();
            Console.WriteLine($"Entered family name: {familyName}");
            int? partySize = GetPartySize(familyName);
            Console.WriteLine($"Entered party size: {partySize}");

        }
    }

    private static string? GetFamilyName()
    {
        Console.Write("What is your family name?: ");
        string? familyName = Console.ReadLine();

        if (familyName is null || familyName == String.Empty)
        {
            return null;
        }
        else
        {
            return familyName;
        }
    }

    private static int? GetPartySize(string familyName)
    {

        while (true)
        {
            Console.Write($"How many people are in the {familyName} party?: ");
            string? partySize = Console.ReadLine();


            // Error check for non-integers
            if (partySize is null || partySize == String.Empty || !int.TryParse(partySize, out int partySizeAsInt))
            {
                Console.WriteLine("You must enter an integer amount for your party size!");
                continue;
            }
            else
            {
                return partySizeAsInt;
            }

        }
    }
}



