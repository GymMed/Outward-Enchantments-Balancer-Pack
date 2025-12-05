using OutwardEnchantmentsBalancerPack.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Helpers
{
    public static class MerchantHelpers
    {
        public static bool TryMoveItemsToContainer(ItemContainer container, List<Item> items)
        {
            float totalWeight = 0f;
            foreach(Item item in items)
            {
                totalWeight += item.Weight;
            }

            return container.TryMoveItemsToContainer(items, totalWeight, true);
        }

        public static void AddContainedContainerItems(ItemContainer container, List<Item> items)
        {
            string key = "";
            foreach(Item item in items)
            {
                key = item.UID.ToString();

                if(!container.m_containedItems.ContainsKey(key))
                    container.m_containedItems.Add(key, item);
            }
            AddItemsToContainer(container, items);
        }

        public static void AddItemsToContainer(ItemContainer container, List<Item> items)
        {
            foreach (var item in items)
            {
                container.AddItem(item);
            }
        }

        public static List<int> GetRandomIncensesIds(int randomAmount = 3)
        {
            List<int> ids = IncensesTypesHelper.IncensesIds.Values.ToList();
            int incenseIndex = 0;
            List<int> finalIncensesIds = new();

            for (int currentIncense = 0; currentIncense < randomAmount; currentIncense++)
            {
                incenseIndex = UnityEngine.Random.Range(0, ids.Count);
                finalIncensesIds.Add(ids[incenseIndex]);
                ids.RemoveAt(incenseIndex);
            }

            return finalIncensesIds;
        }

        public static List<Item> GenerateItemsByIds(List<int> ids, int minItems = 1, int maxItems = 1)
        {
            var items = new List<Item>();
            Item item = null;
            int randomItemCount = 1;
            int currentItem = 0;

            foreach (var id in ids)
            {
                randomItemCount = UnityEngine.Random.Range(minItems, maxItems);

                for (currentItem = 0; currentItem < randomItemCount; currentItem++)
                {
                    item = ItemManager.Instance.GenerateItemNetwork(id);

                    if (item == null)
                        continue;

                    items.Add(item);
                }
            }

            return items;
        }
    }
}
