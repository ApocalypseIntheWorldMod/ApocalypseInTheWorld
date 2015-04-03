using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace dradon_mod.Items
{
	public class DradonChestplate : ModItem
	{
		public override void Effects(Player p)
		{
			p.maxMinions += 60;
			p.rangedDamage = 50000f;
			p.moveSpeed = 5;
		}
		public override void ArmorSetBonus(Player player)
		{
			player.maxMinions += 60;
			player.ghostHeal = true;
			player.ghostHurt = true;
		}
	}
}