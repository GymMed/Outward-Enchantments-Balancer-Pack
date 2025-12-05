using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Enums
{
    public enum EnchantmentEssentials
    {
        Table,
        Pillar,
    }

    public static class EnchantmentEssiantialsHelper
    {
        public static readonly Dictionary<EnchantmentEssentials, int> essentialsIds = new()
        {
            { EnchantmentEssentials.Table, 5000200 },
            { EnchantmentEssentials.Pillar, 5000203 }
        };
    }
}
