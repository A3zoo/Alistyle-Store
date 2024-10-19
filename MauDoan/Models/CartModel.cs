using MauDoan.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauDoan.Models
{
    public class CartModel
    {
        public Product Product { get; set; }

        public int quantity { get; set; }
    }
}