using OutwardEnchantmentsBalancerPack.Utility.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Managers
{
    public class ItemsPriceManager
    {
        private static ItemsPriceManager _instance;

        private ItemsPriceManager()
        {
        }

        public static ItemsPriceManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemsPriceManager();

                return _instance;
            }
        }

        public void BalancePrices()
        {
            foreach (KeyValuePair<ElementalParticles, int> particle in ElementalParticlesHelper.ParticleItemIDs)
            {
                AssignNewItemSellValue(particle.Value, ElementalParticlesHelper.ParticleSellPrice);
            }

            foreach (KeyValuePair<EnchantmentIngrediants, int> enchantmentIngrediant in EnchantmentIngrediantsHelper.NewSellPrices)
            {
                AssignNewItemSellValue(EnchantmentIngrediantsHelper.GetItemId(enchantmentIngrediant.Key), enchantmentIngrediant.Value);
            }

            foreach (IncensesTypes incense in IncensesTypesHelper.GetBaseInceses())
            {
                AssignNewItemSellValue(IncensesTypesHelper.GetIncenseId(incense), IncensesTypesHelper.BaseIncesesSellPrice);
            }

            foreach (IncensesTypes incense in IncensesTypesHelper.GetAdvancedInceses())
            {
                AssignNewItemSellValue(IncensesTypesHelper.GetIncenseId(incense), IncensesTypesHelper.AdvancedIncesesSellPrice);
            }

            foreach(EnchantmentRecipeItem enchantmentItem in EnchantmentRecipeItemManager.Instance.GetAllEnchantmentItems())
            {
                AssignNewItemSellValue(enchantmentItem.ItemID, enchantmentItem.Stats.m_baseValue / 3);
            }
        }

        public void AssignNewItemSellValue(int itemId, int sellPrice)
        {
            Item itemPrefab = ResourcesPrefabManager.Instance.GetItemPrefab(itemId);

            if (itemPrefab == null)
                return;

            if (itemPrefab.Stats == null)
            {
                itemPrefab.m_buyValue_DEPRECATED = sellPrice;
                return;
            }

            itemPrefab.Stats.m_baseValue = sellPrice;
        }
    }
}
