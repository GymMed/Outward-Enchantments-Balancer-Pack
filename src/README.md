<h1 align="center">
    Outward Enchantments Balancer Pack
</h1>
<br/>
<div align="center">
  <img src="https://raw.githubusercontent.com/GymMed/Outward-Enchantments-Balancer-Pack/refs/heads/main/preview/images/1.png" alt="Logo"/>
</div>

<div align="center">
	<a href="https://thunderstore.io/c/outward/p/GymMed/Enchantments_Balancer_Pack/">
		<img src="https://img.shields.io/thunderstore/dt/GymMed/Enchantments_Balancer_Pack" alt="Thunderstore Downloads">
	</a>
	<a href="https://github.com/GymMed/Outward-Enchantments-Balancer-Pack/releases/latest">
		<img src="https://img.shields.io/thunderstore/v/GymMed/Enchantments_Balancer_Pack" alt="Thunderstore Version">
	</a>
	<a href="https://github.com/GymMed/Outward-Mods-Communicator/releases/latest">
		<img src="https://img.shields.io/badge/Mods_Communicator-v1.2.0-D4BD00" alt="Min Mods Communicator Version">
	</a>
</div>

This Outward mod introduces enchantments much earlier in the game while keeping
the experience balanced and making late-game progression more challenging.

<details>
    <summary>Deeper Explanation</summary>
The <i>Soroboreans</i> DLC adds the enchanting system, but most of the
materials needed for enchanting are found in the <b>Antique Plateau</b>, a
location many players only reach after finishing the main game. The Definitive
Edition attempted to spread enchanting materials across more zones, but in my
opinion, it didn’t fully succeed—likely because the developers didn’t have
enough time to balance the loot tables properly.

This mod aims to deliver what the enchanting system should have felt like. It
integrates early-game enchanting in a natural, balanced way without
overwhelming the progression.

To accomplish this, the mod uses the <a
href="https://github.com/GymMed/Outward-Loot-Manager">Loot Manager</a> to
adjust zone drop tables and introduce enchanting items earlier, but with a key
trade-off: it also uses the <a
href="https://github.com/GymMed/Outward-Game-Settings">Game Settings Mod</a> to
add enchantment success chance, require an <code>EnchantmentRecipeItem</code>,
and consume that item on each attempt.

<details>
    <summary>How do these changes impact the game?</summary>
You lose the ability to precisely target specific enchantments. In the base
game, if you wanted strong enchantments, you could simply look up the
requirements on the <a
href="https://outward.fandom.com/wiki/The_Soroboreans">Outward Wiki</a> and
guarantee the results early.

With this mod, you no longer need to rush to the <b>Antique Plateau</b> or rely on the
wiki to min-max enchantments. Instead, enchanting becomes a natural part of
early and mid-game exploration, fitting more organically into the world.
</details>

The mod also adds incense items to alchemist vendors and adjusts their prices.
Since enchanting materials become more plentiful, crafting or selling incense,
enchantments, and related ingredients could otherwise be exploited for easy
profit. To keep the economy balanced, sell prices for these items have been
reduced.

Finally, the mod dynamically assigns enchantments to enemies, allowing them to
drop <code>EnchantmentRecipeItem</code> from other mods as well.
</details>

<img
src="https://raw.githubusercontent.com/GymMed/Outward-Enchantments-Balancer-Pack/refs/heads/main/preview/images/2.png"
alt="Enchanments Loot Drop"
/>

## How to set up

To manually set up, do the following

1. Create the directory: `Outward\BepInEx\plugins\OutwardEnchantmentsBalancerPack\`.
2. Extract the archive into any directory(recommend empty).
3. Move the contents of the plugins\ directory from the archive into the `BepInEx\plugins\OutwardEnchantmentsBalancerPack\` directory you created.
4. It should look like `Outward\BepInEx\plugins\OutwardEnchantmentsBalancerPack\OutwardEnchantmentsBalancerPack.dll`
   Launch the game.

### If you liked the mod leave a star on [GitHub](https://github.com/GymMed/Outward-Enchantments-Balancer-Pack) it's free
