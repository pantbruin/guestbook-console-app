﻿using System;
namespace GuestBookUtilities;

/*
 * To do:
 * Address clashes (e.g. if a guest family name is already in the guest book, what to do?)
 * 
 * 
 */

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
            if (!FamilyNameIsValid(familyName)) continue;
            if (familyName is not null && (familyName.Trim().ToLower() == "finish"))
            {
                if (DoesUserWantToQuit())
                {
                    return;
                }
                else
                {
                    continue;
                }
            }

            familyName = NormalizeFamilyName(familyName);

        GetInteger:
            string? partySizeAsString;
            do
            {
                partySizeAsString = GetPartySize(familyName);
            } while (!PartySizeAsStringIsValid(partySizeAsString));

            if (partySizeAsString is not null && (partySizeAsString.Trim().ToLower() == "finish"))
            {

                if (DoesUserWantToQuit())
                {
                    return;
                }
                else
                {
                    continue;
                }
            }

            int? partySizeAsInt = ParsePartySize(partySizeAsString);
            if (partySizeAsInt is null) goto GetInteger;

            AddGuestToGuestBook(familyName, (int)partySizeAsInt);



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

    private static bool FamilyNameIsValid(string? familyName)
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

    /* Normalizes a family name so that the first letter is capitalized and 
    every other letter is lowercased*/
    private static string NormalizeFamilyName(string? rawFamilyName)
    {
        if (rawFamilyName is null)
        {
            throw new ArgumentException("rawFamilyName cannot be null");
        }

        string lowerCased = rawFamilyName.ToLower();
        return char.ToUpper(lowerCased[0]) + lowerCased.Substring(1);

    }

    private static bool PartySizeAsStringIsValid(string? partySizeAsString)
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

    private static int? ParsePartySize(string? partySizeAsString)
    {
        if (partySizeAsString is null)
        {
            throw new ArgumentException("partySizeAsString cannot be null");
        }

        if (!int.TryParse(partySizeAsString, out int partySizeAsInt))
        {
            Console.Clear();
            Console.WriteLine("ERROR: You must enter an integer amount for your party size!");
            Console.Write("Press the enter key to continue...");
            Console.ReadLine();
            return null;
        }
        else
        {
            return partySizeAsInt;
        }
    }

    private static void AddGuestToGuestBook(string familyName, int partySize)
    {
        guestBookDictionary[familyName] = partySize;
        Console.Clear();
        Console.WriteLine($"{familyName} family party of {partySize} successfully added to Guest Book!");
        Console.Write("Press enter to continue...");
        Console.ReadLine();
    }

    private static void PrintAppInstructions()
    {
        Console.Clear();
        Console.WriteLine("@@@@@ Follow the prompts or type 'finish' to finish building the Guest Book! @@@@");
        Console.WriteLine("===============================");
    }

    private static bool DoesUserWantToQuit()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to finish?");
            Console.Write("Type 'yes' to finish your entries or 'no' to continue building Guest Book: ");
            string? willUserExitResponse = Console.ReadLine();

            string[] validResponses = { "yes", "no" };

            if (willUserExitResponse is null || Array.IndexOf(validResponses, willUserExitResponse) == -1)
            {
                Console.Clear();
                Console.WriteLine("Error: You must enter either 'yes' if you want to finish or 'no' if you want to continue building the guestbook.");
                Console.Write("Press the enter key to continue...");
                Console.ReadLine();
                continue;
            }

            if (willUserExitResponse == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}



