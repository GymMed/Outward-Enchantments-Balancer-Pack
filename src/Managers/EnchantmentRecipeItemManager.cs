using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Managers
{
    public class EnchantmentRecipeItemManager
    {
        private static EnchantmentRecipeItemManager _instance;

        private EnchantmentRecipeItemManager()
        {
            MakeEnchantmentDictionary();
        }

        public static EnchantmentRecipeItemManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EnchantmentRecipeItemManager();

                return _instance;
            }
        }

        Dictionary<int, int> enchantmentToEnchantmentRecipeItems = new Dictionary<int, int>();

        public Dictionary<int, int> EnchantmentToEnchantmentRecipeItems { get => enchantmentToEnchantmentRecipeItems; set => enchantmentToEnchantmentRecipeItems = value; }

        public void MakeEnchantmentDictionary()
        {
            EnchantmentToEnchantmentRecipeItems.Clear();

            foreach(KeyValuePair<string, Item> itemPrefab in ResourcesPrefabManager.ITEM_PREFABS)
            {
                if(itemPrefab.Value is EnchantmentRecipeItem enchantmentItem)
                {
                    if (enchantmentItem.Recipes.Length < 1)
                        continue;

                    Enchantment enchantment = ResourcesPrefabManager.Instance.GetEnchantmentPrefab(enchantmentItem.Recipes[0].RecipeID);

                    if (enchantment == null)
                        continue;

                    // It seems Recipes are Item class prefabs and we don't need duplicates in mapping
                    if (EnchantmentToEnchantmentRecipeItems.TryGetValue(enchantment.PresetID, out int enchantmentItemId))
                        continue;

                    EnchantmentToEnchantmentRecipeItems.Add(enchantment.PresetID, enchantmentItem.ItemID);
                }
            }
        }

        public List<EnchantmentRecipeItem> GetAllEnchantmentItems()
        {
            List<EnchantmentRecipeItem> items = new List<EnchantmentRecipeItem>();

            foreach(KeyValuePair<int, int> enchantmentConnection in EnchantmentToEnchantmentRecipeItems)
            {
                items.Add(GetEnchantmentRecipeItemFromEnchantment(enchantmentConnection.Key));
            }

            return items;
        }

        public List<ItemDropChance> GetAllEnchantmentItemsAsDropChances()
        {
            List<ItemDropChance> items = new List<ItemDropChance>();

            foreach(KeyValuePair<int, int> enchantmentConnection in EnchantmentToEnchantmentRecipeItems)
            {
                ItemDropChance dropChance = new ItemDropChance();
                dropChance.ItemID = enchantmentConnection.Value;
                //dropChance.MinDropCount = 1;
                //dropChance.MaxDropCount = 1;

                items.Add(dropChance);
            }

            return items;
        }

        public Enchantment GetEnchantmentFromEnchantmentRecipeItem(EnchantmentRecipeItem item)
        {
            if (item == null || item.Recipes.Length < 1)
                return null;

            return ResourcesPrefabManager.Instance.GetEnchantmentPrefab(item.Recipes[0].ResultID);
        }

        public Enchantment GetEnchantmentFromEnchantmentRecipeItem(int itemId)
        {
            EnchantmentRecipeItem item = ResourcesPrefabManager.Instance.GetItemPrefab(itemId) as EnchantmentRecipeItem;

            return GetEnchantmentFromEnchantmentRecipeItem(item);
        }

        public EnchantmentRecipeItem GetEnchantmentRecipeItemFromEnchantment(Enchantment enchantment)
        {
            return GetEnchantmentRecipeItemFromEnchantment(enchantment.PresetID);
        }

        public EnchantmentRecipeItem GetEnchantmentRecipeItemFromEnchantment(int enchantmentId)
        {
            Enchantment enchantmentPrefab = ResourcesPrefabManager.Instance.GetEnchantmentPrefab(enchantmentId);

            if (enchantmentPrefab == null)
                return null;

            if (!EnchantmentToEnchantmentRecipeItems.TryGetValue(enchantmentPrefab.PresetID, out int enchantmentItemId))
                return null;

            return ResourcesPrefabManager.Instance.GetItemPrefab(enchantmentItemId) as EnchantmentRecipeItem;
        }
    }
}
