using KomodoCafe_Repo;

public class ProgramUI
{
    KomodoCafeRepository _cafe = new KomodoCafeRepository();

    public void Run()
    {
        Seed();
        Menu();
    }

    private void Menu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Clear();
            
            System.Console.WriteLine("Welcome to Komodo Cafe System Management. Please choose from the following options:\n"
            + "1. Create new menu item.\n"
            + "2. View all menu items.\n"
            + "3. View item by item number.\n"
            + "4. Update menu item.\n"
            + "5. Delete menu item.\n"
            + "6. Exit.");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    CreateNewItem();
                    break;
                case "2":
                    ViewAllItems();
                    break;
                case "3":
                    ViewOneItem();
                    break;
                case "4":
                    UpdateMenuItem();
                    break;
                case "5":
                    DeleteMenuItem();
                    break;
                case "6":
                System.Console.WriteLine("Thank you for using Komodo Cafe Systems Management. Have a great day!");
                    keepRunning = false;
                    break;
                default:
                System.Console.WriteLine("Error. Please try again.");
                    break;
            }
            System.Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateNewItem()
    {
        Console.Clear();

        MenuItem newItem = new MenuItem();

        newItem.MealNum = _cafe.GetAllItems().Count + 1;

        System.Console.WriteLine("Please enter a name for your new menu item:");
        string input = Console.ReadLine();
        newItem.MealName = input;

        System.Console.WriteLine("Please enter a description for your new menu item:");
        string desInput = Console.ReadLine();
        newItem.MealDescription = desInput;

        System.Console.WriteLine("PLease enter the list of ingredients for this menu item:");
        string listInput = Console.ReadLine();
        newItem.ListOfIngredients = listInput;

        System.Console.WriteLine("Please enter the price for this menu item:");
        double priceInput = double.Parse(Console.ReadLine());
        newItem.Price = priceInput;

        System.Console.WriteLine("Please select whether this menu item is gluten free:\n"
        + "1. Yes\n"
        + "2. No");
        int glutenInput = int.Parse(Console.ReadLine());
        newItem.GlutenStatus = (GlutenStatus)glutenInput;

        bool itemAdded = _cafe.CreateNewItem(newItem);

        if (itemAdded)
        {
            System.Console.WriteLine("New menu item added successfully.");
        }
        else
        {
            System.Console.WriteLine("Unable to add new menu item.");
        }
    }

    private void ViewAllItems()
    {
        if (_cafe.GetAllItems().Count > 0)
        {
            foreach (MenuItem itemList in _cafe.GetAllItems())
            {
                DisplayItem(itemList);
            }
        }
        else
        {
            System.Console.WriteLine("There are no menu items to display.");
        }
    }

    private void ViewOneItem()
    {
        ViewAllItems();

        System.Console.WriteLine("Please enter the Meal # of the menu item you would like to view:");
        int input = int.Parse(Console.ReadLine());

        MenuItem itemToView = _cafe.GetOneItem(input);

        if (itemToView != null)
        {
            DisplayItem(itemToView);
        }
        else
        {
            System.Console.WriteLine("There is no menu item that matches that inquiry.");
        }
    }

    private void UpdateMenuItem()
    {
        ViewAllItems();

        System.Console.WriteLine("Please enter the Meal # of the menu item you would like to update:");
        int input = int.Parse(Console.ReadLine());

        MenuItem newItem = new MenuItem();

        System.Console.WriteLine("Please enter a new name for this item:");
        newItem.MealName = Console.ReadLine();
        
        System.Console.WriteLine("Please enter a new description for this item:");
        newItem.MealDescription = Console.ReadLine();
        
        System.Console.WriteLine("Please enter a new list of ingredients for this item:");
        newItem.ListOfIngredients = Console.ReadLine();
        
        System.Console.WriteLine("Please enter a new price for this item:");
        int priceInput = int.Parse(Console.ReadLine());
        newItem.Price = priceInput;

        System.Console.WriteLine("Please choose whether this item is gluten free or not:\n"
        + "1. Yes\n"
        + "2. No");
        int glutenInput = int.Parse(Console.ReadLine());
        newItem.GlutenStatus = (GlutenStatus)glutenInput;

        bool updateSuccess = _cafe.UpdateItem(input, newItem);

        if (updateSuccess)
        {
            System.Console.WriteLine("Item updated successfully.");
        }
        else
        {
            System.Console.WriteLine("Unable to update item.");
        }
    }

    private void DeleteMenuItem()
    {
        ViewAllItems();

        System.Console.WriteLine("Please enter the Meal # of the menu item you would like to delete:");
        int input = int.Parse(Console.ReadLine());

        bool deleteSuccess = _cafe.DeleteItem(input);

        if (deleteSuccess)
        {
            System.Console.WriteLine("Menu item successfully deleted.");
        }
        else
        {
            System.Console.WriteLine("Unable to delete menu item.");
        }
    }

    private void DisplayItem(MenuItem item)
    {
        System.Console.WriteLine("\n"
        + $"Meal #: {item.MealNum} | {item.MealName}\n"
        + "-----------------------\n"
        + $"Price: {item.Price}\n"
        + $"Ingredients: {item.ListOfIngredients}\n"
        + $"Description: {item.MealDescription} | Gluten Free: {item.GlutenStatus}\n"
        + "");
    }

    private void Seed()
    {
        MenuItem chickenBBQ = new MenuItem(_cafe.GetAllItems().Count + 1, "Chicken BBQ", "The most delicious Chicken BBQ sandwich on the East Coast!", "chicken, bbq sauce, garlic spread, bread, spices, fries", 8.95, GlutenStatus.No);

        MenuItem pepperoniAvocadoFlatBread = new MenuItem(_cafe.GetAllItems().Count + 1, "Pepperoni Avocado FlatBread", "Artisan pizza with crisp pepperoni, our special in house Marinara, and soft ripe avocado", "dough, pepperoni, marinara, avocado", 12.95, GlutenStatus.No);

        MenuItem toastedArugulaSalad = new MenuItem(_cafe.GetAllItems().Count + 1, "Toasted Arugula Salad", "Air fried arugula leaves with a raspberry balsamic vinaigrette and almonds and grilled chicken.", "arugula, vinaigrette, almonds, grilled chicken", 5.95, GlutenStatus.Yes);

        _cafe.CreateNewItem(chickenBBQ);
        _cafe.CreateNewItem(pepperoniAvocadoFlatBread);
        _cafe.CreateNewItem(toastedArugulaSalad);
    }
}