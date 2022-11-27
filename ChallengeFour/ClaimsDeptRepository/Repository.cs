namespace ClaimsDept_Repository;

public class ClaimsDeptRepo
{
    protected readonly Queue<ClaimQueue> _claim = new Queue<ClaimQueue>();

    private int _count;

    // Create
    public bool CreateNewClaim(ClaimQueue claim)
    {

        _claim.Enqueue(claim);

        _count++;

        claim.ClaimID = _count;

        return true;
    }

    // Read
    public Queue<ClaimQueue> GetAllClaims()
    {
        return _claim;
    }

    // Read One
    public ClaimQueue NextClaim()
    {
        return _claim.Peek();
    }

    // Update
    public ClaimQueue ProcessNext()
    {
        return _claim.Dequeue();
    }

    // Delete
    public bool DeleteClaims(ClaimQueue claims)
    {
        _claim.Clear();

        return true;
    }
}
