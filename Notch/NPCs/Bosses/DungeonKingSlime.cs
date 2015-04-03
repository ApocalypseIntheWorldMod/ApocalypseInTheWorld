using System;
using Microsoft.Xna.Framework;
using Terraria;
using TAPI;

namespace Notch
{
	public class DungeonKingSlime : ModNPC
	{
		public override void AI()
		{
			if (Main.netMode != 1)
            {
				Projectile.NewProjectile(5, 5, 10, 7, "Cursed Flame", 60, 0, Main.myPlayer, 240, 240);
			}				
		}
		public override void HitEffect(int hitDirection, double damage, bool isDead)
		{
			int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("71"), 0);
		}
	}
}