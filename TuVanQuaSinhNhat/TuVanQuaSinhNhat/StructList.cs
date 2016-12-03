using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuVanQuaSinhNhat
{
    public struct ProductList
    {
        public int rating { get; set; }
        public Product p { get; set; }

        public ProductList(int p1, Product p2) : this()
        {
            rating = p1;
            p = p2;
        }
    }
}
