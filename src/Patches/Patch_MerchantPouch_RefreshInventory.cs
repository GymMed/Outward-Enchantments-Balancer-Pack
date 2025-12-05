using HarmonyLib;
using OutwardEnchantmentsBalancerPack.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Patches
{
    [HarmonyPatch(typeof(MerchantPouch), nameof(MerchantPouch.RefreshInventory))]
    public class Patch_MerchantPouch_RefreshInventory
    {
        public readonly static Dictionary<string, string> MerchantsToFillIncense = new Dictionary<string, string>()
        {
            { "Fourth Watcher" , "9Qi1PDHnIUKf-eNT8Y3FJQ" },
            { "Agatha, Maiden of the Winds" , "YMvgNzX7JEG6PnQdK1Z-Dg" },
        };

        static void Prefix(MerchantPouch __instance, Dropable _dropable)
        {
            //refresh timer
            if (EnvironmentConditions.GameTime < __instance.m_nextRefreshTime || PhotonNetwork.isNonMasterClientInRoom)
            {
                return;
            }

            if (__instance.Merchant == null)
                return;

            if (__instance.Merchant.ShopName.Contains("Alchemist", StringComparison.OrdinalIgnoreCase))
            {
                int randomAmount = UnityEngine.Random.Range(1, 6);
                MerchantHelpers.TryMoveItemsToContainer(__instance, MerchantHelpers.GenerateItemsByIds(MerchantHelpers.GetRandomIncensesIds(randomAmount), 1, 5));
            }

            if (MerchantsToFillIncense.Values.Contains(__instance.Merchant.HolderUID.Value))
            {
                int randomAmount = UnityEngine.Random.Range(1, 6);
                MerchantHelpers.TryMoveItemsToContainer(__instance, MerchantHelpers.GenerateItemsByIds(MerchantHelpers.GetRandomIncensesIds(randomAmount), 1, 5));
            }
        }
    }
}
