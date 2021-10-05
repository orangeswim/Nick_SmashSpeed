using System;
using BepInEx;
using BepInEx.Configuration;
using Nick;
using System.Collections.Generic;
using HarmonyLib;
using System.Reflection;
using System.IO;
using UnityEngine;
using BepInEx.Logging;

namespace NickMirrorMatchMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static Plugin Instance;
        static ConfigEntry<Color> tintColor1;
        static ConfigEntry<Color> tintColor2;
        static ConfigEntry<Color> tintColor3;

        private void Awake()
        {
            Logger.LogDebug($"Plugin {PluginInfo.PLUGIN_NAME} is loaded!");

            if (Instance)
            {
                DestroyImmediate(this);
                return;
            }
            Instance = this;

            var config = this.Config;
            tintColor1 = config.Bind<Color>("Colors", "TintColor1", new Color(0.51f, 0.27f, 1, 0.66f));
            tintColor2 = config.Bind<Color>("Colors", "TintColor2", new Color(1, 0.93f, 0.23f, 0.66f));
            tintColor3 = config.Bind<Color>("Colors", "TintColor3", new Color(0.16f, 0.95f, 0.82f, 0.66f));

            config.SettingChanged += OnConfigSettingChanged;

            // Harmony patches
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }

        static void OnConfigSettingChanged(object sender, EventArgs args)
        {
            LogDebug($"{PluginInfo.PLUGIN_NAME} OnConfigSettingChanged");
            Plugin.Instance?.Config?.Reload();
        }

        internal static void LogDebug(string message) => Instance.Log(message, LogLevel.Debug);
        internal static void LogInfo(string message) => Instance.Log(message, LogLevel.Info);
        internal static void LogError(string message) => Instance.Log(message, LogLevel.Error);
        private void Log(string message, LogLevel logLevel) => Logger.Log(logLevel, message);
    }
}
