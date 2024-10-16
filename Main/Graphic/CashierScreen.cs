using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassan.Graphic
{
    public static class CashierScreen
    {
        static char colouredSelectorTop = '*';
        static char colouredSelectorMiddle = '*';
        static char colouredSelectorBottom = '*';

        static string adminTools = "Admin Tools";
        static string manageProducts = "New shopping cart";
        static string addRemoveCampaigns = "Exit";
        
        public static string cashierUI = $@"
        
        {colouredSelectorTop} {adminTools} {colouredSelectorTop}

        {colouredSelectorMiddle} {manageProducts} {colouredSelectorMiddle}

        {colouredSelectorBottom} {addRemoveCampaigns} {colouredSelectorBottom}
";
    }
}
