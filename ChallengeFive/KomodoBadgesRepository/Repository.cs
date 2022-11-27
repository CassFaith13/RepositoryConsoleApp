namespace KomodoBadgesRepository;

// CRUD
public class KomodoBadges_Repository
{
    protected readonly Dictionary<int, BadgeList> _komodo = new Dictionary<int, BadgeList>();

    private int _count;

    // Create
    public bool CreateNewBadge(BadgeList badge)
    {
        
        _count++;

        badge.BadgeID = _count;

        _komodo.Add(badge.BadgeID, badge);

        return true;
    }

    // Read
    public Dictionary<int, BadgeList> GetAllBadges()
    {
        return _komodo;
    }

    // Read One
    public BadgeList GetOneBadge(int viewBadge)
    {
        foreach (var badge in _komodo.Values) //Do I want to loop through keys or values, etc
            if (badge.BadgeID == viewBadge)
            {
                return badge;
            }
        return null;
    }

    // Update
    public bool UpdateBadge(int oldID, BadgeList newBadge)
    {
        BadgeList oldBadge = GetOneBadge(oldID);

        if (oldBadge != null)
        {
            oldBadge.Name = newBadge.Name;
            oldBadge.DoorAccess = newBadge.DoorAccess;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Delete
    public bool RemoveBadgeAccess(BadgeList badge)
    {
        bool deleteResult = _komodo.Remove(badge.BadgeID);

        return deleteResult;
    }
}