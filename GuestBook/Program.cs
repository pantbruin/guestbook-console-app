using GuestBookUtilities;
internal class Program
{
    private static void Main(string[] args)
    {
        GuestBook.BuildGuestBook();
        GuestBook.PrintGuestListAndTotalGuests();
    }
}