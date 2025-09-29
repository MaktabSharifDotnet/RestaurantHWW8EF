using HWW8WithEF.DTO;
using HWW8WithEF.Entities;
using HWW8WithEF.Enums;
using HWW8WithEF.Exceptions;
using HWW8WithEF.Services;
using System.Linq.Expressions;

RestuarantService restuarantService = new RestuarantService();
while (true)
{
    ShowMenu();
    try
    {
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                ShowCategory();
                try
                {
                    string selectedOption = Console.ReadLine();
                    FoodCategoryEnum foodCategoryEnum = (FoodCategoryEnum)Enum.Parse(typeof(FoodCategoryEnum), selectedOption);
                    switch (foodCategoryEnum)
                    {
                        case FoodCategoryEnum.MainCourse:
                            ShowListRestuarant();
                            Console.WriteLine("please enter restaurantID");
                            int restaurantId = int.Parse(Console.ReadLine());
                            Console.WriteLine("please enter nameFood");
                            string nameMainCourse = Console.ReadLine();
                            Console.WriteLine("please enter price");
                            decimal priceMainCourse = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("isVegetarian : 1.true or 2.false");
                            string isVegetarianInput = Console.ReadLine();
                            bool isVegetarian = (isVegetarianInput == "1");
                            try
                            {
                                restuarantService.AddMainCourse(restaurantId,nameMainCourse, priceMainCourse, isVegetarian);
                                Console.WriteLine($"{nameMainCourse} added successfully.");
                            }
                            catch (FoodAlreadyExistException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            break;
                        case FoodCategoryEnum.Drink:
                            ShowListRestuarant();
                            Console.WriteLine("please enter restaurantID");
                             restaurantId = int.Parse(Console.ReadLine());
                            Console.WriteLine("please enter nameFood");
                            string nameDrink = Console.ReadLine();
                            Console.WriteLine("please enter price");
                            decimal priceDrink = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("isVegetarian : 1.true or 2.false");
                            string isAlcoholicInput = Console.ReadLine();
                            bool IsAlcoholic = (isAlcoholicInput == "1");
                            try
                            {
                                restuarantService.AddDrink(restaurantId,nameDrink, priceDrink, IsAlcoholic);
                                Console.WriteLine($"{nameDrink} added successfully.");
                            }
                            catch (FoodAlreadyExistException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case FoodCategoryEnum.Dessert:
                            ShowListRestuarant();
                            Console.WriteLine("please enter restaurantID");
                             restaurantId = int.Parse(Console.ReadLine());
                            Console.WriteLine("please enter nameFood");
                            string nameDesert = Console.ReadLine();
                            Console.WriteLine("please enter price");
                            decimal priceDesert = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("isVegetarian : 1.true or 2.false");
                            string isContainsNutsInput = Console.ReadLine();
                            bool IsContainsNuts = (isContainsNutsInput == "1");
                            try
                            {
                                restuarantService.AddDessert(restaurantId,nameDesert, priceDesert, IsContainsNuts);
                                Console.WriteLine($"{nameDesert} added successfully.");
                            }
                            catch (FoodAlreadyExistException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;


                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("invalid category  , Please select an option from the menu provided.");
                }

                break;
            case 2:
                Console.WriteLine("please enter name");
                string nameCustomer = Console.ReadLine();
                Console.WriteLine("please enter phone");
                string phone = Console.ReadLine();
                Console.WriteLine("please enter address");
                string address = Console.ReadLine();
                try
                {
                    restuarantService.RegisterCustomer(nameCustomer, phone, address);
                    Console.WriteLine("RegisterCustomer is done");
                }
                catch (CustomerAlreadyExistException e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            case 3:
                Console.WriteLine("please enter your Id");
                try
                {
                    CustomerIdAndFoodIdsAndRestaurantId customerIdAndFoodIds = RegisterFoods();
                    if (customerIdAndFoodIds != null) 
                    {
                        restuarantService.AddOrder(customerIdAndFoodIds.CustomerId, customerIdAndFoodIds.RestaurantId, customerIdAndFoodIds.FoodIds);
                        Console.WriteLine("add order is done");
                    }
                                   
                }
                catch (CustomerNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e) 
                {
                    Console.WriteLine("invalid format for customerId ");
                }
                break;

        }
    }
    catch (FormatException)
    {
        Console.WriteLine("invalid option , Please select an option from the menu provided.");
    }

}
void ShowMenu()
{
    Console.WriteLine("please enter option");
    Console.WriteLine("1.AddFood");
    Console.WriteLine("2.Register Customer");
    Console.WriteLine("3.Add Order");

}
void ShowCategory()
{
    Console.WriteLine("Please select the desired option.");
    Console.WriteLine("1.MainCourse");
    Console.WriteLine("2.Dessert");
    Console.WriteLine("3.Drink");
}
void ShowListRestuarant() 
{
    List<Restaurant> restaurants=restuarantService.GetRestaurants();
    foreach (var restaurant in restaurants)
    {
        Console.WriteLine($"Id:{restaurant.Id} , name:{restaurant.Name} , ");
    }
}


CustomerIdAndFoodIdsAndRestaurantId RegisterFoods()
{
    Console.WriteLine("Please enter your customer ID:");
    int customerId = int.Parse(Console.ReadLine());

    ShowListRestuarant();

    Console.WriteLine("Please enter the ID of the desired restaurant.");
    int restaurantId; 
    try
    {
        restaurantId = int.Parse(Console.ReadLine()); 
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid RestaurantID. The process is cancelled.");
        return null;

    }

    List<int> foodIds = new List<int>();
    bool exit = false;
    while (!exit)
    {
       
        ShowMenuFood(restaurantId); 
        int foodId = int.Parse(Console.ReadLine());
        foodIds.Add(foodId);

        Console.WriteLine("Enter 100 to exit or enter another number to continue.");
        string exitFromMenu = Console.ReadLine();
        if (exitFromMenu == "100")
        {
            exit = true;
        }
    }

    CustomerIdAndFoodIdsAndRestaurantId customerIdAndFoodIds = new CustomerIdAndFoodIdsAndRestaurantId
    {
        CustomerId = customerId,
        FoodIds = foodIds,
        RestaurantId = restaurantId
    };
    return customerIdAndFoodIds;
}

void ShowMenuFood(int restaurantId)
{
    Console.WriteLine($"--- Menu for Restaurant ID: {restaurantId} ---");
    List<Food> foods = restuarantService.MenuByRestaurantId(restaurantId);
    foreach (var food in foods)
    {
        Console.WriteLine($"Food ID: {food.Id}, Name: {food.Name}, Price: {food.Price}");
    }
    Console.WriteLine("Select the food ID you want.");
}