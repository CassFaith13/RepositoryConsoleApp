using ClaimsDept_Repository;

public class ProgramUI
{
    ClaimsDeptRepo _insurance = new ClaimsDeptRepo();

    public void Run()
    {
        Seed();
        Claims();
    }

    public void Claims()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            
            System.Console.WriteLine("Welcome to Komodo Insurance. Please select from the following option:\n"
            + "1. Create a new claim.\n"
            + "2. View next claim in queue.\n"
            + "3. View all claims in queue.\n"
            + "4. Process claim in queue.\n"
            + "5. Remove all claims.\n"
            + "6. Exit.");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateNewCLaim();
                    break;
                case "2":
                    ViewNextClaim();
                    break;
                case "3":
                    ViewAllClaims();
                    break;
                case "4":
                    ProcessNextClaim();
                    break;
                case "5":
                    RemoveAllClaims();
                    break;
                case "6":
                System.Console.WriteLine("Thank you for using Komodo Insurance Services. Have a great day.");
                    keepRunning = false;
                    break;
                default:
                System.Console.WriteLine("Error. Please try again!");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateNewCLaim()
    {
        ClaimQueue newClaim = new ClaimQueue();

        newClaim.ClaimID = _insurance.GetAllClaims().Count + 1;

        System.Console.WriteLine("Please enter the claim type for your new claim:\n"
        + "1. Car\n"
        + "2. Home\n"
        + "3. Theft");

        int typeInput = int.Parse(Console.ReadLine());
        newClaim.ClaimType = (ClaimType)typeInput;

        System.Console.WriteLine("Please enter the date of the incident:");
        DateTime incInput = DateTime.Parse(Console.ReadLine());
        newClaim.DateOfIncident = (DateTime)incInput;

        System.Console.WriteLine("Please enter a description of the incident:");
        newClaim.Description = Console.ReadLine();
        
        System.Console.WriteLine("Please enter the date the incident was reported:");
        DateTime claimInput = DateTime.Parse(Console.ReadLine());
        newClaim.DateOfClaim = (DateTime)claimInput;

        System.Console.WriteLine("Please choose if this claim was reported within 30 days of the incident date:\n"
        + "1. Yes\n"
        + "2. No");

        int validInput = int.Parse(Console.ReadLine());
        newClaim.ValidStatus = (ValidStatus)validInput;

        bool claimAdded = _insurance.CreateNewClaim(newClaim);

        if (claimAdded)
        {
            System.Console.WriteLine("Claim added to queue successfully.");
        }
        else
        {
            System.Console.WriteLine("Claim NOT added to queue. Please try again.");
        }
    }

    private void ViewNextClaim()
    {
        Queue<ClaimQueue> claims = _insurance.GetAllClaims();

        if (claims.Count > 0)
        {
            ClaimQueue viewNext = _insurance.NextClaim();

            DisplayClaim(viewNext);
        }
        else
        {
            System.Console.WriteLine("There is no claim next in queue.");
        }
    }

    private void ViewAllClaims()
    {
        if (_insurance.GetAllClaims().Count > 0)
        {
            foreach (ClaimQueue claim in _insurance.GetAllClaims())
            {
                DisplayClaim(claim);
            }
        }
        else
        {
            System.Console.WriteLine("There are no claims to view.");
        }
    }

    private void ProcessNextClaim()
    {
        if (_insurance.GetAllClaims().Count > 0)
        {
            ClaimQueue claim = _insurance.NextClaim();

            System.Console.WriteLine($"Claim ID: {claim.ClaimID} | {claim.ClaimType}\n"
            + "-----------------\n"
            + $"Client Name: {claim.ClientName}\n"
            + $"Date Of Incident: {claim.DateOfIncident}\n"
            + $"Description of incident: {claim.Description}\n"
            + $"Claim Amount: {claim.ClaimAmount}\n"
            + $"Date Of Claim: {claim.DateOfClaim}\n"
            + $"Is claim within 30 days of incident? {claim.ValidStatus}\n"
            + "");

            System.Console.WriteLine("Would you like to process this claim?\n"
            + "1. Yes\n"
            + "2. No");
            string processInput = Console.ReadLine();
            
            switch (processInput)
            {
                case "1":
                ClaimQueue processClaim = _insurance.ProcessNext();
                System.Console.WriteLine("Claim successfully processed!");
                break;
                case"2":
                System.Console.WriteLine("Back to main menu.");
                break;
                default:
                System.Console.WriteLine("Error. Please try again.");
                break;
            }
        }
        else
        {
            System.Console.WriteLine("There are no claims to process.");
        }
    }

    private void RemoveAllClaims()
    {
        if (_insurance.GetAllClaims().Count > 0)
        {
            ClaimQueue claims = new ClaimQueue();

            System.Console.WriteLine("Are you sure you want to delete ALL claims in queue? This cannot be undone.\n"
            + "1. Yes\n"
            + "2. No");
            string deleteInput = Console.ReadLine();
            switch (deleteInput)
            {
                case "1":
                bool claimToDelete = _insurance.DeleteClaims(claims);
                
                if (claimToDelete)
                {
                    System.Console.WriteLine("Claims successfully deleted from system.");
                    Console.ReadKey();
                }
                else
                {
                    System.Console.WriteLine("Claims NOT deleted from system. Please try again.");
                }
                    break;
                case "2":
                    System.Console.WriteLine("Back to main menu.");
                    break;
                default:
                    System.Console.WriteLine("Error. Please try again.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("There are no claims to delete.");
        }
    }

    private void DisplayClaim(ClaimQueue claim)
    {
        System.Console.WriteLine($"Claim ID: {claim.ClaimID} | {claim.ClaimType}\n"
        + "-----------------\n"
        + $"Client Name: {claim.ClientName}\n"
        + $"Date Of Incident: {claim.DateOfIncident}\n"
        + $"Description of incident: {claim.Description}\n"
        + $"Claim Amount: {claim.ClaimAmount}\n"
        + $"Date Of Claim: {claim.DateOfClaim}\n"
        + $"Is claim within 30 days of incident? {claim.ValidStatus}\n"
        + "");
    }

    private void Seed()
    {
        ClaimQueue faith = new ClaimQueue(_insurance.GetAllClaims().Count + 1, ClaimType.Car, "Faith", new DateTime(2022, 11, 01), "Client's SUV was rear-ended at a red light on Lacienga Boulevard and Malcom X Drive.", new DateTime(2022, 11, 04), 600.89, ValidStatus.Yes);
        ClaimQueue royall = new ClaimQueue(_insurance.GetAllClaims().Count + 1, ClaimType.Home, "Royall", new DateTime(2022, 08, 28), "Client's apartment burned down while he was sleeping. Client was in the hospital for 3 months. Total loss.", new DateTime(2022, 11, 15), 500135.24, ValidStatus.No);
        ClaimQueue briggs = new ClaimQueue(_insurance.GetAllClaims().Count + 1, ClaimType.Theft, "Briggs", new DateTime(2022, 10, 31), "Client's home was broken into on Halloween. Incident was recorded on camera.", new DateTime(2022, 11, 10), 2500, ValidStatus.Yes);

        _insurance.CreateNewClaim(faith);
        _insurance.CreateNewClaim(royall);
        _insurance.CreateNewClaim(briggs);
    }
}