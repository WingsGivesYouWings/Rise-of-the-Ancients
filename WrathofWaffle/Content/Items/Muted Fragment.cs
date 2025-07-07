using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WrathofWaffle.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class MutedFragment : ModItem
	{
		public override void SetDefaults()
		{
		Item.value = Item.buyPrice(silver: 10000);
		Item.rare = ItemRarityID.Cyan;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalStorm, 1);
			recipe.AddIngredient(ItemID.CursedFlames, 1);
			recipe.AddIngredient(ItemID.GoldenShower,1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
