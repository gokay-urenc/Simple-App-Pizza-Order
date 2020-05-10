using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUygulama
{
    public class Ebat:Base
    {
        public decimal FiyatCarpani { get; set; }
        public override string ToString()
        {
            return Adi;
        }
    }
}
