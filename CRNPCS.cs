using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Chat;
using Terraria.Localization;
using System;

namespace CRNPCS
{
	public class CRNPCSsystem : ModSystem
	{
		//set up the variables
		int counter = 0;
		int spawnerCounter = 0;
		int spawnednpc = 0;
		Random random = new Random();

		//function for saying something in the chat
		public void Talk(string message, Color color)
		{
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText(message, color);
			}
			else
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), color);
			}
		}
		//count down the timer till it's time to spawn in a random npc on all players
        public void randomNPCspawner()
        {
            counter++;
            if (counter >= 60)
            {
                spawnerCounter++;
                counter = 0;
            }

            if (spawnerCounter >= Config.Instance.spawnCooldown * 60)
            {
                foreach (Player player in Main.player)
                {
                    if (player.name != "")
                    {
                        int npc = random.Next(-65, 668);
                        int XOffset = random.Next(-50, 50);
                        int YOffset = random.Next(-50, 50);
                        spawnednpc = NPC.NewNPC(player.GetSource_FromThis(), (int)player.position.X + XOffset, (int)player.position.Y + YOffset, npc);
                        Talk(player.name + " Has spawned in a " + Main.npc[spawnednpc].FullName, Color.HotPink);
                    }
                    else
                    {
                        break;
                    }
                    spawnerCounter = 0;
                }
            }
        }

		//spawn in the npcs for the server
		public override void PostUpdateEverything()
        {
			if (Main.netMode!= NetmodeID.SinglePlayer) 
			{
                randomNPCspawner();
            }
			base.PostUpdateEverything();
        }

        //spawn in the npcs for singleplayer
        public override void PostUpdateWorld()
        {
            if (Main.netMode==NetmodeID.SinglePlayer)
            {
                randomNPCspawner();
            }
            base.PostUpdateWorld();
        }
    }
}