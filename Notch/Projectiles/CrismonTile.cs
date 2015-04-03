using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace Notch.Projectiles
{
    public class CrismonTile : ModProjectile
    {
        public override void AI()
        {
			projectile.type = 16;
            int x = (int)(projectile.position.X / 16f);
            int y = (int)(projectile.position.Y / 16f);
            int range = 5;
            for (int j = x - range; j <= x + range; j++) //issue with for
            {
                for (int k = y - range; k <= y + range; k++) //issue with for
                {
                    if (Main.tile[x, y].type == 2) //Grass id // issue with .type
                    {
                        Main.tile[x, y].type = 199; //cismon grass id
                        WorldGen.SquareTileFrame(x, y, true);
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                    if (Main.tile[x, y].type == 1) //stone id
                    {
                        Main.tile[x, y].type = 203; //crimstond id
                        WorldGen.SquareTileFrame(x, y, true);
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                    if (Main.tile[x, y].type == 53) //sand id
                    {
                        Main.tile[x, y].type = 234; //crimsand id
                        WorldGen.SquareTileFrame(x, y, true);
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                    if (Main.tile[x, y].type == 161) //ice id
                    {
                        Main.tile[x, y].type = 200; //red ice id
                        WorldGen.SquareTileFrame(x, y, true);
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                }
            }
        }
    }
}