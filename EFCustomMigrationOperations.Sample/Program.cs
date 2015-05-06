using System;
using System.Linq;
using EFCustomMigrationOperations.Sample.Model;

namespace EFCustomMigrationOperations.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductContext())
            {
                var allProduct = context.Products.ToList();
                allProduct.ForEach(p => Console.WriteLine(p.SKU));
            }

            Console.ReadKey();
        }
    }
}
