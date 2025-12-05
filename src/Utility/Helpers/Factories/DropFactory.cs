using OutwardEnchantmentsBalancerPack.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Helpers.Factories
{
    public static class DropFactory
    {
        public static List<ItemDropChance> GetEnchantmentIngrediantsDrops(
            DropConfig tourmalineConfig = default, 
            DropConfig quartzConfig = default, 
            DropConfig rootConfig = default
        )
        {
            if (tourmalineConfig.Equals(default))
                tourmalineConfig = new DropConfig();

            if (quartzConfig.Equals(default))
                quartzConfig = new DropConfig();

            if (rootConfig.Equals(default))
                rootConfig = new DropConfig(0);

            List<ItemDropChance> items = new List<ItemDropChance>();

            if(tourmalineConfig.DropChance > 0)
                items.Add(GetTourmalineDrop(
                    tourmalineConfig.DropChance,
                    tourmalineConfig.MinCount,
                    tourmalineConfig.MaxCount,
                    tourmalineConfig.MinDice,
                    tourmalineConfig.MaxDice
                ));

            if(quartzConfig.DropChance > 0)
                items.Add(GetPurifyingQuartzDrop(
                    quartzConfig.DropChance,
                    quartzConfig.MinCount,
                    quartzConfig.MaxCount,
                    quartzConfig.MinDice,
                    quartzConfig.MaxDice
                ));

            if(rootConfig.DropChance > 0)
                items.Add(GetDreamersRootDrop(
                    rootConfig.DropChance,
                    rootConfig.MinCount,
                    rootConfig.MaxCount,
                    rootConfig.MinDice,
                    rootConfig.MaxDice
                ));

            return items;
        }

        public static ItemDropChance GetTourmalineDrop(DropConfig config = default)
        {
            if (config.Equals(default))
                config = new DropConfig();

            return GetTourmalineDrop(
                config.DropChance,
                config.MinCount,
                config.MaxCount,
                config.MinDice,
                config.MaxDice
            );
        }

        public static ItemDropChance GetPurifyingQuartzDrop(DropConfig config = default)
        {
            if (config.Equals(default))
                config = new DropConfig();

            return GetPurifyingQuartzDrop(
                config.DropChance,
                config.MinCount,
                config.MaxCount,
                config.MinDice,
                config.MaxDice
            );
        }

        public static ItemDropChance GetRootDrop(DropConfig config = default)
        {
            if (config.Equals(default))
                config = new DropConfig();

            return GetDreamersRootDrop(
                config.DropChance,
                config.MinCount,
                config.MaxCount,
                config.MinDice,
                config.MaxDice
            );
        }

        public static ItemDropChance GetTourmalineDrop(
            int dropChance = 10,
            int minDropCount = 1,
            int maxDropCount = 2,
            int minDiceRoll = 0,
            int maxDiceRoll = 0)
        {
            return CreateItemDropChance(
                6200170,
                dropChance,
                minDropCount,
                maxDropCount,
                minDiceRoll,
                maxDiceRoll
            );
        }

        public static ItemDropChance GetPurifyingQuartzDrop(
            int dropChance = 10,
            int minDropCount = 1,
            int maxDropCount = 2,
            int minDiceRoll = 0,
            int maxDiceRoll = 0)
        {
            return CreateItemDropChance(
                6000170,
                dropChance,
                minDropCount,
                maxDropCount,
                minDiceRoll,
                maxDiceRoll
            );
        }

        public static ItemDropChance GetDreamersRootDrop(
            int dropChance = 10,
            int minDropCount = 1,
            int maxDropCount = 2,
            int minDiceRoll = 0,
            int maxDiceRoll = 0)
        {
            return CreateItemDropChance(
                4000360, 
                dropChance, 
                minDropCount, 
                maxDropCount, 
                minDiceRoll, 
                maxDiceRoll
           );
        }

        public static List<ItemDropChance> CombineDrops(params ItemDropChance[] drops)
        {
            return new List<ItemDropChance>(drops);
        }

        public static List<ItemDropChance> CombineDrops(params List<ItemDropChance>[] dropLists)
        {
            var result = new List<ItemDropChance>();
            foreach (var list in dropLists)
            {
                result.AddRange(list);
            }
            return result;
        }

        private static ItemDropChance CreateItemDropChance(
            int itemId,
            int dropChance,
            int minDropCount,
            int maxDropCount,
            int minDiceRoll,
            int maxDiceRoll)
        {
            return new ItemDropChance
            {
                ItemID = itemId,
                DropChance = dropChance,
                MinDropCount = minDropCount,
                MaxDropCount = maxDropCount,
                MinDiceRollValue = minDiceRoll,
                MaxDiceRollValue = maxDiceRoll
            };
        }
    }
}
