using OutwardEnchantmentsBalancerPack.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutwardEnchantmentsBalancerPack.Utility.Helpers
{
    public static class ItemDropChanceHelpers
    {
        // based on emptyDropChance percentage distributes the weights
        // original system works based on weights and not percentages,
        // which is harder to calculate in head and will lead to mistakes
        public static DropChancesDistributedData DistributeEquallyItemDropChancesWeights(List<ItemDropChance> items, int emptyDropChance = 0)
        {
            if (items == null || items.Count == 0)
                return new DropChancesDistributedData();

            emptyDropChance = Mathf.Clamp(emptyDropChance, 0, 100);
            int remainingPercent = 100 - emptyDropChance;
            int emptyWeight = emptyDropChance * items.Count;
            int eachItemWeight = remainingPercent;

            foreach (var item in items)
            {
                item.DropChance = eachItemWeight;
            }

            return new DropChancesDistributedData(emptyWeight, items.Count);
        }

        // based on emptyDropChance and respectItemChances percentages distributes the weights
        public static DropChancesDistributedData DistributeEquallyItemDropChancesWeights(List<ItemDropChance> respectItemsChances, List<ItemDropChance> distributeItemsChances, int emptyDropChance = 0)
        {
            if (respectItemsChances == null) respectItemsChances = new();
            if (distributeItemsChances == null) distributeItemsChances = new();
            if (respectItemsChances.Count == 0 && distributeItemsChances.Count == 0)
                return new DropChancesDistributedData();

            emptyDropChance = Mathf.Clamp(emptyDropChance, 0, 100);

            // 1️ Sum up total percent used by respect list
            float respectTotalPercent = respectItemsChances.Sum(i => Mathf.Max(0, i.DropChance));

            // 2️ Calculate leftover percent
            float remainingPercent = Mathf.Max(0, 100 - emptyDropChance - respectTotalPercent);

            // Scale down if "respect" items + empty exceeds 100%
            if (remainingPercent < 0f && respectTotalPercent > 0f)
            {
                float scale = (100f - emptyDropChance) / respectTotalPercent;
                foreach (var item in respectItemsChances)
                {
                    item.DropChance = Mathf.RoundToInt(item.DropChance * scale);
                }

                respectTotalPercent = respectItemsChances.Sum(i => i.DropChance);
                remainingPercent = Mathf.Max(0f, 100f - emptyDropChance - respectTotalPercent);
            }

            // 3️ Handle scaling base (convert percents to integer weights)
            // To preserve proportions, we can scale by total item count (A + B)
            int totalItems = respectItemsChances.Count + distributeItemsChances.Count;
            if (totalItems == 0) return new DropChancesDistributedData();

            int emptyWeight = Mathf.RoundToInt(emptyDropChance * totalItems);

            // 4️ Respect items keep their proportional DropChance as weights
            foreach (var item in respectItemsChances)
            {
                item.DropChance *= totalItems; // scale up
#if DEBUG
                OEBP.LogMessage($"[OEBP] respect: {item.DropChance}");
#endif
            }

            // 5 Distribute remaining percent equally among B list
            float eachItemPercent = distributeItemsChances.Count > 0
                ? remainingPercent / distributeItemsChances.Count
                : 0f;
#if DEBUG
            OEBP.LogMessage($"[OEBP] each item percent: {eachItemPercent}");
#endif

            int eachItemWeight = Mathf.RoundToInt(eachItemPercent * totalItems);
#if DEBUG
            OEBP.LogMessage($"[OEBP] each item weight: {eachItemWeight}");
#endif

            foreach (var item in distributeItemsChances)
            {
                item.DropChance = eachItemWeight;
            }

#if DEBUG
            OEBP.LogMessage($"[OEBP] empty weight: {emptyWeight}");
            OEBP.LogMessage($"[OEBP] max dice: {totalItems * 100}");
#endif
            return new DropChancesDistributedData(emptyWeight, totalItems);
        }

        public static List<ItemDropChance> CopyItemDropChances(List<ItemDropChance> original)
        {
            if (original == null) return new List<ItemDropChance>();
            return original.Select(i => CopyItemDropChance(i)).ToList();
        }

        public static ItemDropChance CopyItemDropChance(ItemDropChance original)
        {
            return new ItemDropChance
            {
                ItemID = original.ItemID,
                DropChance = original.DropChance,
                MaxDropCount = original.MaxDropCount,
                MinDropCount = original.MinDropCount,
                MaxDiceRollValue = original.MaxDiceRollValue,
                MinDiceRollValue = original.MinDiceRollValue
            };
        }
    }
}
