using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace Notch.Projectiles
{ 
   public class Wave : ModProjectile
   {
	   public override void AI()
	   {
		   projectile.type = 45;           
       }
	   public override void DealtNPC(NPC n, int hitDir, int dmgDealt, float knockback, bool crit)
       {
           n.AddBuff(31, 3000);
       }
   }
}