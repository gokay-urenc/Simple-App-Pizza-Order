using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUygulama
{
   public class Pizza:Base
    {
        public decimal Fiyati { get; set; }
        public override string ToString()
        {
            return Adi;
        }
    }
}
