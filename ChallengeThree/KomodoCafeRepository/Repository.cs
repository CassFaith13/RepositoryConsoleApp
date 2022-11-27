namespace KomodoCafe_Repo;

public class KomodoCafeRepository
{
    protected readonly List<MenuItem> _menu = new List<MenuItem>();

    private int _count;

    public bool CreateNewItem(MenuItem item)
    {
        _menu.Add(item);

        _count++;

        item.MealNum = _count;

        return true;
    }

    public List<MenuItem> GetAllItems()
    {
        return _menu;
    }

    public MenuItem GetOneItem(int viewItem)
    {
        return _menu.Find(item => item.MealNum == viewItem);
    }

    public bool UpdateItem(int mealNum, MenuItem newItem)
    {
        MenuItem oldItem = _menu.Find(item => item.MealNum == mealNum);

        if (oldItem != null)
        {
            oldItem.MealName = newItem.MealName != "" ? newItem.MealName : oldItem.MealName;
            oldItem.MealDescription = newItem.MealDescription != "" ? newItem.MealDescription : oldItem.MealDescription;
            oldItem.ListOfIngredients = newItem.ListOfIngredients != "" ? newItem.ListOfIngredients : oldItem.ListOfIngredients;
            oldItem.Price = newItem.Price != 0 ? newItem.Price : oldItem.Price;
            oldItem.GlutenStatus = newItem.GlutenStatus != 0 ? newItem.GlutenStatus : oldItem.GlutenStatus;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteItem(int mealNum)
    {
        MenuItem itemToDelete = _menu.Find(item => item.MealNum == mealNum);

        bool deleteResult = _menu.Remove(itemToDelete);

        return deleteResult;
    }
}