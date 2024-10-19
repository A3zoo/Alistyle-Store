using MauDoan.Context;
using System.Collections.Generic;

namespace MauDoan.Controllers
{
    internal class Product_Category
    {
        public List<Category> ListCategory { get; internal set; }
        public List<Product> ListProduct { get; internal set; }
    }
}