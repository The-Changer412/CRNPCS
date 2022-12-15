using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace CRNPCS
{
	public class CRNPCS : Mod
	{
	}

    public class CRNPCSPlayer: ModPlayer
	{

        int spawnCounter = 0;
		int count = 0;
		public override void PostUpdate()
		{
			count++; 
			if (count % Main.frameRate == 0) {
				spawnCounter++;
            }

			if (spawnCounter >= Config.Instance.spawnCooldown * 60)
			{
				Random rand = new Random();
				int npc = rand.Next(-65, 668);
				NPC.NewNPC(Player.GetSource_NaturalSpawn(), (int)Player.position.X +rand.Next(-5, 5), (int)Player.position.Y + rand.Next(-2, 2), npc);
				spawnCounter = 0;
			}
		}
	}
}