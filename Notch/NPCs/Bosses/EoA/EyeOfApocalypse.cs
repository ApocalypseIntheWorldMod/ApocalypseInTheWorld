using System;
using Microsoft.Xna.Framework;
using Terraria;
using TAPI;

namespace Notch.NPCs
{
    public class EyeOfApocalypse : ModNPC
    {

        bool spawnTwins = true;
        bool shouldTeleport = false;
        bool shouldCharge = false;

        public static Player GetPlayer(NPC npc) 
        {
            Player player = Main.player[npc.target];
            return player;
        }

        public override void AI()
        {
            if (Main.netMode != 1)
            {
                if (spawnTwins)
                {
                    float subit = (float)Math.PI / 2f;

                    Player player = GetPlayer(npc);

                    Vector2 abovePlayer = player.Center + new Vector2(0f, -250f);

                    if (!shouldTeleport && !shouldCharge)
                    {
                        float speed = 5f;
                        Vector2 move = abovePlayer - npc.Center;
                        float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                        if (magnitude > speed)
                        {
                            move *= speed / magnitude;
                        }
                        npc.velocity = move;
                    }

                    Vector2 distance = player.Center - npc.Center;
                    float angle = (float)Math.Atan2(distance.Y, distance.X);
                    npc.rotation = angle - subit;

                    //Debugging for the ai[0] Delete when finished :)
                    Main.NewText(npc.ai[0] + ", " + npc.ai[1], Color.White);

                    npc.ai[0]--;

                    if (shouldTeleport && npc.ai[0] < -110f)
                    {
                        int num1 = Main.rand.Next(2);

                        for (int q = 0; q < 45; q++)
                        {
                            Vector2 randpos = new Vector2(npc.position.X + Main.rand.Next(-75, 76), npc.position.Y + Main.rand.Next(-75, 76));
                            int dustID = Dust.NewDust(randpos, 16, 16, 64, 0f, 0f, 0, Color.Yellow, 2.4f);
                            Main.dust[dustID].noGravity = true;
                        }

                        if (num1 == 0)
                        {
                            npc.position = new Vector2(player.Center.X + (float)Main.rand.Next(150, 550), player.Center.Y - (float)Main.rand.Next(150, 550));
                        }
                        else if (num1 == 1)
                        {
                            npc.position = new Vector2(player.Center.X - (float)Main.rand.Next(150, 550), player.Center.Y - (float)Main.rand.Next(150, 550));
                        }

                        for (int r = 0; r < 30; r++)
                        {
                            Vector2 randpos = new Vector2(npc.position.X + Main.rand.Next(-75, 76), npc.position.Y + Main.rand.Next(-75, 76));
                            int dustID = Dust.NewDust(randpos, 16, 16, 64, 0f, 0f, 0, Color.Yellow, 2.4f);
                            Main.dust[dustID].noGravity = true;
                        }

                        npc.ai[0] = 0;
                    }

                    if (shouldCharge)
                    {
                        float speed = 8f;
                        Vector2 move = player.Center - npc.Center;
                        float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                        if (magnitude > speed)
                        {
                            move *= speed / magnitude;
                        }
                        npc.velocity = move;
                    }

                    npc.ai[1]--;

                    if (npc.ai[1] < -150f && npc.ai[1] >= -400f)
                    {
                        shouldTeleport = true;
                    }
                    else if (npc.ai[1] < -400f && npc.ai[1] >= -800f)
                    {
                        shouldTeleport = false;
                        shouldCharge = true;
                    } 
                    else if (npc.ai[1] < -800f)
                    {
                        shouldCharge = false;
                        npc.ai[1] = 250f;
                    }

                    if (npc.life <= 75000 && spawnTwins == true)
                    {
                        int npcID = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, "Vanilla:Spazmatism", 0);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 35, "Vanilla:Retinazer", 0);
                        Main.NewText("Go my minions, attack him!", 255, 40, 150);
                        spawnTwins = false;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                    }
                } 
                else
                {
                    float subit = (float)Math.PI / 2f;
                    Player player = GetPlayer(npc);

                    Vector2 distance = player.Center - npc.Center;
                    float angle = (float)Math.Atan2(distance.Y, distance.X);
                    npc.rotation = angle - subit;

                    if (npc.ai[0] < -60f)
                    {
                        int num1 = Main.rand.Next(2);

                        for (int q = 0; q < 45; q++)
                        {
                            Vector2 randpos = new Vector2(npc.position.X + Main.rand.Next(-75, 76), npc.position.Y + Main.rand.Next(-75, 76));
                            int dustID = Dust.NewDust(randpos, 16, 16, 64, 0f, 0f, 0, Color.Yellow, 2.4f);
                            Main.dust[dustID].noGravity = true;
                        }

                        if (num1 == 0)
                        {
                            npc.position = new Vector2(player.Center.X + (float)Main.rand.Next(150, 550), player.Center.Y - (float)Main.rand.Next(150, 550));
                        }
                        else if (num1 == 1)
                        {
                            npc.position = new Vector2(player.Center.X - (float)Main.rand.Next(150, 550), player.Center.Y - (float)Main.rand.Next(150, 550));
                        }

                        for (int r = 0; r < 30; r++)
                        {
                            Vector2 randpos = new Vector2(npc.position.X + Main.rand.Next(-75, 76), npc.position.Y + Main.rand.Next(-75, 76));
                            int dustID = Dust.NewDust(randpos, 16, 16, 64, 0f, 0f, 0, Color.Yellow, 2.4f);
                            Main.dust[dustID].noGravity = true;
                        }

                        npc.ai[0] = 0;
                    }

                    npc.ai[0]--;
                }
            }
        }
        public override void SetupLootRules(NPC unused)
        {
            bool flag = LootRule.settingUp;
            LootRule.settingUp = true;
            LootRule[] rules = new LootRule[6];
            rules[0] = new LootRule(null).Item("Greater Healing Potion").Stack(5, 30);
            rules[1] = new LootRule(null).Times((NPC npc) => 5 + Main.rand.Next(5)).Item("Heart");
            rules[2] = new LootRule(null).Item("Notch:Soulofdestruction").Stack(20, 40);
            rules[3] = new LootRule(null).Weighted(true).LootRules(new LootRule[]
			{
				new LootRule(null).Item("Soul of Night").Stack(60, 80),
				new LootRule(null).Item("Notch:OcramiteOre").Stack(60, 80)
			});
            rules[4] = new LootRule(null).Code(delegate(NPC npc)
            {
                LootRule.DownedBossMessage(npc.displayName + " " + Lang.misc[17], 50, 150, 200);
            });
            rules[5] = new LootRule(null).Rules(new Func<NPC, bool>[] { (NPC npc) => Main.netMode != 1 }).Code(delegate(NPC npc)
            {
                NotchWorld.GenOcramite();
                spawnTwins = true;
            });
            LootRule.AddFor("Notch:EyeOfApocalypse", rules);
            LootRule.settingUp = flag;
        }
    }
}