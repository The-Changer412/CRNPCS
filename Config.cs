using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CRNPCS
{
    [Label("$Mods.CRNPCS.Config.Label")]
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        // Automatically set by tModLoader
        public static Config Instance;

        [Header("$Mods.CRNPCS.Config.Header.GeneralOptions")]

        [Label("$Mods.CRNPCS.Config.SpawnCooldown.Label")]
        [Tooltip("$Mods.CRNPCS.Config.SpawnCooldown.Tooltip")]
        [DefaultValue(60)]
        public int spawnCooldown;
    }
}