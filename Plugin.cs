using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
[MycoMod(null, ModFlags.IsClientSide)]
public class SparrohPlugin : BaseUnityPlugin
{
    public const string PluginGUID = "sparroh.popupresizer";
    public const string PluginName = "PopupResizer";
    public const string PluginVersion = "1.0.1";

    internal static new ManualLogSource Logger;
    internal static SparrohPlugin Instance { get; set; }

    internal static ConfigEntry<bool> resizePopups;

    private Harmony harmony;
    private FileSystemWatcher configWatcher;
    private volatile bool configReloadPending;
    private float lastReloadTime;

    private void Awake()
    {
        Instance = this;
        Logger = base.Logger;

        resizePopups = Config.Bind(
            "General",
            "Resize Item Popups",
            true,
            "If true, reduces the size of item upgrade popups and repositions them."
        );

        Config.ConfigReloaded += OnConfigReloaded;
        SetupConfigWatcher();

        try
        {
            harmony = new Harmony(PluginGUID);
            harmony.PatchAll(typeof(ResizePopupPatches));
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to apply Harmony patches: {ex.Message}");
        }

        Logger.LogInfo($"{PluginName} loaded successfully.");
    }

    private void Update()
    {
        if (!configReloadPending)
            return;

        // Debounce: Windows often fires Changed twice; also avoid reloading mid-write.
        if (Time.unscaledTime - lastReloadTime < 0.25f)
            return;

        configReloadPending = false;
        lastReloadTime = Time.unscaledTime;

        try
        {
            Config.Reload();
        }
        catch (Exception ex)
        {
            Logger.LogWarning($"Failed to reload config: {ex.Message}");
        }
    }

    private void OnConfigReloaded(object sender, EventArgs e)
    {
        Logger.LogInfo($"Config reloaded. Resize Item Popups = {resizePopups.Value}");
    }

    private void SetupConfigWatcher()
    {
        try
        {
            string configPath = Config.ConfigFilePath;
            string directory = Path.GetDirectoryName(configPath);
            string fileName = Path.GetFileName(configPath);

            if (string.IsNullOrEmpty(directory) || string.IsNullOrEmpty(fileName))
            {
                Logger.LogWarning("Could not set up config file watcher: invalid config path.");
                return;
            }

            configWatcher = new FileSystemWatcher(directory, fileName)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
                EnableRaisingEvents = true
            };

            configWatcher.Changed += OnConfigFileChanged;
            configWatcher.Created += OnConfigFileChanged;
            configWatcher.Renamed += OnConfigFileChanged;

            Logger.LogInfo($"Watching config file for changes: {configPath}");
        }
        catch (Exception ex)
        {
            Logger.LogWarning($"Could not set up config file watcher: {ex.Message}");
        }
    }

    private void OnConfigFileChanged(object sender, FileSystemEventArgs e)
    {
        configReloadPending = true;
    }

    private void OnDestroy()
    {
        Config.ConfigReloaded -= OnConfigReloaded;

        if (configWatcher != null)
        {
            configWatcher.EnableRaisingEvents = false;
            configWatcher.Changed -= OnConfigFileChanged;
            configWatcher.Created -= OnConfigFileChanged;
            configWatcher.Renamed -= OnConfigFileChanged;
            configWatcher.Dispose();
            configWatcher = null;
        }

        try
        {
            harmony?.UnpatchSelf();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error unpatching Harmony: {ex.Message}");
        }
    }
}
