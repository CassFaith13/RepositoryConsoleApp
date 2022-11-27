namespace KomodoBadgesRepository;

public class BadgeList
{
    public BadgeList() { }

    public BadgeList(int badgeID, string name, DoorAccess doorAccess)
    {
        BadgeID = badgeID;
        Name = name;
        DoorAccess = doorAccess;
    }

    public int BadgeID { get; set; }
    public string Name { get; set; }
    public DoorAccess DoorAccess { get; set; }

    public override string ToString()
    {
        var str = "\n" +
        $"BadgeID: {BadgeID} | Name: {Name}\n" +
        $"Door Access: {DoorAccess}\n" +
        "------------------";
        
        return str;
    }
}

public enum DoorAccess { A1 = 1, A2, B1, B2 }