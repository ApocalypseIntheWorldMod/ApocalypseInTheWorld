using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TAPI;
using Terraria;
namespace Notch.Items.Devarmor
{
  public class Dradoncharm : ModItem
  {
      public override void Effects (Player p)
      {
	      p.magicDamage += 60;
		  p.maxMinions += 90;
		  p.thorns = 5000f;
		  p.ghostHeal = true;
		  p.ghostHurt = true;
		  p.fireWalk = true;
		  p.luckMax = 50f;
		  p.magicCuffs = 2000;
		  p.manaMagnet = true;
		  p.statLifeMax2 += 50;
	  }
	  public override void DamageNPC (Player p, NPC n, int hitDir, ref int damage, ref float knockback, ref bool crits, ref float critMult)
	  {
            p.statLife += 70;
      }
   }
}   