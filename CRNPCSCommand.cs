using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace CRNPCS
{
    public class CRNPCSCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "timer";

        public override string Usage => "/timer";

        public override string Description => "Tells you how much time is left before a random npc spawns in";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            int TimeLeft = Config.Instance.spawnCooldown * 60 - ModContent.GetInstance<CRNPCSsystem>().spawnerCounter;

            ModContent.GetInstance<CRNPCSsystem>().Talk(LocalizationLoader.GetOrCreateTranslation("$Mods.CRNPCS.Chat.CommandBefore") +TimeLeft.ToString() + LocalizationLoader.GetOrCreateTranslation("$Mods.CRNPCS.Chat.CommandAfter"), Color.OrangeRed);
        }
    }
}
