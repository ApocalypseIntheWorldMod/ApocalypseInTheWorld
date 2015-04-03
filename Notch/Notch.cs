using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using TAPI;

namespace Notch
{
    public class Notch : ModBase
    {
        static ModBase mb = new ModBase();
        static Texture2D EmptyTexture;
        static Texture2D ApocBg = mb.textures["Tiles/ApocBg"];
        static Point bg0SzBak;

        public static Biome Apocalypse
        {
            get;
            private set;
        }

        public override void PreGameDraw(SpriteBatch sb)
        {
            base.PreGameDraw(sb);

            if (Main.dedServ || Main.gameMenu)
                return;

            bool dm = Apocalypse.Check(Main.localPlayer);

            if (dm)
            {
                Main.backgroundTexture[0] = ApocBg;

                for (int i = 1; i < Main.backgroundTexture.Length; i++)
                    Main.backgroundTexture[i] = EmptyTexture;

                Main.backgroundWidth[0] = ApocBg.Width;
                Main.backgroundHeight[0] = ApocBg.Height;
            }
        }

		public static int helpText = 0;
		public static int downedEyeOfApocalypse = 0;
        public override void ChooseTrack(ref string current)
        {
            if(Main.gameMenu)
			{
				return;
			}
			if(NPC.AnyNPCs("Notch:EyeOfApocalypse"))
			{
				current = "Vanilla:Music_12";
		}
		}
	}
}