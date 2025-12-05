using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Enums
{
    public enum EnchantmentIngrediants
    {
        Tourmaline,
        PurifyingQuartz,
        DreamersRoot,
    }

    public static class EnchantmentIngrediantsHelper
    {
        public static readonly Dictionary<EnchantmentIngrediants, int> ItemsIds = new()
        {
            // buy and sell 60
            { EnchantmentIngrediants.Tourmaline, 6200170 },
            // buy 30 sell 9
            { EnchantmentIngrediants.PurifyingQuartz, 6000170 },
            // buy 3 sell 1
            { EnchantmentIngrediants.DreamersRoot, 4000360 },
        };

        public static readonly Dictionary<EnchantmentIngrediants, int> NewSellPrices = new()
        {
            { EnchantmentIngrediants.Tourmaline, 20 },
            { EnchantmentIngrediants.PurifyingQuartz, 5 },
            { EnchantmentIngrediants.DreamersRoot, 1 },
        };

        public static int GetItemPrice(EnchantmentIngrediants ingrediant)
        {
            if (NewSellPrices.TryGetValue(ingrediant, out int id))
                return id;

            return 0;
        }

        public static int GetItemId(EnchantmentIngrediants ingrediant)
        {
            if (ItemsIds.TryGetValue(ingrediant, out int id))
                return id;

            return 0;
        }
    }
}
