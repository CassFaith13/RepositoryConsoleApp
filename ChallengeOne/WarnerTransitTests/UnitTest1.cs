using WarnerTransit_Repo;

namespace WarnerTransitTests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void SetDelivery()
    {
        DeliveryOrder order = new DeliveryOrder();
        order.ItemNum = 5;

        int expected = 5;
        int actual = order.ItemNum;

        Assert.AreEqual(expected, actual);
    }
}