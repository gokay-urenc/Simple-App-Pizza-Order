using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUygulama
{
    public class Siparisler
    {
        public int Adet { get; set; }
        public Pizza SepettekiPizza { get; set; }
        public Ebat SepettekiEbat { get; set; }
        public string KenarTercihi { get; set; }
        public List<string> SepettekiMalzemeler { get; set; }
        public decimal SiparisTutari { get; set; }
    }
}