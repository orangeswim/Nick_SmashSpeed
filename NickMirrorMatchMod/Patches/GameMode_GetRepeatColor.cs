using HarmonyLib;
using Nick;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using BepInEx.Configuration;

namespace NickMirrorMatchMod.Patches
{
    [HarmonyPatch(typeof(GameMode), "GetRepeatColor")]
    class GameMode_GetRepeatColor
    {
        static ConfigEntry<Color> colorEntry;

        static bool Prefix(int number, ref Color __result)
        {
            var config = Plugin.Instance.Config;

            // Get random color, incase we can't load tint color for somem reason
            Color color = UnityEngine.Random.ColorHSV();
            color.a = 0.66f;
            
            // Try to get color from config, if it exists
            if (config.TryGetEntry<Color>(new ConfigDefinition("Colors", $"TintColor{number}"), out colorEntry))
            {
                Debug.Log($"Setting duplicate {number} to color {colorEntry.Value.ToString()}");
                color = colorEntry.Value;
            }else
            {
                Debug.LogError($"Could not get config entry for value TintColor{number} !");
            }

            __result = color;

            // Skip original function
            return false;
        }
    }
}
