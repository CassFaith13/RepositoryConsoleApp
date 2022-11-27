namespace WarnerTransit_Repo;

public class DeliveryRepository
{
    protected readonly List<DeliveryOrder> _delivery = new List<DeliveryOrder>();

    private int _count;

    public bool CreateNewDelivery(DeliveryOrder order)
    {
        _delivery.Add(order);

        _count++;

        order.ItemNum = _count;

        return true;
    }

    public List<DeliveryOrder> GetAllRoutes()
    {
        return _delivery;
    }

    public DeliveryOrder GetOneRoute(int viewOrder)
    {
        return _delivery.Find(order => order.ItemNum == viewOrder);
    }

    public bool UpdateDeliveryStatus(int itemNum, DeliveryOrder newOrder)
    {
        DeliveryOrder oldOrder = _delivery.Find(order => order.ItemNum == itemNum);

        if (oldOrder != null)
        {
            oldOrder.DeliveryStatus = newOrder.DeliveryStatus != 0 ? newOrder.DeliveryStatus : oldOrder.DeliveryStatus;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CancelDelivery (int itemNum)
    {
        DeliveryOrder orderToDelete = _delivery.Find(order => order.ItemNum == itemNum);

        bool deleteResult = _delivery.Remove(orderToDelete);

        return deleteResult;
    }
}
