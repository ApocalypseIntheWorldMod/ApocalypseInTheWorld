using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace dradon_mod.Items
{
	public class DradonHelmet : ModItem
	{
		public override void Effects(Player p)
		{
			p.maxMinions += 15;
			p.meleeDamage = 50000f;
			p.moveSpeed = 40;
		}
		public override void ArmorSetBonus(Player player)
		{
			player.maxMinions += 60;
			player.ghostHeal = true;
			player.ghostHurt = true;
		}
	}
}
