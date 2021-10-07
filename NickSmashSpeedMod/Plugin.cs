using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;

namespace NickSmashSpeedMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static Plugin Instance;

        static ConfigEntry<float> gravity;
        static ConfigEntry<float> di;
        static ConfigEntry<float> gamespeed;

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
            gravity = config.Bind<float>("Physics", "Gravity", 1f);
            di = config.Bind<float>("Physics", "Di", 1f);
            gamespeed = config.Bind<float>("Physics", "Gamespeed", 0.95f);

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
