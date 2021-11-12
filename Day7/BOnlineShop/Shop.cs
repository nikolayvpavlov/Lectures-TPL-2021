using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOnlineShop
{
    internal class Shop
    {
        private object myLock = new object();

        private List<string> products;
        private Dictionary<string, int> stock;

        public Shop()
        {
            products = new List<string>();
            stock = new Dictionary<string, int>();
        }

        public void Supply(string product, int quantity)
        {
            lock (myLock)
            {
                stock[product] = stock[product] + quantity;
            }
        }

        public void Purchase(string product, int quantity)
        {
            lock (myLock)
            {
                if (stock.ContainsKey(product))
                {
                    stock[product] = stock[product] - quantity;
                }
                else
                    throw new Exception("Insufficient quantity available");
            }
        }
    }
}
