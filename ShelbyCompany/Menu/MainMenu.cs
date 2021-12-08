using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyCompany.Menu
{
    public class MainMenu
    {
        public MainMenu()
        {

        }

        public void Login()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            if (Environment.UserLogin.TryLogin(username, password))
            {
                Console.WriteLine("You're now logged in.");
                Console.Clear();
                this.DisplayCategories();
            }
            else
            {
                Console.WriteLine("Incorrect login details. Please try again.");
                this.Login();
            }
        }

        public void DisplayCategories()
        {
            foreach (var category in Environment.ShelbyCompanyContext.Categories)
            {
                Console.WriteLine("Categories");
                Console.WriteLine("Id: " + category.Id + ", Name: " + category.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Choose a category by id:");
            string categoryInput = Console.ReadLine();
            int categoryId;
            if (int.TryParse(categoryInput, out categoryId))
            {
                Console.Clear();
                this.DisplayCategoryItems(categoryId);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong INT format. Please try again!");
                Console.WriteLine();
                this.DisplayCategories();
            }
        }

        public bool IsUserLoggedIn()
        {
            return Environment.UserLogin.LoggedIn ? true : false;
        }


        public void DisplayCategoryItems(int categoryId)
        {
            var category = Environment.ShelbyCompanyContext.Categories.SingleOrDefault(cat => cat.Id == categoryId);

            if (category == null)
            {
                Console.Clear();
                Console.WriteLine("Category Id invalid. Please try again");
                this.DisplayCategories();
                return;
            }

            foreach (var item in Environment.ShelbyCompanyContext.Products)
            {
                if (item.CategoryId != category.Id)
                {
                    continue;
                }

                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Price: ", item.Price + ", Quantity: " + item.Quantity);
            }

            Console.WriteLine("Choose a item by id:");
            string itemIdInput = Console.ReadLine();
            if (int.TryParse(itemIdInput, out int itemId))
            {
                this.Order(itemId);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong INT format. Please try again!");
                Console.WriteLine();
                this.DisplayCategoryItems(categoryId);
            }
        }

        public void Order(int itemId)
        {
            var item = Environment.ShelbyCompanyContext.Products.SingleOrDefault(it => it.Id == itemId);
            Console.Clear();

            if (item == null)
            {
                Console.WriteLine("Invalid Item Id.");
                this.DisplayCategories();

                return;
            }

            Console.WriteLine("Would you like to order the following item:");
            Console.WriteLine(item.Name);
            Console.WriteLine();
            Console.WriteLine("Y/N: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.Clear();
                Console.WriteLine("Order Confirmation");
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Price: " + item.Price);
                Console.WriteLine();
                Console.WriteLine("Press any key to return to categories.");
                Console.ReadKey();
                Console.Clear();
                this.DisplayCategories();
            }
            else
            {
                Console.Clear();
                this.DisplayCategories();
            }
        }
    }
}