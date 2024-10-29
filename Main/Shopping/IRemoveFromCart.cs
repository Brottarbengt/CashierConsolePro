using Kassan.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Shopping
{
    internal interface IRemoveFromCart
    {
        void RemoveFromCart(CartItem product); 
    }
}
