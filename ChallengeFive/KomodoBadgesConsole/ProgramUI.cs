using KomodoBadgesRepository;

public class ProgramUI
{
    private KomodoBadges_Repository _kRepo = new KomodoBadges_Repository();

    public void Run()
    {
        Seed();
        Badge();
    }

    private void Badge()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Komodo Insurance. Please choose from the following options:\n"
            + "1. Create a new employee badge.\n"
            + "2. Update Access to an existing badge.\n"
            + "3. Remove access from an existing badge.\n"
            + "4. View all badges and access privileges.\n"
            + "5. View one employee badge.\n"
            + "6. Exit.");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BuildNewBadge();
                    break;
                case "2":
                    UpdateAccess();
                    break;
                case "3":
                    RemoveAccess();
                    break;
                case "4":
                    ViewAllBadges();
                    break;
                case "5":
                    ViewOneBadge();
                    break;
                case "6":
                System.Console.WriteLine("Thank you! Have a great day.");
                    keepRunning = false;
                    break;
                default:
                System.Console.WriteLine("Error. Please try again.");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void BuildNewBadge()
    {
        Console.Clear();

        // List<string> doorAccess = new List<string>();
        BadgeList newBadge = new BadgeList();

        newBadge.BadgeID = _kRepo.GetAllBadges().Count + 1;

        System.Console.WriteLine("Please enter the last name of the employee assigned to this badge:");
        string nameInput = Console.ReadLine();

        newBadge.Name = nameInput;

        System.Console.WriteLine("Please enter the door this badge has access to:\n"
        + "1. A1\n"
        + "2. A2\n"
        + "3. B1\n"
        + "4. B2");
        int inputAccess = int.Parse(Console.ReadLine());
        newBadge.DoorAccess = (DoorAccess)inputAccess;

        bool updateSuccess = _kRepo.CreateNewBadge(newBadge);

        if (updateSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("New badge successfully created.");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("New badge NOT created. Please try again.");
        }
    }

    private void UpdateAccess()
    {
        Console.Clear();
        ViewAllBadges();

        System.Console.WriteLine("Please enter the ID number of the employee badge you would like to update door access to:");
        int input = int.Parse(Console.ReadLine());

        BadgeList badge = _kRepo.GetOneBadge(input);

        // List<string> doorAccess = new List<string>();

        BadgeList newBadge = new BadgeList();

        System.Console.WriteLine($"Badge {badge.BadgeID} has access to door(s): {badge.DoorAccess}.");

        System.Console.WriteLine("Would you like to add a door access to this badge?\n"
        + "1. Yes.\n"
        + "2. No");
        string inputString = Console.ReadLine();
        
        switch (inputString)
        {
            case "1":
            Console.Clear();
            System.Console.WriteLine("Please enter the door this badge has access to:\n"
            + "1. A1\n"
            + "2. A2\n"
            + "3. B1\n"
            + "4. B2");
            int inputAccess = int.Parse(Console.ReadLine());
                // doorAccess.Add(inputAccess);
                newBadge.DoorAccess = (DoorAccess)inputAccess;
                break;
            case "2":
            Console.Clear();
            System.Console.WriteLine("Back to main menu.");
                break;
            default:
            System.Console.WriteLine("Error. Please try again.");
                break;
        }

        bool updateSuccess = _kRepo.UpdateBadge(input, newBadge);

        if (updateSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Badge access updated.");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Badge access NOT updated. Please try again!");
        }
    }

    private void RemoveAccess()
    {
        Console.Clear();
        ViewAllBadges();

        System.Console.WriteLine("Please enter the Badge ID you would like to remove:");
        int userBadge = int.Parse(Console.ReadLine());

        BadgeList badgeToDelete = _kRepo.GetOneBadge(userBadge);

        bool deleteSuccess = _kRepo.RemoveBadgeAccess(badgeToDelete);

        if (deleteSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Badge successfully deleted.");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Badge NOT deleted. Please try again.");
        }
    }

    private void ViewAllBadges()
    {
        Console.Clear();

        foreach (var badge in _kRepo.GetAllBadges())
        {
            System.Console.WriteLine(badge);
        }
    }

    private void ViewOneBadge()
    {
        Console.Clear();
        ViewAllBadges();

        System.Console.WriteLine("Please enter the Badge ID of the employee you would like to view:");
        int userInput = int.Parse(Console.ReadLine());

        BadgeList badge = _kRepo.GetOneBadge(userInput);

        if (badge != null)
        {
            DisplayBadge(badge);
        }
        else 
        {
            System.Console.WriteLine("This employee does not exist. Please try again.");
        }
    }

    private void DisplayBadge(BadgeList badge)
    {
        
        System.Console.WriteLine("\n"
        + $"BadgeID: {badge.BadgeID} | Name: {badge.Name}\n"
        + $"Door Access: {badge.DoorAccess}\n"
        + "--------------------");
    }

    private void Seed()
    {
        BadgeList faith = new BadgeList(_kRepo.GetAllBadges().Count + 1, "Faith", DoorAccess.A1);
        BadgeList royall = new BadgeList(_kRepo.GetAllBadges().Count + 1, "Royall", DoorAccess.A2);
        BadgeList briggs = new BadgeList(_kRepo.GetAllBadges().Count + 1, "Briggs", DoorAccess.B2);

        _kRepo.CreateNewBadge(faith);
        _kRepo.CreateNewBadge(royall);
        _kRepo.CreateNewBadge(briggs);
    }
}