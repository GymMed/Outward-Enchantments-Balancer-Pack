using OutwardEnchantmentsBalancerPack.Utility.Data;
using OutwardEnchantmentsBalancerPack.Utility.Enums;
using OutwardEnchantmentsBalancerPack.Utility.Helpers;
using OutwardEnchantmentsBalancerPack.Utility.Helpers.Factories;
using OutwardModsCommunicator.EventBus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking.Match;

namespace OutwardEnchantmentsBalancerPack.Events
{
    public static class EventBusPublisher
    {
        public static void PublishGolemsDrops(List<ItemDropChance> enchantments)
        {
            PublishForgeGolemDrops(enchantments);
            PublishMoltenForgeGolemDrops(enchantments);
            PublishSwordGolemDrops(enchantments);
            PublishBeastGolemDrops(enchantments);
        }

        public static void PublishMoltenForgeGolemDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire, 10, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Forge Golem",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishForgeGolemDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Forge Golem",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 70);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishBeastGolemDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Beast Golem",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 70);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishSwordGolemDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(10, 1, 1),
                new DropConfig(20, 1, 4)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Sword Golem",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 50);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishTroglodytesDrops(List<ItemDropChance> enchantments)
        {
            PublishTroglodyteDrops();
            PublishManaTroglodyteDrops(enchantments);
            PublishArmoredTroglodyteDrops(enchantments);
            PublishTroglodyteKnightDrops(enchantments);
            PublishTroglodyteGrenadierDrops(enchantments);
        }

        public static void PublishTroglodyteDrops()
        {
            ItemDropChance itemDropChance = ItemDropHelpers.GetDreamersRootDrop(10, 1, 2, 0, 0);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Troglodyte",
                [LootManagerParamsHelper.Get(LootManagerParams.ItemDropChance).key] = itemDropChance,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishManaTroglodyteDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance rootDropChance = ItemDropHelpers.GetDreamersRootDrop(10, 1, 2, 0, 0);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(10, 1, 2, 0, 0);

            itemDrops.Add(rootDropChance);
            itemDrops.Add(quartzDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Mana Troglodyte",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 75);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishArmoredTroglodyteDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance rootDropChance = ItemDropHelpers.GetDreamersRootDrop(10, 1, 2, 0, 0);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(10, 1, 2, 0, 0);

            itemDrops.Add(rootDropChance);
            itemDrops.Add(quartzDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Armored Troglodyte",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 75);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishTroglodyteKnightDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance rootDropChance = ItemDropHelpers.GetDreamersRootDrop(10, 1, 2, 0, 0);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(10, 1, 2, 0, 0);

            itemDrops.Add(rootDropChance);
            itemDrops.Add(quartzDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Troglodyte Knight",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 75);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishTroglodyteGrenadierDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance rootDropChance = ItemDropHelpers.GetDreamersRootDrop(10, 1, 2, 0, 10);
            ItemDropChance decayDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 10, 1, 1, 10, 15);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(10, 1, 2, 0, 0);

            itemDrops.Add(rootDropChance);
            itemDrops.Add(decayDropChance);
            itemDrops.Add(quartzDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Troglodyte Grenadier",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishRootDrops(List<ItemDropChance> enchantments)
        {
            PublishHeynaDrops(enchantments);
            PublishArmoredHeynaDrops(enchantments);
            PublishWalkingHiveDrops(enchantments);
            PublishAssasinBugDrops(enchantments);
            PublishManaMantisDrops(enchantments);
            PublishManticoreDrops(enchantments);

            PublishDeerDrops(enchantments);
            PublishTuanosaursDrops(enchantments);
            PublishGoldenDrops(enchantments);
        }

        public static void PublishGoldenDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 20, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Golden,
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishTuanosaursDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(1, 1, 1),
                new DropConfig(1, 1, 1),
                new DropConfig(10, 1, 1)
            );
            ItemDropChance itemDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 10, 1, 1);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Tuanosaurs,
            };

            EventPayLoadHelpers.GetAndSetDistributedEnchantmentsDataToPayload(payload, itemDropChance, enchantments, 68);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishDeerDrops(List<ItemDropChance> enchantments)
        {
            ItemDropChance itemDropChance = ItemDropHelpers.GetDreamersRootDrop(30, 1, 3, 0, 0);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Deer,
            };

            EventPayLoadHelpers.GetAndSetDistributedEnchantmentsDataToPayload(payload, itemDropChance, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishHeynaDrops(List<ItemDropChance> enchantments)
        {
            ItemDropChance itemDropChance = ItemDropHelpers.GetDreamersRootDrop(20, 1, 3, 0, 0);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Hyena",
            };

            EventPayLoadHelpers.GetAndSetDistributedEnchantmentsDataToPayload(payload, itemDropChance, enchantments, 75);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishJewelbirdDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(20, 1, 3)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Jewelbird",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 60);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishPearlbirdDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(0), 
                new DropConfig(5, 1, 1),
                new DropConfig(20, 1, 3)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Pearlbird",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 70);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishWalkingHiveDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(40, 2, 4)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Walking Hive",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 30);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishGiantDrops(List<ItemDropChance> enchantments)
        {
            PublishAshGiantDrops(enchantments);
            PublishAshGiantPriestDrops(enchantments);
        }

        public static void PublishAshGiantPriestDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(3, 1, 1), 
                new DropConfig(10, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Ash Giant Priest",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 67);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishManticoreDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(10, 1, 1), 
                new DropConfig(10, 1, 1),
                new DropConfig(20, 1, 3)
            );

            ItemDropChance decayDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 20, 1, 1);
            itemDrops.Add(decayDropChance);

