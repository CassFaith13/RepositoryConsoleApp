namespace KomodoCafe_Repo;

public class MenuItem
{
    public MenuItem() {}

    public MenuItem(int mealNum, string mealName, string mealDescription, string listOfIngredients, double price, GlutenStatus glutenStatus)
    {
            MealNum = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            Price = price;
            GlutenStatus = glutenStatus;
        }

        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public double Price { get; set; }
        public GlutenStatus GlutenStatus { get; set; }
        public bool IsGlutenFree
        {
            get
            {
                switch (GlutenStatus)
                {
                    case GlutenStatus.Yes:
                        return true;
                    case GlutenStatus.No:
                        return false;
                    default:
                        return false;
                }
            }
        }
}

public enum GlutenStatus { Yes = 1, No }