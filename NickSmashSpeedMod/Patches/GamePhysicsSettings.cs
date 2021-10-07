using BepInEx.Configuration;
using HarmonyLib;
using Nick;
using NickSmashSpeedMod;

namespace NickSmashSpeedMod.Patches
{

   



    [HarmonyPatch(typeof(GamePhysicsSettings.Settings), "Copy")]
    class Physics
    {
        static ConfigEntry<float> gravity;
        static ConfigEntry<float> di;
        static ConfigEntry<float> gamespeed;
        static bool Prefix(ref GamePhysicsSettings.Settings s)
        {
            var config = Plugin.Instance.Config;
            if (config.TryGetEntry<float>(new ConfigDefinition("Physics", "Gravity"), out gravity))
            {
                Plugin.LogInfo($"Setting gravity to {gravity.Value}");
                s.gravity = gravity.Value;
            }
            else
            {
                Plugin.LogError($"Could not get config entry for di!");
            }
            if (config.TryGetEntry<float>(new ConfigDefinition("Physics", "Di"), out di))
            {
                Plugin.LogInfo($"Setting gravity to {di.Value}");
                s.di = di.Value;
            }
            else
            {
                Plugin.LogError($"Could not get config entry for di!");
            }
            if (config.TryGetEntry<float>(new ConfigDefinition("Physics", "Gamespeed"), out gamespeed))
            {
                Plugin.LogInfo($"Setting gravity to {gamespeed.Value}");
                s.gamespeed = gamespeed.Value;
            }
            else
            {
                Plugin.LogError($"Could not get config entry for gamespeed!");
            }

            // Continue to original
            return true;
        }
    }



}
