using HWW8WithEF.Entities;
using HWW8WithEF.Enums;
using HWW8WithEF.Exceptions;
using HWW8WithEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWW8WithEF.Services
{
    public class RestuarantService
    {
        Repository repository = new Repository();
        CustomerRepository customerRepository = new CustomerRepository();
        OrderRepository orderRepository = new OrderRepository();
        RestaurantRepository restaurantRepository = new RestaurantRepository();

        public void AddDrink(int restaurantId ,string name , decimal Price , bool isAlcoholic) 
        {
            Food? food=repository.GetFoodByName(name);
            if (food!=null)
            {
                throw new FoodAlreadyExistException("This food has already been added.");
            }
            var drink = new Drink
            {
                Price = Price ,
                Name = name ,
                IsAlcoholic = isAlcoholic,
                Category = FoodCategoryEnum.Drink,
                RestaurantId = restaurantId
            };
            repository.AddFood(drink);
        }

        public void AddDessert(int restaurantId, string name, decimal Price, bool containsNuts) 
        {
            Food? food = repository.GetFoodByName(name);
            if (food != null)
            {
                throw new FoodAlreadyExistException("This food has already been added.");
            }
            var desert = new Dessert
            {
                  Name = name ,
                  Price = Price ,
                  ContainsNuts=containsNuts,
                  Category= FoodCategoryEnum.Dessert,
                  RestaurantId=restaurantId
            };
            repository.AddFood(desert);
        }

        public void AddMainCourse(int restaurantId, string name, decimal Price, bool isVegetarian) 
        {
            Food? food = repository.GetFoodByName(name);
            if (food != null)
            {
                throw new FoodAlreadyExistException("This food has already been added.");
            }
            var mainCourse = new MainCourse
            {
                Name = name ,
                Price = Price ,
                IsVegetarian = isVegetarian,
                Category= FoodCategoryEnum.MainCourse,
                RestaurantId=restaurantId
            };
            repository.AddFood(mainCourse);
        }

        public void RegisterCustomer(string name , string phone , string address) 
        {
           Customer? customer=customerRepository.GetCustomerByPhone(phone);
            if (customer!=null)
            {
                throw new CustomerAlreadyExistException("A customer with this mobile number has already been registered.");
            }
            ContactInfo contactInfo = new ContactInfo 
            {
               Phone = phone ,
               Address = address 
            };
            Customer customer1 = new Customer
            {
              Name = name ,
              Contact= contactInfo
            };
            customerRepository.AddCustomer(customer1);
        }

        public void AddOrder(int customerId, int restaurantId, List<int> foodIds)
        {          
            Customer? customer = customerRepository.GetCustomerByCustomerId(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer with this ID does not exist.");
            }
           
            List<Food> foods = repository.GetFoodsByIds(foodIds);           
            decimal initialPrice = foods.Sum(f => f.Price);
            decimal finalPrice = initialPrice;        
            if (initialPrice > 100000) 
            {
                decimal discountAmount = initialPrice * 0.10m; 
                finalPrice = initialPrice - discountAmount;
                Console.WriteLine($"A 10% discount has been applied! Original price: {initialPrice}, New price: {finalPrice}");
            }           
            var order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                Status = OrderStatusEnum.Pending,
                Foods = foods,
                TotalPrice = finalPrice 
                ,RestaurantId = restaurantId
            };         
            orderRepository.AddOrder(order);
        }

        public List<Food> GetFoods() 
        {
          return repository.GetFoods();
        }

        public void AddRestaurant(string name , string address , List<Food> menu) 
        {

            Restaurant restaurant = new Restaurant 
            {
              Name= name ,
              Address= address ,
              Menu= menu
            };
            restaurantRepository.AddRestaurant(restaurant);
        }

        public List<Restaurant> GetRestaurants() 
        {
          return restaurantRepository.GetRestaurants();
        }
        public List<Food> MenuByRestaurantId(int restaurantId)
        {

            return repository.MenuByRestaurantId(restaurantId);
        }
    }
}
