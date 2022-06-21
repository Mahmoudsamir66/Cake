
using Cake.Data;
using Cake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Database _db;
        public IndexModel(Database _db)
        {
            this._db = _db;

        }
        public List<Product> products { get; set; }=new List<Product>();
        public Product productFeatured { get; set; }


        public async Task OnGetAsync()
        {
            products = await _db.Products.ToListAsync();
            productFeatured=products.ElementAt(new Random().Next(products.Count));
        }
    }
}
