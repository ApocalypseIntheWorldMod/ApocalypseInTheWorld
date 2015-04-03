using System;
using Microsoft.Xna.Framework;
using Terraria;
using TAPI;

namespace Notch.NPCs
{
    public class CorruptedFairy : ModNPC
    {
		public override void AI()
		{
			if (Main.netMode != 1)
            {
				//Pixie invoction
			    if(npc.ai[0] < 1f && npc.life <= 300 && npc.ai[1] <20)
				{
				int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, "Vanilla:Pixie", 0);	
				Main.NewText("Go brother, protect me!", 255, 40, 150);
				}
				//Projectile Holy Water for hallow tile
				if (Main.netMode !=1 && npc.localAI[0] == 0f)
                {					
				    Projectile.NewProjectile(5, 5, 10, 7, "Vanilla:Holy water", 60, 0, Main.myPlayer, 240, 240);
				}
		    }
		}
		public override bool CanSpawn(int x, int y, int type, Player player)
		{
			bool holy = player.zoneHoly;
			return Notch.downedEyeOfApocalypse > 0 && y > Main.worldSurface && y < Main.hellLayer;
		}
	}
}