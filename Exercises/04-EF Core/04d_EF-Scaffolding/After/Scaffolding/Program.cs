using System;
using System.Linq;
using Scaffolding.Models;

namespace Scaffolding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Enter for Customers");
            Console.ReadLine();

            using(var context = new NorthwindSlimContext())
            {
                var customers = context.Customer.OrderBy(c => c.CompanyName).ToList();
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.CompanyName} {c.City}");
                }
            }
        }
    }
}
