using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using TAPI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Notch.Items
{ 
   public class Firenami : ModItem
   {
	   public override bool PreShoot(Player player, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	   {
		   int spread = 30;
		   float spreadMult = 0.5f;
           for (int i = 0; i < 4; i++)
		   {
			   float vX = velocity.X+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
			   float vY = velocity.Y+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
			   Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockback, Main.myPlayer);
	       }   
	   return false;
       }
   }
}