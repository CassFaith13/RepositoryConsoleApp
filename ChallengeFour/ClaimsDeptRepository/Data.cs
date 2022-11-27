namespace ClaimsDept_Repository;

public class ClaimQueue
{
    public ClaimQueue() { }

    public ClaimQueue(int claimID, ClaimType claimType, string clientName, DateTime dateOfIncident, string description, DateTime dateOfClaim, double claimAmount, ValidStatus validStatus)
    {
        ClaimID = claimID;
        ClaimType = claimType;
        ClientName = clientName;
        DateOfIncident = dateOfIncident;
        Description = description;
        DateOfClaim = dateOfClaim;
        ClaimAmount = claimAmount;
        ValidStatus = validStatus;
    }

    public int ClaimID { get; set; }
    public ClaimType ClaimType { get; set; }
    public string ClientName { get; set; }
    public DateTime DateOfIncident { get; set; }
    public string Description { get; set; }
    public DateTime DateOfClaim { get; set; }
    public double ClaimAmount { get; set; }
    public ValidStatus ValidStatus { get; set; }
    public bool IsValid
    {
        get
        {
            switch (ValidStatus)
            {
                case ValidStatus.Yes:
                    return true;
                case ValidStatus.No:
                    return false;
                default:
                    return false;
            }
        }
    }
}

public enum ValidStatus { Yes =1, No }
public enum ClaimType { Car = 1, Home, Theft }