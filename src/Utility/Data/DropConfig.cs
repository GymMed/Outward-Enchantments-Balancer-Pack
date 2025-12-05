using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Data
{
    public struct DropConfig
    {
        public int DropChance;
        public int MinCount;
        public int MaxCount;
        public int MinDice;
        public int MaxDice;

        public DropConfig(
            int dropChance = 10,
            int minCount = 1,
            int maxCount = 2,
            int minDice = 0,
            int maxDice = 0)
        {
            DropChance = dropChance;
            MinCount = minCount;
            MaxCount = maxCount;
            MinDice = minDice;
            MaxDice = maxDice;
        }
    }
}
