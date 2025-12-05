using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Data
{
    public class DropChancesDistributedData
    {
        private int emptyDropChance = 0;
        private int weightPerPercentage = 0;

        public DropChancesDistributedData(int emptyDropChance = 0, int weightPerPercentage = 0)
        {
            this.EmptyDropChance = emptyDropChance;
            this.WeightPerPercentage = weightPerPercentage;
        }

        public int WeightPerPercentage { get => weightPerPercentage; set => weightPerPercentage = value; }
        public int EmptyDropChance { get => emptyDropChance; set => emptyDropChance = value; }

        public int GetMaxDiceValue()
        {
            return WeightPerPercentage * 100;
        }
    }
}
