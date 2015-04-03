using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TAPI;
using Terraria;

namespace Notch.Items
{
	public class Apocalypsio : ModItem
	{
		
	
		
		public override bool? UseItem(Player p)
		{
			if(Main.dayTime == true)
			{
				Main.NewText("The apocalypse need to be summon at night", 255, 51, 0);
			}
			if(Main.dayTime == false)
			{
			    Main.NewText("The apocalypse start in the world", 175, 75, 255);
			}
			if(Main.dayTime == false)
			{
			   //int mX = (int) (Main.screenPosition.X + Main.mouseX);
			   //int mY = (int) (Main.screenPosition.Y + Main.mouseY); 
			   int npcID = NPC.NewNPC((int)p.Center.X, (int)p.Center.Y - 500, NPCDef.byName["Notch:EyeOfApocalypse"].type, 0);
			   if (Main.netMode == 2)
				   NetMessage.SendData(23, -1, -1, "", npcID, 0.0f, 0.0f, 0.0f, 0);
		    }
			if(Main.netMode != 2)
			{
				Main.PlaySound(15, (int)p.Center.X, (int)p.Center.Y, 0);
				Vector2 npcPos = p.position - new Vector2(0,200);
				for (int m = 0; m < 15; m++)
				{
				}
			}
			return true;
		}
	}
}