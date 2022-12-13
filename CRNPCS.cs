using System;
using Terraria;
using Terraria.ModLoader;

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

			if (spawnCounter >= Config.Instance.spawnCooldown)
			{
				
				Random rand = new Random();\
				int npc = rand.Next(-65, 668);
				NPC.NewNPC(Player.GetSource_NaturalSpawn(), (int)Player.position.X, (int)Player.position.Y, npc);
				spawnCounter = 0;
			}
		}
	}
}