using HarmonyLib;
using Nick;

namespace NickJukeboxMod.Patches
{

    [HarmonyPatch(typeof(Nick.Unlocks.UnlocksSystem), "IsUnlocked")]
    class Unlocks
    {

        static bool Prefix(ref bool __result)
        {

            __result = true;

            // Don't Continue to original
            return false;
        }
    }

    [HarmonyPatch(typeof(JukeboxScreen), "MenuOpen")]
    class Jukebox_all
    {

        static bool Prefix(ref MenuSharedState sharedState)
        {

            Plugin.LogInfo($"Changing unlockAll state");
            sharedState.unlockAll = true;

            // Continue to original
            return true;
        }
    }


}
