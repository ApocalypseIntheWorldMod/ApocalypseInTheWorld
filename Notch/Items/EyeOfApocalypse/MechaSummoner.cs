using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace Notch.Items
{
    public class MechaSummoner : ModItem
    {
        public override bool? UseItem(Player P)
        {
            if(Main.dayTime)
                    {
                        Main.NewText("The Mecha trio needs to be summoned at night! But watchout of the evil plantera", 255, 51, 0);
                NPC.NewNPC(new Vector2(P.position.X, P.position.Y - 1000), "Vanilla:Plantera");
                return true;
                    }
            if(Main.dayTime == false)
                    {
						Main.NewText("The Mecha trio has been summoned", 255, 0, 135);
                Main.PlaySound(15, (int)P.position.X, (int)P.position.Y );
                NPC.NewNPC(new Vector2(P.position.X, P.position.Y - 1000), "Vanilla:The Destroyer");
                NPC.NewNPC(new Vector2(P.position.X - 1000, P.position.Y - 500), "Vanilla:Retinazer");
                NPC.NewNPC(new Vector2(P.position.X - 1000, P.position.Y - 500), "Vanilla:Spazmatism");
                NPC.NewNPC(new Vector2(P.position.X, P.position.Y - 1000), "Vanilla:Skeletron Prime");
                return true;
            }
            return false;
        }   
        }
}