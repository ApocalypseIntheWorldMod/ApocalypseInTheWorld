using System;
using Microsoft.Xna.Framework;
using Terraria;
using TAPI;

namespace Notch
{
    public class NotchNet : ModNet
    {
        public static void SendNPCData(int npc, int ignore = -1) 
        {
            NetMessage.SendData(23, -1, ignore, "", npc, 0f, 0f, 0f, 0f);
        }
		public static void NewText(string text, byte r, byte g, byte b)
    {
        if(Main.netMode == 0)
        {
            Main.NewText(text, r, g, b, false);
        }
        else if(Main.netMode == 2)
        {
            NetMessage.SendData(25, -1, -1, text, 255, (float)r, (float)g, (float)b, 0f);
        }
    }

        public static void SendNPCLocalData(int npc, int ignore = -1) 
        {
            float[] localAI = Main.npc[npc].localAI;
            NetMessage.SendModData(Mods.GetMod("Notch"), 1, -1, ignore, npc, localAI[0], localAI[1], localAI[2], localAI[3]); 
        }

        public static void SendNPCAllData(int npc, int ignore = -1) 
        {
            SendNPCData(npc, ignore);
            SendNPCLocalData(npc, ignore);
        }

        public override void NetReceive(BinBuffer bb, int messageID, MessageBuffer buffer) 
        {
            switch(messageID)
            {
            case 1: 
                int npc = bb.ReadInt();
                float[] localAI = Main.npc[npc].localAI;
                localAI[0] = bb.ReadFloat();
                localAI[1] = bb.ReadFloat();
                localAI[2] = bb.ReadFloat();
                localAI[3] = bb.ReadFloat();
                if(Main.netMode == 2)
                {
                    SendNPCLocalData(npc, buffer.whoAmI);
                }
                break;
            default:
                break;
            }
        }
    }
}

			    