using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using OutwardModsCommunicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using OutwardModsCommunicator.EventBus;
using OutwardEnchantmentsBalancerPack.Events;
using UnityEngine.Networking.Match;
using OutwardEnchantmentsBalancerPack.Managers;

// RENAME 'OutwardModPackTemplate' TO SOMETHING ELSE
namespace OutwardEnchantmentsBalancerPack
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(OutwardModsCommunicator.OMC.GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(LOOT_MANAGER_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("gymmed.outward_game_settings", BepInDependency.DependencyFlags.SoftDependency)]
    public class OEBP : BaseUnityPlugin
    {
        public const string GUID = "gymmed.enchantments_balancer_pack";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "Enchantments Balancer Pack";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "0.0.2";

        // Choose prefix for log messages for quicker search and readablity
        public static string prefix = "[Enchantments-Balancer]";

        public const string LOOT_MANAGER_GUID = "gymmed.loot_manager";
        public static string LOOT_MANAGER_ALL_GUID = LOOT_MANAGER_GUID + "_*";

        internal static ManualLogSource Log;

        // If you need settings, define them like so:
        //public static ConfigEntry<bool> ExampleConfig;

        internal void Awake()
        {
            Log = this.Logger;
            LogMessage($"Hello world from {NAME} {VERSION}!");

            // Any config settings you define should be set up like this:
            //ExampleConfig = Config.Bind("ExampleCategory", "ExampleSetting", false, "This is an example setting.");

            OutwardModsCommunicator.OMC.xmlFilePath = Path.Combine(GetProjectLocation(), "MyModsOverrides.xml");

            // Harmony is for patching methods. If you're not patching anything, you can comment-out or delete this line.
            new Harmony(GUID).PatchAll();

            EventBus.Subscribe(GUID + "_*", "OEBP@OverwriteXmlFilePath", OverwriteXmlFilePath);
        }

        private void OverwriteXmlFilePath(EventPayload payload)
        {
            if (payload == null) return;

            // try to retrieve passed event data, don't forget to check if retrieve didn't fail
            string filePath = payload.Get<string>("xmlFilePath", null);

            if(string.IsNullOrEmpty(filePath))
            {
                LogSL($"OEBP@OverwriteXmlFilePath string variable xmlFilePath is missing! Make sure to provide xmlFilePath.");

            }

            LogSL($"xmlFilePath = {filePath}");
        }

        // Update is called once per frame. Use this only if needed.
        // You also have all other MonoBehaviour methods available (OnGUI, etc)
        internal void Update()
        {
        }

        //  Log message with prefix
        public static void LogMessage(string message)
        {
            Log.LogMessage($"{OEBP.prefix} {message}");
        }

        // Log message through side loader, helps to see it
        // if you are using UnityExplorer and want to see live logs
        public static void LogSL(string message)
        {
            SL.Log($"{OEBP.prefix} {message}");
        }

        // Gets mod dll location
        public static string GetProjectLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static void PublishLoot()
        {
            try
            {
                List<ItemDropChance> enchantmentsDrops = EnchantmentRecipeItemManager.Instance.GetAllEnchantmentItemsAsDropChances();

                EventBusPublisher.PublishRootDrops(enchantmentsDrops);
                EventBusPublisher.PublishFireDrops(enchantmentsDrops);
                EventBusPublisher.PublishIceDrops(enchantmentsDrops);
                EventBusPublisher.PublishHorrorDrops(enchantmentsDrops);
                EventBusPublisher.PublishGiantDrops(enchantmentsDrops);
                EventBusPublisher.PublishBanditsDrops(enchantmentsDrops);
                EventBusPublisher.PublishUniquesDrops(enchantmentsDrops);
                EventBusPublisher.PublishIceWitchDrops(enchantmentsDrops);
                EventBusPublisher.PublishAncientDwellerDrops(enchantmentsDrops);
                EventBusPublisher.PublishGlobalDrops();

                //EventBusPublisher.PublishStoreLootsToXml();
            } 
            catch(Exception e)
            {
                LogMessage($"OutwardEnchantmentsBalancerPack@PublishLoot we encountered an errpr: \"{e.Message}\"");
            }
        }

        // This is an example of a Harmony patch.
        // If you're not using this, you should delete it.
        [HarmonyPatch(typeof(ResourcesPrefabManager), nameof(ResourcesPrefabManager.Load))]
        public class ResourcesPrefabManager_Load
        {
            static void Postfix(ResourcesPrefabManager __instance)
            {
                // use Debug build for things you don't want to release
#if DEBUG
                // provide class and method separated by @ for easier live debugging
                LogSL("ResourcesPrefabManager@Load called!");
#endif
                PublishLoot();
                ItemsPriceManager.Instance.BalancePrices();
            }
        }
    }
}
