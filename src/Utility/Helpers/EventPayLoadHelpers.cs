using OutwardEnchantmentsBalancerPack.Utility.Data;
using OutwardEnchantmentsBalancerPack.Utility.Enums;
using OutwardModsCommunicator.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Helpers
{
    public static class EventPayLoadHelpers
    {
        public static void AssignDistributedDataToPayLoad(EventPayload payload, DropChancesDistributedData data)
        {
            payload.Set(LootManagerParamsHelper.Get(LootManagerParams.EmptyDropChance).key, data.EmptyDropChance);
            payload.Set(LootManagerParamsHelper.Get(LootManagerParams.MaxDiceValue).key, data.GetMaxDiceValue());
        }

        public static void AssignDistributedDataToPayLoad(EventPayload payload, DropChancesDistributedData data, List<ItemDropChance> items)
        {
            AssignDistributedDataToPayLoad(payload, data);
            payload.Set(LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key, items);
        }

        public static void SetDistributedEnchantmentsToPayload(EventPayload payload, List<ItemDropChance> items, List<ItemDropChance> enchantments, int emptyDropChance = 0)
        {
            List<ItemDropChance> enchantmentsCopy = ItemDropChanceHelpers.CopyItemDropChances(enchantments);
            GetAndSetDistributedDataToPayload(payload, items, enchantmentsCopy, emptyDropChance);
        }

        public static void GetAndSetDistributedDataToPayload(EventPayload payload, List<ItemDropChance> items, List<ItemDropChance> distributionItems, int emptyDropChance = 0)
        {
            try
            {
                List<ItemDropChance> allItems = new List<ItemDropChance>();

                DropChancesDistributedData distributedData = ItemDropChanceHelpers.DistributeEquallyItemDropChancesWeights(items, distributionItems, emptyDropChance);
                allItems.AddRange(items);
                allItems.AddRange(distributionItems);

                AssignDistributedDataToPayLoad(payload, distributedData, allItems);
            }
            catch(Exception e)
            {
                OEBP.LogMessage($"OutwardEnchantmentsBalancerPack@PublishLoot we encountered an errpr: \"{e.Message}\"");
            }
        }

        public static void GetAndSetDistributedDataToPayload(EventPayload payload, ItemDropChance item, List<ItemDropChance> enchantments, int emptyDropChance = 0)
        {
            List<ItemDropChance> items = new List<ItemDropChance>(item);

            GetAndSetDistributedDataToPayload(payload, items, enchantments, emptyDropChance);
        }

        public static void GetAndSetDistributedEnchantmentsDataToPayload(EventPayload payload, ItemDropChance item, List<ItemDropChance> enchantments, int emptyDropChance = 0)
        {
            List<ItemDropChance> items = new List<ItemDropChance>(item);

            SetDistributedEnchantmentsToPayload(payload, items, enchantments, emptyDropChance);
        }
    }
}
