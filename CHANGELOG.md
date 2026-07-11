# Changelog

## 1.1.0

- Fixed popups not resizing after the first batch (list monitor desync with pooled popups)
- Replaced fragile list polling with a Harmony patch on `UpgradePopup.Update`
- Scale to 50% and shift right by 200px while enabled
- Config hot-reload: edit `sparroh.popupresizer.cfg` in-game and changes apply live

## 1.0.1

- Initial standalone release (split from EnhancedSettings)
- Resize and reposition item upgrade popups
- Config toggle: Resize Item Popups (enabled by default)

1.0.0 (2025-10-16)
Features

    Reduced reward popup size by 50% to decrease screen clutter
    Shifted popup positioning to right side of screen (less obtrusive)
    Automatic monitor and resize system for upgrade reward popups
    F1 debugging key to check current popup count in logs

Tech

    Add MinVer
    Add thunderstore.toml for tcli
    Add LICENSE and CHANGELOG.md
