using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseoftheAncients.Properties.Items.Swords
{
    class FileName
    { public class SteelSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // How many items need for research in Journey Mode
        }

        public override void SetDefaults()
        {
            // Visual properties
            Item.width = 40; // Width of an item sprite
            Item.height = 40; // Height of an item sprite
            Item.scale = 1f; // Multiplicator of item size, for example is you set this to 2f our sword will be biger twice. IMPORTANT: If you are using numbers with floating point, write "f" in their end, like 1.5f, 3.14f, 2.1278495f etc.
            Item.rare = ItemRarityID.Blue; // The color of item's name in game. Check https://terraria.wiki.gg/wiki/Rarity

            // Combat properties
            Item.damage = 50; // Item damage
            Item.DamageType = DamageClass.Melee; // What type of damage item is deals, Melee, Ranged, Magic, Summon, Generic (takes bonuses from all damage multipliers), Default (doesn't take bonuses from any damage multipliers)
            // useTime and useAnimation often use the same value, but we'll see examples where they don't use the same values
            Item.useTime = 20; // How long the swing lasts in ticks (60 ticks = 1 second)
            Item.useAnimation = 20; // How long the swing animation lasts in ticks (60 ticks = 1 second)
            Item.knockBack = 6f; // How far the sword punches enemies, 20 is maximal value
            Item.autoReuse = true; // Can the item auto swing by holding the attack button
        }
    }
}
}
