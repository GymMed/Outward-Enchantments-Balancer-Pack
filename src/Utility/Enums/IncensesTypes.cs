using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Enums
{
    public enum IncensesTypes
    {
        //base
        Monarch,
        Cecropia,
        Admiral,
        Chrysalis,
        PaleBeauty,

        // advanced
        Apollo,
        Comet,
        Luna,
        Morpho,
        Sylphina 
    }

    public static class IncensesTypesHelper
    {
        public static readonly Dictionary<IncensesTypes, int> IncensesIds = new()
        {
            // base
            // sell 75 silver
            // buy 250 silver
            { IncensesTypes.Monarch, 6000200 },
            { IncensesTypes.Cecropia, 6000270 },
            { IncensesTypes.Admiral, 6000190 },
            { IncensesTypes.Chrysalis, 6000220 },
            { IncensesTypes.PaleBeauty, 6000210 },

            // advanced
            // sell 180 silver
            // buy 600 silver
            { IncensesTypes.Apollo, 6000180 },
            { IncensesTypes.Comet, 6000260 },
            { IncensesTypes.Luna, 6000230 },
            { IncensesTypes.Morpho, 6000240 },
            { IncensesTypes.Sylphina, 6000250 },

        };

        // 33%
        public static int BaseIncesesSellPrice = 25;
        public static int AdvancedIncesesSellPrice = 60;

        public static IncensesTypes[] GetBaseInceses()
        {
            return new IncensesTypes[]
            {
                IncensesTypes.Monarch,
                IncensesTypes.Cecropia,
                IncensesTypes.Admiral,
                IncensesTypes.Chrysalis,
                IncensesTypes.PaleBeauty,
            };
        }

        public static IncensesTypes[] GetAdvancedInceses()
        {
            return new IncensesTypes[]
            {
                IncensesTypes.Apollo,
                IncensesTypes.Comet,
                IncensesTypes.Luna,
                IncensesTypes.Morpho,
                IncensesTypes.Sylphina 
            };
        }

        public static int GetIncenseId(IncensesTypes type)
        {
            if (IncensesIds.TryGetValue(type, out int id))
                return id;

            return 0;
        }
    }
}
