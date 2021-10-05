# NASB mirror match recolor mod

This mod will recolor duplicate characters by tinting the original material.

## Installation

*If your game isn't modded with BepinEx, DO THAT FIRST!*
Simply go to the [latest BepinEx release](https://github.com/BepInEx/BepInEx/releases) and extract BepinEx_x64_VERSION.zip directly into your game's folder, then run the game once to install BepinEx properly.

Next, go to the [latest release of this mod](https://github.com/megalon/nick-mirror-match-mod/releases/latest) and place the dll in `BepInEx\plugins`

That's it!

## Configuration

**Run the game once to generate a config file!**

The file will be placed in
`BepInEx\config\megalon.nick_mirror_match_mod.cfg`

Here you can edit the color hex values.
The format is `RRGGBBAA`

* `TintColor1` is for the first duplicate player
* `TintColor2` is the second
* `TintColor3` is the third

```
[Colors]

# Setting type: Color
# Default value: 000000A8
TintColor1 = 000000A8

# Setting type: Color
# Default value: FF0000A8
TintColor2 = FF0000A8

# Setting type: Color
# Default value: 0000FFA8
TintColor3 = 0000FFA8
```
