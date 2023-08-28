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
            if (!familyNameIsValid(familyName)) continue;
            // to do: sanitize familyName
            //if (doesUserWantToQuit(familyName)) return;

            string? partySizeAsString;
            do
            {
                partySizeAsString = GetPartySize(familyName);
            } while (!partySizeAsStringIsValid(partySizeAsString));


        }
    }

    private static string? GetFamilyName()
    {
        PrintAppInstructions();
        Console.Write("What is your family name?: ");
        string? familyName = Console.ReadLine();

        return familyName;
    }

    private static string? GetPartySize(string? familyName)
    {
        PrintAppInstructions();
        Console.Write($"How many people are in the {familyName} party?: ");
        string? partySizeAsString = Console.ReadLine();

        return partySizeAsString;

    }

    private static bool familyNameIsValid(string? familyName)
    {
        if (familyName is null || familyName.Trim() == String.Empty || familyName.Trim().Length < 2)
        {
            Console.Clear();
            Console.WriteLine("ERROR: Your family name must be at least 2 characters! Press the enter key to continue...");
            Console.ReadLine();
            return false;
        }
        else
        {
            return true;
        }
    }

    private static bool partySizeAsStringIsValid(string? partySizeAsString)
    {
        if (partySizeAsString is null || partySizeAsString.Trim() == String.Empty)
        {
            Console.Clear();
            Console.WriteLine("ERROR: You need to enter an integer party size. Press the enter key to continue...");
            Console.ReadLine();
            return false;
        }
        else
        {
            return true;
        }
    }

    private static void PrintAppInstructions()
    {
        Console.Clear();
        Console.WriteLine("@@@@@ Follow the prompts or type 'exit' to finish building the Guest Book! @@@@");
        Console.WriteLine("===============================");
    }

    //private static bool doesUserWantToQuit(string? userInput)
    //{
    //    if (userInput is not null && !(userInput.Trim().ToLower() == "exit"))
    //    {
    //        return false;
    //    }

    //    while (true)
    //    {
    //        Console.WriteLine("Are you sure you want to exit?");
    //        Console.Write("Type 'yes' to finish your entries or 'no' to continue building Guest Book: ");
    //        string? willUserExitResponse = Console.ReadLine();

    //        string[] validResponses = { "yes", "no" };

    //        if (willUserExitResponse is null || Array.IndexOf(validResponses, willUserExitResponse) == -1)
    //        {
    //            Console.WriteLine("Error: You must enter either 'yes' if you want to finish or 'no' if you want to continue building the guestbook.");
    //            continue;
    //        }

    //        if (userInput == "yes" || userInput == "y") return true;
    //        else return false;

    //    }
    //}
}



