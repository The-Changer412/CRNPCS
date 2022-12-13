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
				Main.NewText("spawn me in");
				Main.NewText(Main.time);
				spawnCounter = 0;
			}
		}
	}
}