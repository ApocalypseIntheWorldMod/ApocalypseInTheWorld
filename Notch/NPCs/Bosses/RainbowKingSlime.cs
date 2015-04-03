using System;
using Microsoft.Xna.Framework;
using Terraria;
using TAPI;

namespace Notch
{
	public class RainbowKingSlime : ModNPC
	{
        public override void HitEffect(int hitDirection, double damage, bool isDead)
        {
            if (npc.ai[0] < 1f && npc.life <= 14000 && npc.ai[1] < 5)
            {
                int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("Vanilla:RainbowSlime"), 0);
            }
            if (npc.ai[0] < 1f && npc.life <= 13000 && npc.ai[1] < 5)
            {
                int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("Vanilla:RainbowSlime"), 0);
            }
            if (npc.ai[0] < 1f && npc.life <= 12000 && npc.ai[1] < 5)
            {
                int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("Vanilla:RainbowSlime"), 0);
            }
            if (npc.ai[0] < 1f && npc.life <= 11000 && npc.ai[1] < 5)
            {
                int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("Vanilla:RainbowSlime"), 0);
            }
            if (npc.ai[0] < 1f && npc.life <= 10000 && npc.ai[1] < 5)
            {
                int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, ("Vanilla:RainbowSlime"), 0);
            }
        }
	}
}