            ItemDropChance fireDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire, 10, 1, 1);
            itemDrops.Add(fireDropChance);

            ItemDropChance lightDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 20, 1, 1);
            itemDrops.Add(lightDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Manticore",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishManaMantisDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(20, 1, 1),
                new DropConfig(20, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Ice, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Mana Mantis",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 45);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishHiveLordDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(2, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 20, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Hive Lord",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 53);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishBladeDancerDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(10, 1, 1), 
                new DropConfig(2, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 10, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Blade Dancer",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 58);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishAshGiantDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(3, 1, 1), 
                new DropConfig(10, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 5, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Ash Giant",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 67);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishArmoredHeynaDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(2, 1, 1), 
                new DropConfig(2, 1, 1),
                new DropConfig(20, 2, 4)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Armored Heyna",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 73);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishAssasinBugDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(30, 2, 4)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Assasin Bug",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 50);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishIceDrops(List<ItemDropChance> enchantments)
        {
            PublishCrescentSharkDrops(enchantments);
            PublishWendigoDrops(enchantments);
        }

        public static void PublishFireDrops(List<ItemDropChance> enchantments)
        {
            PublishBurningManDrops(enchantments);
            PublishObsidianElementalDrops(enchantments);
            PublishFireBeetleDrops(enchantments);
        }

        public static void PublishFireBeetleDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(2, 1, 1), 
                new DropConfig(2, 1, 1),
                new DropConfig(20, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire, 10, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Fire Beetle",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 61);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishBurningManDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire, 15, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmulaneDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmulaneDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Burning Man",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 70);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishObsidianElementalDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire, 20, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmulaneDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmulaneDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Obsidian Elemental",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishHorrorDrops(List<ItemDropChance> enchantments)
        {
            PublishIlluminatorDrops(enchantments);
            PublishIlluminatorHorrorDrops(enchantments);
            PublishShellDrops(enchantments);

            PublishImmaculateDrops(enchantments);
            PublishImmaculateRaiderDrops(enchantments);
            PublishImmaculateWarlockDrops(enchantments);

            PublishBladeDancerDrops(enchantments);
            PublishHiveLordDrops(enchantments);
        }

        public static void PublishShellDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();
            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 30, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Shell Horror",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 60);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishImmaculateWarlockDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 15, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmalineDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmalineDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Immaculate Warlock",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishImmaculateRaiderDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 15, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmalineDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmalineDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Immaculate Raider",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishImmaculateDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 15, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmalineDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmalineDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Immaculate",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishIlluminatorDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 15, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmalineDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmalineDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Illuminator",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 65);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishIlluminatorHorrorDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = new();

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Decay, 10, 1, 1);
            ItemDropChance quartzDropChance = ItemDropHelpers.GetPurifyingQuartzDrop(5, 1, 1, 0, 0);
            ItemDropChance tourmalineDropChance = ItemDropHelpers.GetTourmalineDrop(5, 1, 1, 0, 0);

            itemDrops.Add(particleDropChance);
            itemDrops.Add(quartzDropChance);
            itemDrops.Add(tourmalineDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Illuminator Horror",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 70);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishBanditsDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(3, 1, 1), 
                new DropConfig(5, 1, 1),
                new DropConfig(10, 1, 3)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Bandits,
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 72);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);

            //PublishTestBanditsDrops();
            // For testing
            //PublishIceExceptionsDrops();
        }

        public static void PublishTestBanditsDrops()
        {
            List<ItemDropChance> itemDropChances = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(45, 1, 3), 
                new DropConfig(46, 1, 3)
            );

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = itemDropChances,
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Bandits,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishIceExceptionsDrops(List<ItemDropChance> enchantments)
        {
            //List<ItemDropChance> itemDropChance = ItemDropHelpers.GetGuaranteedParticlesDrop(1, 1);
            ItemDropChance itemDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Fire);

            List<string> exceptNames = new List<string>();
            exceptNames.Add("Ice Witch");

            var payload = new EventPayload
            {
                //["listOfItemDropChances"] = itemDropChance,
                [LootManagerParamsHelper.Get(LootManagerParams.ItemDropChance).key] = itemDropChance,
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Bandits,
                [LootManagerParamsHelper.Get(LootManagerParams.ExceptNames).key] = exceptNames,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishWendigoDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(20, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Ice, 30, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Wendigo",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 25);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishCrescentSharkDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDrops = DropFactory.GetEnchantmentIngrediantsDrops(
                new DropConfig(5, 1, 1), 
                new DropConfig(20, 1, 1),
                new DropConfig(10, 1, 3)
            );

            ItemDropChance particleDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Ice, 15, 1, 1);
            itemDrops.Add(particleDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Crescent Shark",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDrops, enchantments, 40);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishIceWitchDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemDropChances = new List<ItemDropChance>(); 
            ItemDropChance itemDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Ice, 40, 1, 1);
            itemDropChances.Add(itemDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Ice Witch",
                [LootManagerParamsHelper.Get(LootManagerParams.Faction).key] = Character.Factions.Bandits,
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDropChances, enchantments, 55);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishAncientDwellerDrops(List<ItemDropChance> enchantments)
        {
            ItemDropChance eitherDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Either, 40, 1, 1);
            ItemDropChance lightDropChance = ItemDropHelpers.GetSpecificParticleDrop(ElementalParticles.Light, 40, 1, 1);

            List<ItemDropChance> itemDropChances = new List<ItemDropChance>();
            itemDropChances.Add(eitherDropChance);
            itemDropChances.Add(lightDropChance);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.EnemyName).key] = "Ancient Dweller",
            };

            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemDropChances, enchantments);
            
            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootByEnemyName", payload);
        }

        public static void PublishUniquesDrops(List<ItemDropChance> enchantments)
        {
            PublishBossesDrops(enchantments);
            PublishUniqueEnemyDrops(enchantments);

            PublishUncertainBossesDrops(enchantments);
            PublishUncertainUniqueEnemyDrops(enchantments);
        }

        public static void PublishUniqueEnemyDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemsDropChances = ItemDropHelpers.GetGuaranteedParticlesDrop(1, 1);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForUniqueEnemies).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = itemsDropChances,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootForUniques", payload);
        }

        public static void PublishUncertainUniqueEnemyDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemsDropChances = new List<ItemDropChance>();
            itemsDropChances.Add(ItemDropHelpers.GetTourmalineDrop(10));
            itemsDropChances.Add(ItemDropHelpers.GetPurifyingQuartzDrop(10));

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForUniqueEnemies).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
            };
            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemsDropChances, enchantments, 33);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootForUniques", payload);
        }

        public static void PublishBossesDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemsDropChances = ItemDropHelpers.GetGuaranteedParticlesDrop(1, 2);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = itemsDropChances,
                [LootManagerParamsHelper.Get(LootManagerParams.IsForBosses).key] = true,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootForUniques", payload);
        }

        public static void PublishUncertainBossesDrops(List<ItemDropChance> enchantments)
        {
            List<ItemDropChance> itemsDropChances = new List<ItemDropChance>();
            itemsDropChances.Add(ItemDropHelpers.GetTourmalineDrop(10));
            itemsDropChances.Add(ItemDropHelpers.GetPurifyingQuartzDrop(10));

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForBosses).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
            };
            EventPayLoadHelpers.SetDistributedEnchantmentsToPayload(payload, itemsDropChances, enchantments, 10);

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLootForUniques", payload);
        }

        public static void PublishGlobalDrops()
        {
            PublishIncenseDrops();
            PublishIncenseDropsForUnique();
            PublishIncenseDropsForBosses();
        }

        public static void PublishIncenseDrops()
        {
            List<ItemDropChance> drops = ItemDropHelpers.GetIncensesDrop(1);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForBosses).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = drops,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishIncenseDropsForBosses()
        {
            List<ItemDropChance> drops = ItemDropHelpers.GetIncensesDrop(8);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForBosses).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = drops,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishIncenseDropsForUnique()
        {
            List<ItemDropChance> drops = ItemDropHelpers.GetIncensesDrop(5);

            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.IsForUniqueEnemies).key] = true,
                [LootManagerParamsHelper.Get(LootManagerParams.MinDropCount).key] = 1,
                [LootManagerParamsHelper.Get(LootManagerParams.MaxDropCount).key] = 2,
                [LootManagerParamsHelper.Get(LootManagerParams.ListOfItemDropChances).key] = drops,
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "AddLoot", payload);
        }

        public static void PublishStoreLootsToXml()
        {
            var payload = new EventPayload
            {
                //["filePath"] = "",
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "LootRulesSerializer@SaveLootRulesToXml", payload);
        }

        public static void PublishLoadLootsXml()
        {
            var payload = new EventPayload
            {
                [LootManagerParamsHelper.Get(LootManagerParams.LoadLootsXmlFilePath).key] = Path.Combine(OutwardEnchantmentsBalancerPack.OEBP.GetProjectLocation(), "MyLootOverrides.xml"),
            };

            EventBus.Publish(OEBP.LOOT_MANAGER_ALL_GUID, "LootRulesSerializer@SaveLootRulesToXml", payload);
        }
    }
}
