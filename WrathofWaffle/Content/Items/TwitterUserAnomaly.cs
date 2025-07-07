using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WrathofWaffle.Content.Items
{ 
	
	public class TwitterUserAnomaly : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.crit = 10;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 25;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 9;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 14500);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item84;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Electrosphere;
			Item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient<MutedFragment>(1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
