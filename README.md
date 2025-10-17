# PopupReducer

A BepInEx mod for MycoPunk that reduces the size and obstructiveness of reward popups during gameplay.

## Description

This client-side mod addresses the screen clutter caused by large reward popups that can obscure gameplay visibility when collecting upgrades. The mod reduces popup size by 50% and repositions them to the right side of the screen, making them much less intrusive while still being visible for progress tracking.

The mod automatically monitors the GameManager.upgradePopups collection and adds resizing/scaling components to new popup instances when they are created. This ensures all reward popups (from upgrades, resources, achievements, etc.) are consistently sized and positioned.

## Getting Started

### Dependencies

* MycoPunk (base game)
* [BepInEx](https://github.com/BepInEx/BepInEx) - Version 5.4.2403 or compatible
* .NET Framework 4.8

### Building/Compiling

1. Clone this repository
2. Open the solution file in Visual Studio, Rider, or your preferred C# IDE
3. Build the project in Release mode

Alternatively, use dotnet CLI:
```bash
dotnet build --configuration Release
```

### Installing

**Option 1: Via Thunderstore (Recommended)**
1. Download and install using the Thunderstore Mod Manager
2. Search for "PopupReducer" under MycoPunk community
3. Install and enable the mod

**Option 2: Manual Installation**
1. Ensure BepInEx is installed for MycoPunk
2. Copy `PopupReducer.dll` from the build folder
3. Place it in `<MycoPunk Game Directory>/BepInEx/plugins/`
4. Launch the game

### Executing program

Once installed, the mod works automatically and affects all reward system popups:

**Visual Changes:**
- **Smaller Popups:** All reward popups are scaled down by 50% (0.5x original size)
- **Repositioned:** Popups appear 200 units to the right of original position
- **Real-Time Application:** New popups are resized immediately when created

**Affected Content:**
- Upgrade rewards and collectible discoveries
- Resource acquisition notifications
- Achievement and progression unlocks
- Any other system-generated reward popups

**Debug Features:**
- Press F1 in-game to log current popup count to BepInEx console
- Use BepInEx console for monitoring popup creation and modifications

## Help

* **Popups still big?** This mod only affects reward popups, not other UI elements like dialogs or menus
* **Position wrong?** The mod repositions popups relative to their original spawned location
* **Not all popups affected?** Some very special popups may use different systems - this covers the main upgrade popup list
* **Performance impact?** Minimal - only monitors popup lists and applies simple scale/position changes
* **Incompatible with mods?** Shouldn't conflict as it targets specific popup GameObjects
* **Want bigger popups?** Disable the mod to restore original size and positioning
* **Debug info?** Press F1 during gameplay to log current popup information to BepInEx console

## Authors

* Sparroh
* funlennysub (original mod template)
* [@DomPizzie](https://twitter.com/dompizzie) (README template)

## License

* This project is licensed under the MIT License - see the LICENSE.md file for details
