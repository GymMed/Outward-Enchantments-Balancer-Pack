using OutwardEnchantmentsBalancerPack.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Helpers
{
    public static class ItemDropHelpers
    {
        public static List<ItemDropChance> GetEnchantmentIngrediantsDrops(int tourmalineChance = 10, int quartzChance = 10, int rootChance = 0)
        {
            List<ItemDropChance> items = new List<ItemDropChance>();

            if (tourmalineChance > 0)
                items.Add(GetTourmalineDrop(tourmalineChance, 1, 1));

            if (quartzChance > 0)
                items.Add(GetPurifyingQuartzDrop(quartzChance, 1, 1));

            if (rootChance > 0)
                items.Add(GetDreamersRootDrop(rootChance, 1, 3));

            return items;
        }

        public static ItemDropChance GetTourmalineDrop(int dropChance = 10, int minDropCount = 1, int maxDropCount = 2, int minDiceRoll = 0, int maxDiceRoll = 0)
        {
            return CreateItemDropChace(
                6200170, 
                dropChance, 
                minDropCount, 
                maxDropCount, 
                minDiceRoll, 
                maxDiceRoll
           );
        }

        public static ItemDropChance GetPurifyingQuartzDrop(int dropChance = 10, int minDropCount = 1, int maxDropCount = 2, int minDiceRoll = 0, int maxDiceRoll = 0)
        {
            return CreateItemDropChace(
                6000170, 
                dropChance, 
                minDropCount, 
                maxDropCount, 
                minDiceRoll, 
                maxDiceRoll
           );
        }

        public static ItemDropChance GetDreamersRootDrop(int dropChance = 10, int minDropCount = 1, int maxDropCount = 2, int minDiceRoll = 0, int maxDiceRoll = 0)
        {
            return CreateItemDropChace(
                4000360, 
                dropChance, 
                minDropCount, 
                maxDropCount, 
                minDiceRoll, 
                maxDiceRoll
           );
        }

        public static ItemDropChance GetSpecificParticleDrop(ElementalParticles particle, int dropChance = 10, int minDropCount = 1, int maxDropCount = 2, int minDiceRoll = 0, int maxDiceRoll = 0)
        {
            return CreateItemDropChace(
                ElementalParticlesHelper.GetItemID(particle), 
                dropChance, 
                minDropCount, 
                maxDropCount, 
                minDiceRoll, 
                maxDiceRoll
           );
        }

        public static ItemDropChance CreateItemDropChace(int itemId, int dropChance = 10, int minDropCount = 1, int maxDropCount = 2, int minDiceRoll = 0, int maxDiceRoll = 0)
        {
            ItemDropChance itemDropChance = new ItemDropChance();
            itemDropChance.DropChance = dropChance;
            itemDropChance.ItemID = itemId;
            itemDropChance.MinDropCount = minDropCount;
            itemDropChance.MaxDropCount = maxDropCount;
            itemDropChance.MinDiceRollValue = minDiceRoll;
            itemDropChance.MaxDiceRollValue = maxDiceRoll;

            return itemDropChance;
        }

        public static List<ItemDropChance> GetIncensesDrop(int dropChance = 1, int minDropCount = 1, int maxDropCount = 2)
        {
            List<ItemDropChance> drops = new();

            foreach(KeyValuePair<IncensesTypes, int> incense in IncensesTypesHelper.IncensesIds)
            {
                drops.Add(CreateItemDropChace(incense.Value, dropChance, minDropCount, maxDropCount));
            }

            return drops;
        }

        public static List<ItemDropChance> GetGuaranteedParticlesDrop(int minDropCount = 1, int maxDropCount = 2)
        {
            ItemDropChance decayDropChance = new ItemDropChance();
            decayDropChance.DropChance = 20;
            decayDropChance.ItemID = ElementalParticlesHelper.GetItemID(ElementalParticles.Decay);
            decayDropChance.MinDropCount = minDropCount;
            decayDropChance.MaxDropCount = maxDropCount;
            decayDropChance.MinDiceRollValue = 0;
            decayDropChance.MaxDiceRollValue = 20;

            ItemDropChance eitherDropChance = new ItemDropChance();
            eitherDropChance.DropChance = 20;
            eitherDropChance.ItemID = ElementalParticlesHelper.GetItemID(ElementalParticles.Either);
            eitherDropChance.MinDropCount = minDropCount;
            eitherDropChance.MaxDropCount = maxDropCount;
            eitherDropChance.MinDiceRollValue = 20;
            eitherDropChance.MaxDiceRollValue = 40;

            ItemDropChance fireDropChance = new ItemDropChance();
            fireDropChance.DropChance = 20;
            fireDropChance.ItemID = ElementalParticlesHelper.GetItemID(ElementalParticles.Fire);
            fireDropChance.MinDropCount = minDropCount;
            fireDropChance.MaxDropCount = maxDropCount;
            fireDropChance.MinDiceRollValue = 40;
            fireDropChance.MaxDiceRollValue = 60;

            ItemDropChance iceDropChance = new ItemDropChance();
            iceDropChance.DropChance = 20;
            iceDropChance.ItemID = ElementalParticlesHelper.GetItemID(ElementalParticles.Ice);
            iceDropChance.MinDropCount = minDropCount;
            iceDropChance.MaxDropCount = maxDropCount;
            iceDropChance.MinDiceRollValue = 60;
            iceDropChance.MaxDiceRollValue = 80;

            ItemDropChance lightDropChance = new ItemDropChance();
            lightDropChance.DropChance = 20;
            lightDropChance.ItemID = ElementalParticlesHelper.GetItemID(ElementalParticles.Light);
            lightDropChance.MinDropCount = minDropCount;
            lightDropChance.MaxDropCount = maxDropCount;
            lightDropChance.MinDiceRollValue = 80;
            lightDropChance.MaxDiceRollValue = 100;

            List<ItemDropChance> particlesDrops = new List<ItemDropChance>();
            particlesDrops.Add(decayDropChance);
            particlesDrops.Add(eitherDropChance);
            particlesDrops.Add(fireDropChance);
            particlesDrops.Add(iceDropChance);
            particlesDrops.Add(lightDropChance);

            return particlesDrops;
        }
    }
}
