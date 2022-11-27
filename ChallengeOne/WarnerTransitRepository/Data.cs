namespace WarnerTransit_Repo;

public class DeliveryOrder
{
    public DeliveryOrder() { }

    public DeliveryOrder(int itemNum, DeliveryStatus deliveryStatus, DateTime deliveryDate, int customerID, DateTime orderDate, int itemQty)
    {
        ItemNum = itemNum;
        DeliveryStatus = deliveryStatus;
        DeliveryDate = deliveryDate;
        CustomerID = customerID;
        OrderDate = orderDate;
        ItemQty = itemQty;
    }

    public int ItemNum { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public int ItemQty { get; set; }
}

public enum DeliveryStatus { Scheduled = 1, EnRoute, Complete, Cancelled, UnableToLocate }