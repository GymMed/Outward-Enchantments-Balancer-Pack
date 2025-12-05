using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Enums
{
    public enum ElementalParticles
    {
        Decay = 6000140,
        Either = 6000150,
        Fire = 6000110,
        Ice = 6000120,
        Light = 6000130,
    }

    public static class ElementalParticlesHelper
    {
        public static readonly Dictionary<ElementalParticles, int> ParticleItemIDs = new()
        {
            { ElementalParticles.Decay, 6000140 },
            { ElementalParticles.Either, 6000150 },
            { ElementalParticles.Fire, 6000110 },
            { ElementalParticles.Ice, 6000120 },
            { ElementalParticles.Light, 6000130 },
        };

        // original 54
        // 33% = 18
        public static int ParticleSellPrice = 18;

        public static int GetItemID(ElementalParticles type)
        {
            return ParticleItemIDs.TryGetValue(type, out var id) ? id : -1; // -1 = not found
        }

        public static ElementalParticles? GetParticleType(int itemID)
        {
            foreach (var pair in ParticleItemIDs)
                if (pair.Value == itemID)
                    return pair.Key;

            return null;
        }
    }
}
