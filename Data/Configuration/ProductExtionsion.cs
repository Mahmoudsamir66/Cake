using Cake.Models;
using Microsoft.EntityFrameworkCore;

namespace Cake.Data.Configuration
{
    public  static class ProductExtionsion
    {  
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            Product[] products = {
            new Product
            {
                id = 1,
                name="cake",
                description="very good",
                image="cake.jpg",
                price=100

            },
            new Product
            {
                id = 2,
                name="baker",
                description="very simple",
                image="baker.jpg",
                price=10

            } ,
            new Product
            {
                id = 3,
                name="baker",
                description="very simple",
                image="baker.jpg",
                price=122

            },
            new Product
            {
                id = 4,
                name="baker",
                description="very simple",
                image="a.jpg",
                price=50

            },
            new Product
            {
                id = 5,
                name="baker",
                description="very simple",
                image="b.jpg",
                price=60

            },
            new Product
            {
                id = 6,
                name="baker",
                description="very simple",
                image="c.jpg",
                price=1000

            },
            new Product
            {
                id = 7,
                name="baker",
                description="very simple",
                image="d.jpg",
                price=105

            }


            };

            modelBuilder.Entity<Product>().HasData(products);
            return modelBuilder;
            
        }
      
      
    }
}
