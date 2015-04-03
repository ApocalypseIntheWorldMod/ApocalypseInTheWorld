using System;
using System.Collections.Generic;
using Terraria;
using TAPI;

namespace Notch 
{
    public class NotchWorld : ModWorld
    {
        public override void WorldGenModifyTaskList(List<WorldGenTask> list)
        {
            list.Insert(13, new WorldGenTask.Action("Notch:Apocalypse", delegate
            {
                WorldGenTask.Gen.array5 = new int[Main.maxTilesY];
                WorldGenTask.Gen.array6 = new int[Main.maxTilesY];
                WorldGenTask.Gen.surface = (int)Main.worldSurface;
                WorldGenTask.Gen.rockLayer = 0;
                Main.statusText = "Adding the apocalypse...";
                int num2 = WorldGen.genRand.Next(Main.maxTilesX);
                if (WorldGenTask.Gen.dungeonDir == 1)
                {
                    while ((float)num2 < (float)Main.maxTilesX * 0.55f || (float)num2 > (float)Main.maxTilesX * 0.7f)
                    {
                        num2 = WorldGen.genRand.Next(Main.maxTilesX);
                    }
                }
                else
                {
                    while ((float)num2 < (float)Main.maxTilesX * 0.3f || (float)num2 > (float)Main.maxTilesX * 0.45f)
                    {
                        num2 = WorldGen.genRand.Next(Main.maxTilesX);
                    }
                }
                int num3 = WorldGen.genRand.Next(50, 90);
                float num4 = (float)(Main.maxTilesX / 4200);
                num3 += (int)((float)WorldGen.genRand.Next(20, 40) * num4);
                num3 += (int)((float)WorldGen.genRand.Next(20, 40) * num4);
                int num5 = num2 - num3;
                num3 = WorldGen.genRand.Next(50, 90);
                num3 += (int)((float)WorldGen.genRand.Next(20, 40) * num4);
                num3 += (int)((float)WorldGen.genRand.Next(20, 40) * num4);
                int num6 = num2 + num3;
                if (num5 < 0)
                {
                    num5 = 0;
                }
                if (num6 > Main.maxTilesX)
                {
                    num6 = Main.maxTilesX;
                }
                int num7 = WorldGen.lavaLine - 60;
                for (int i = 0; i < Main.rockLayer; i++)
                {
                    num5 += WorldGen.genRand.Next(-4, 4);
                    num6 += WorldGen.genRand.Next(-3, 5);
                    WorldGenTask.Gen.array5[i] = num5;
                    WorldGenTask.Gen.array6[i] = num6;
                    for (int j = num5; j < num6; j++)
                    {
                        if (i < num7)
                        {
                            num7 += WorldGen.genRand.Next(-2, 3);
                            if (num7 < WorldGen.lavaLine - 140)
                            {
                                num7 = WorldGen.lavaLine - 140;
                            }
                            if (num7 > WorldGen.lavaLine - 100)
                            {
                                num7 = WorldGen.lavaLine - 100;
                            }
                            if (Main.tile[j, i].wall == 2)
                            {
                                Main.tile[j, i].wall = TileDef.wallByName["Notch:ApocalypseWall"];
                            }
                            int type = (int)Main.tile[j, i].type;
                            if (type == 0 || type == 2 || type == 23 || type == 40 || type == 53)
                            {
                                Main.tile[j, i].type = TileDef.byName["Notch:ApocalypseDirt"];
                            }
                            else if (type == 1)
                            {
                                Main.tile[j, i].type = TileDef.byName["Notch:ApocalypseStone"];
                            }
                        }
                        else
                        {
                            num7 += WorldGen.genRand.Next(1, 3);
                        }
                    }
                    if (WorldGenTask.Gen.rockLayer < num7)
                    {
                        WorldGenTask.Gen.rockLayer = num7;
                    }
                }
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.002); k++)
                {
                    int num8 = WorldGen.genRand.Next(1, Main.maxTilesX - 1);
                    int num9 = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)num6);
                    if (num9 >= Main.maxTilesY)
                    {
                        num9 = Main.maxTilesY - 2;
                    }
                    if (Main.tile[num8 - 1, num9].active() && Main.tile[num8 - 1, num9].type == 0 && Main.tile[num8 + 1, num9].active() && Main.tile[num8 + 1, num9].type == 0 && Main.tile[num8, num9 - 1].active() && Main.tile[num8, num9 - 1].type == 0 && Main.tile[num8, num9 + 1].active() && Main.tile[num8, num9 + 1].type == 0)
                    {
                        Main.tile[num8, num9].active(true);
                        Main.tile[num8, num9].type = 2;
                    }
                    num8 = WorldGen.genRand.Next(1, Main.maxTilesX - 1);
                    num9 = WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow);
                    if (num9 >= Main.maxTilesY)
                    {
                        num9 = Main.maxTilesY - 2;
                    }
                    if (Main.tile[num8 - 1, num9].active() && Main.tile[num8 - 1, num9].type == 0 && Main.tile[num8 + 1, num9].active() && Main.tile[num8 + 1, num9].type == 0 && Main.tile[num8, num9 - 1].active() && Main.tile[num8, num9 - 1].type == 0 && Main.tile[num8, num9 + 1].active() && Main.tile[num8, num9 + 1].type == 0)
                    {
                        Main.tile[num8, num9].active(true);
                        Main.tile[num8, num9].type = 2;
                    }
                }
            }));
            list.Insert(19, new WorldGenTask.Action("Notch:ApocDust", delegate
            {
                Main.statusText = "Adding apocalypse dust...";  
                for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0001); i++)     //The first actual thing I've hardcoded myself :D (to do with WorldGen)
                {
                    int num8 = 0;
                    int ii = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int jj = WorldGen.genRand.Next((int)num8, Main.maxTilesY);
                    if (Main.tile[ii, jj].type == TileDef.byName["Notch:ApocalypseDirt"])
                    {
                        WorldGen.TileRunner(ii, jj, (double)WorldGen.genRand.Next(5, 12), WorldGen.genRand.Next(15, 50), TileDef.byName["Notch:ApocalypseDust"], false, 0f, 0f, false, true);
                    }
                }
                for (int j = 0; j < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0005); j++)
                {
                    int num8 = 0;
                    int ii = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int jj = WorldGen.genRand.Next((int)num8, Main.maxTilesY);
                    if (Main.tile[ii, jj].type == TileDef.byName["Notch:ApocalypseDirt"])
                    {
                        WorldGen.TileRunner(ii, jj, (double)WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 5), TileDef.byName["Notch:ApocalypseDust"], false, 0f, 0f, false, true);
                    }
                }
            }));
    }

	public static void GenOcramite()
	{
		if(Main.netMode == 1 || WorldGen.noTileActions || WorldGen.gen)
		{
			return;
		}
		Notch.downedEyeOfApocalypse += 1;
		for(double k = 0; k < (Main.maxTilesX - 200) * (Main.maxTilesY - 150 - (int)Main.rockLayer) / 10000.0 / (double)Notch.downedEyeOfApocalypse; k += 1.0)
		{
			WorldGen.OreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileDef.byName["Notch:OcramiteOre"]);
		}
		NotchNet.NewText("The Soul of The Eye of apocalypse has been fusionning with ore", 100, 210 ,100);
	}
	public override void Save(BinBuffer bb)
    {
        WriteEntry(bb, "downedEyeOfApocalypse", Notch.downedEyeOfApocalypse);

        bb.Write("EOF");
    }

    private void WriteEntry(BinBuffer bb, string tag, bool val)
    {
        bb.Write(tag);
        bb.Write(val);
    }

    private void WriteEntry(BinBuffer bb, string tag, int val)
    {
        bb.Write(tag);
        bb.Write(val);
    }

    public override void Load(BinBuffer bb)
    {
        WrapperDictionary<string, bool> entriesBool = new WrapperDictionary<string, bool>();
        WrapperDictionary<string, int> entriesInt = new WrapperDictionary<string, int>();
        string tag = bb.ReadString();
        while(!tag.Equals("EOF"))
        {
            if(tag.Equals("downedEyeOfApocalypse"))
            {
                entriesInt[tag] = bb.ReadInt();
            }
            else
            {
                entriesBool[tag] = bb.ReadBool();
            }
            tag = bb.ReadString();
        }
        LoadData(entriesInt, "downedEyeOfApocalypse", ref Notch.downedEyeOfApocalypse, 0);
    }

    private void LoadData(WrapperDictionary<string, bool> entries, string tag, ref bool slot, bool default0)
    {
        if(entries.ContainsKey(tag))
        {
            slot = entries[tag];
        }
        else
        {
            slot = default0;
        }
    }

    private void LoadData(WrapperDictionary<string, int> entries, string tag, ref int slot, int default0)
    {
        if(entries.ContainsKey(tag))
        {
            slot = entries[tag];
        }
        else
        {
            slot = default0;
        }
    }
}}

