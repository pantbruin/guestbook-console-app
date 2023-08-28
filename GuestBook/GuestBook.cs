using System;
namespace GuestBookUtilities;

	public static class GuestBook
	{
		public static void BuildGuestBook()
		{
        Console.WriteLine("Welcome to Build a Guestbook App!");
        Console.WriteLine("To begin, push the enter key...");
        Console.ReadLine();
        Console.Clear();

        while (true)
        {
            string? familyName = GetFamilyName();
            Console.WriteLine($"Entered: {familyName}");

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
	}

