# Popup Resizer

A BepInEx mod for MycoPunk that shrinks item upgrade popups and shifts them for a cleaner HUD.

## Features

- Scales upgrade popups to 50% size
- Repositions popups to the right so they sit better on screen
- Toggleable via config (enabled by default)
- Hot-reloads config while the game is running

## Getting Started

### Dependencies

* MycoPunk (base game)
* [BepInEx](https://github.com/BepInEx/BepInEx) - Version 5.4.2403 or compatible
* .NET Framework 4.8
* [HarmonyLib](https://github.com/pardeike/Harmony) (included via NuGet)

### Building/Compiling

1. Clone this repository
2. Open the solution file in Visual Studio, Rider, or your preferred C# IDE
3. Build the project in Release mode to generate the .dll file

Alternatively, use dotnet CLI:
```bash
dotnet build --configuration Release
```

### Installing

**Via Thunderstore (Recommended)**:
1. Download and install via Thunderstore Mod Manager
2. The mod will be automatically installed to the correct directory

**Manual Installation**:
1. Place the built `PopupResizer.dll` in your `<MycoPunk Directory>/BepInEx/plugins/` folder

### Executing program

The mod loads automatically through BepInEx when the game starts. Check the BepInEx console for loading confirmation messages.

## Configuration

Access mod settings through the BepInEx configuration file at `<MycoPunk Directory>/BepInEx/config/sparroh.popupresizer.cfg`:

- **Resize Item Popups** (`true` by default) — enables smaller, repositioned upgrade popups

Config changes are watched and reloaded automatically while the game is running. Toggle the option, save the file, and the next popup update will reflect the new value (including currently visible popups).

## Help

* **Mod not loading?** Verify BepInEx is installed correctly and check console logs for errors
* **Popups not resizing?** Confirm the config option is enabled and that upgrade popups are actually appearing in-game
* **UI looks wrong with other mods?** Check for conflicts with other HUD/UI mods

## Authors

- Sparroh

## License

This project is licensed under the MIT License - see the LICENSE file for details
