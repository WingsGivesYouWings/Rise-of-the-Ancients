using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace RiseoftheAncients.Properties.Items.Swords
{
 
        public class SteelShard : ModItem // Your item name (SteelShard) and type (ModItem)
        {
            public override void SetStaticDefaults()
            {
                CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; // How many items need for research in Journey Mo
            }

            public override void SetDefaults()
            {
                Item.width = 22; // Width of an item sprite
                Item.height = 24; // Height of an item sprite
                Item.maxStack = 9999; // How many items can be in one inventory slot
                Item.value = 100; // Item sell price in copper coins
                Item.rare = ItemRarityID.Blue; // 
            }
        }
    }
    class FileName;
    

