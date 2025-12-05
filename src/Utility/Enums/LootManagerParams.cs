using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutwardEnchantmentsBalancerPack.Utility.Enums
{
    public enum LootManagerParams
    {
        LootId,
        ItemId,
        DropChance,
        MinDropCount,
        MaxDropCount,
        MinDiceRollValue,
        MaxDiceRollValue,
        EnemyId,
        EnemyName,
        AreaEnum,
        AreaFamily,
        Faction,
        ExceptIds,
        ExceptNames,
        IsForBosses,
        IsForBossesPawns,
        IsForStoryBosses,
        IsForUniqueArenaBosses,
        IsForUniqueEnemies,
        ListOfItemDropChances,
        ItemDropChance,
        MinNumberOfDrops,
        MaxNumberOfDrops,
        EmptyDropChance,
        MaxDiceValue,
        // separated
        LoadLootsXmlFilePath,
        StoreLootsXmlFilePath,
    }

    public static class LootManagerParamsHelper
    {
        // because param strings a reused multiple times it helps to have enum to detect type mistakes in compiler builds.
        private static readonly Dictionary<LootManagerParams, (string key, Type type)> _params
            = new()
            {
                [LootManagerParams.LootId] = ("lootId", typeof(string)),
                [LootManagerParams.ItemId] = ("itemId", typeof(int)),
                [LootManagerParams.DropChance] = ("dropChance", typeof(int)),
                [LootManagerParams.MinDropCount] = ("minDropCount", typeof(int)),
                [LootManagerParams.MaxDropCount] = ("dropChance", typeof(int)),
                [LootManagerParams.MinDiceRollValue] = ("minDiceRollValue", typeof(int)),
                [LootManagerParams.MaxDiceRollValue] = ("maxDiceRollValue", typeof(int)),
                [LootManagerParams.EnemyId] = ("enemyId", typeof(string)),
                [LootManagerParams.EnemyName] = ("enemyName", typeof(string)),
                [LootManagerParams.AreaEnum] = ("area", typeof(AreaManager.AreaEnum?)),
                [LootManagerParams.AreaFamily] = ("areaFamily", typeof(AreaFamily)),
                [LootManagerParams.Faction] = ("faction", typeof(Character.Factions?)),
                [LootManagerParams.ExceptIds] = ("listExceptIds", typeof(List<string>)),
                [LootManagerParams.ExceptNames] = ("listExceptNames", typeof(List<string>)),
                [LootManagerParams.IsForBosses] = ("isForBosses", typeof(bool)),
                [LootManagerParams.IsForBossesPawns] = ("isForBossPawns", typeof(bool)),
                [LootManagerParams.IsForStoryBosses] = ("isForStoryBosses", typeof(bool)),
                [LootManagerParams.IsForUniqueArenaBosses] = ("isForUniqueArenaBosses", typeof(bool)),
                [LootManagerParams.IsForUniqueEnemies] = ("isForUniqueEnemies", typeof(bool)),
                [LootManagerParams.ListOfItemDropChances] = ("listOfItemDropChances", typeof(List<ItemDropChance>)),
                [LootManagerParams.ItemDropChance] = ("itemDropChance", typeof(ItemDropChance)),
                [LootManagerParams.MinNumberOfDrops] = ("minNumberOfDrops", typeof(int)),
                [LootManagerParams.MaxNumberOfDrops] = ("maxNumberOfDrops", typeof(int)),
                [LootManagerParams.EmptyDropChance] = ("emptyDropChance", typeof(int)),
                [LootManagerParams.MaxDiceValue] = ("maxDiceValue", typeof(int)),
                // not loot
                [LootManagerParams.LoadLootsXmlFilePath] = ("filePath", typeof(string)),
                [LootManagerParams.StoreLootsXmlFilePath] = ("filePath", typeof(string)),
            };

        public static (string key, Type type) Get(LootManagerParams param) => _params[param];
    }
}
