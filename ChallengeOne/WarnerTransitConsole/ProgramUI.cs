using WarnerTransit_Repo;

public class ProgramUI
{
    DeliveryRepository _order = new DeliveryRepository();

    public void Run()
    {
        Seed();
        Order();
    }

    private void Order()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            
            System.Console.WriteLine("Welcome to Warner Transit Federal. Please choose from the following options:\n"
            + "1. Add new delivery to route.\n"
            + "2. View all deliveries.\n"
            + "3. View delivery by Item Number.\n"
            + "4. Update delivery status.\n"
            + "5. Cancel a delivery.\n"
            + "6. Exit.");

            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    CreateNewDelivery();
                    break;
                case "2":
                    ViewAllDeliveries();
                    break;
                case "3":
                    ViewOneDelivery();
                    break;
                case "4":
                    UpdateDeliveryStatus();
                    break;
                case "5":
                    CancelDelivery();
                    break;
                case "6":
                System.Console.WriteLine("Thank you for using Warner Transit Federal. Have a great day!");
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

    private void CreateNewDelivery()
    {
        Console.Clear();

        DeliveryOrder newOrder = new DeliveryOrder();

        newOrder.ItemNum = _order.GetAllRoutes().Count + 1;

        System.Console.WriteLine("PLease choose the status of the order:\n"
        + "1. Scheduled\n"
        + "2. EnRoute\n"
        + "3. Complete\n"
        + "4. Cancelled\n"
        + "5. Unable To Locate");

        int input = int.Parse(Console.ReadLine());
        newOrder.DeliveryStatus = (DeliveryStatus)input;

        System.Console.WriteLine("Please enter date of expected/completed delivery (MM/DD/YYYY):");
        DateTime deliveryInput = DateTime.Parse(Console.ReadLine());
        newOrder.DeliveryDate = deliveryInput;

        System.Console.WriteLine("Please enter the Customer ID (XXX):");
        int custInput = int.Parse(Console.ReadLine());
        newOrder.CustomerID = custInput;

        System.Console.WriteLine("Please enter the date the item was ordered (MM/DD/YYYY):");
        DateTime orderInput = DateTime.Parse(Console.ReadLine());
        newOrder.OrderDate = orderInput;

        System.Console.WriteLine("Please enter how many items in this order:");
        int qtyInput = int.Parse(Console.ReadLine());
        newOrder.ItemQty = qtyInput;

        bool orderAdded = _order.CreateNewDelivery(newOrder);

        if (orderAdded)
        {
            System.Console.WriteLine("Delivery order added successfully.");
        }
        else
        {
            System.Console.WriteLine("Unable to add delivery order.");
        }
    }

    private void ViewAllDeliveries()
    {
        if (_order.GetAllRoutes().Count > 0)
        {
            foreach (DeliveryOrder orderList in _order.GetAllRoutes())
            {
                DisplayOrder(orderList);
            }
        }
        else
        {
            System.Console.WriteLine("There are no deliveries to view.");
        }
    }

    private void ViewOneDelivery()
    {
        ViewAllDeliveries();

        System.Console.WriteLine("Please enter the Item Number of the delivery you would like to view:");
        int input = int.Parse(Console.ReadLine());
        DeliveryOrder orderToView = _order.GetOneRoute(input);

        if (orderToView != null)
        {
            DisplayOrder(orderToView);
        }
        else
        {
            System.Console.WriteLine("There are no routes that match that inquiry.");
        }
    }

    private void UpdateDeliveryStatus()
    {
        ViewAllDeliveries();

        System.Console.WriteLine("Please enter the Item Number of the delivery you would like to update:");
        int input = int.Parse(Console.ReadLine());
        DeliveryOrder newOrder = new DeliveryOrder();

        System.Console.WriteLine("Please enter the new delivery status for this order:\n"
        + "1. Scheduled\n"
        + "2. EnRoute\n"
        + "3. Complete\n"
        + "4. Cancelled\n"
        + "5. Unable To Locate");
        int statusInput = int.Parse(Console.ReadLine());
        newOrder.DeliveryStatus = (DeliveryStatus)statusInput;

        bool updateSuccess = _order.UpdateDeliveryStatus(input, newOrder);

        if (updateSuccess)
        {
            System.Console.WriteLine("Delivery status updated successfully.");
        }
        else
        {
            System.Console.WriteLine("Unable to update delivery status.");
        }
    }

    private void CancelDelivery()
    {
        ViewAllDeliveries();

        System.Console.WriteLine("Please enter the Item Number of the delivery you would like to cancel:");
        int input = int.Parse(Console.ReadLine());

        bool deleteSuccess = _order.CancelDelivery(input);

        if (deleteSuccess)
        {
            System.Console.WriteLine("Delivery successfully cancelled.");
        } 
        else
        {
            System.Console.WriteLine("Unable to cancel delivery.");
        }
    }

    private void DisplayOrder(DeliveryOrder order)
    {
        // Console.Clear();
        
        System.Console.WriteLine("\n"
        + $"Item #: {order.ItemNum} | Delivery Status: {order.DeliveryStatus} on {order.DeliveryDate}\n"
        + "---------------------\n"
        + $"Customer ID: {order.CustomerID} | Order Date: {order.OrderDate} | Item Quantity: {order.ItemQty}\n"
        + "");
    }

    private void Seed()
    {
        DeliveryOrder orderOne = new DeliveryOrder(_order.GetAllRoutes().Count + 1, DeliveryStatus.Complete, new DateTime(2022 , 10 , 31), 111, new DateTime(2022 , 10 , 01), 4);
        DeliveryOrder orderTwo = new DeliveryOrder(_order.GetAllRoutes().Count + 1, DeliveryStatus.EnRoute, new DateTime(2022 , 12 , 01), 222, new DateTime(2022 , 1 , 25), 1);
        DeliveryOrder orderThree = new DeliveryOrder(_order.GetAllRoutes().Count + 1, DeliveryStatus.Scheduled, new DateTime(2022 , 12 , 24), 333, new DateTime(2022 , 09 , 15), 2);
        DeliveryOrder orderFour = new DeliveryOrder(_order.GetAllRoutes().Count + 1, DeliveryStatus.Cancelled, new DateTime(2022 , 11 , 12), 444, new DateTime(2022 , 10 , 22), 10);
        DeliveryOrder orderFive = new DeliveryOrder(_order.GetAllRoutes().Count + 1, DeliveryStatus.UnableToLocate, new DateTime(2022 , 12 , 15), 111, new DateTime(2022 , 05 , 01), 1);

        _order.CreateNewDelivery(orderOne);
        _order.CreateNewDelivery(orderTwo);
        _order.CreateNewDelivery(orderThree);
        _order.CreateNewDelivery(orderFour);
        _order.CreateNewDelivery(orderFive);
    }
}