using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOnlineShop
{
    internal class Buyer
    {
        Shop shop;

        public Buyer(Shop shop)
        {
            this.shop = shop;
        }

        //This is a stub, i.e. it has no actual implementation.  Just for illustration.
        public void Behave()
        {
            //This method will call our DoBuy.
        }

        private void DoBuy(string product, int quantity)
        {
            shop.Purchase(product, quantity);
        }
    }
}
