using HarmonyLib;
using Nick;

namespace NickJukeboxMod.Patches
{

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
