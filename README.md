<p align="center">
  <a href="https://www.nuget.org/packages/Lib.Harmony" alt="NuGet Harmony">
    <img src="https://img.shields.io/nuget/v/Lib.Harmony.svg?label=NuGet%20Lib.Harmony&colorB=blue" />
  </a>
  <a href="https://www.nexusmods.com/daggerfallunity/mods/1192" alt="NexusMods Harmony">
    <img src="https://img.shields.io/badge/NexusMods-Harmony-yellow.svg" />
  </a>
</p>

This is an unofficial distribution of the [Lib.Harmony](https://github.com/pardeike/Harmony) library, created as an easier way to manage external dependencies for mod projects.

## Installation
This mod should always be at the top of your load order. Any other mod that says it should be at or near the top, should be loaded after this one. This ensures any mods using Harmony that don't add it as an explicit dependency don't cause problems. This mod cannot be used with the android version of Daggerfall Unity.
  
## For Players
You probably don't need this mod if you weren't directed to install it by a mod in your mod list. It is only intended to ensure all mods in a mod list are using the latest version of Harmony to limit conflicts.
  
## For Modders
You should reference the 0Harmony.dll in your project, or preferably use the Lib.Harmony NuGet package. You do not need to include 0Harmony.dll in your final .dfmod. You do not need to - and should not - include 0Harmony.dll in your distributed mod, for instance by trying to place it in the StreamingAssets\Mods or Managed folders. This mod handles the player side for you.
You do need to add "daggerfall.harmony" as a dependency for your mod when building your mod. The resulting ``dfmod.json`` should then add an entry that looks like
```"Dependencies": [
    {
        "Name": "daggerfall.harmony",
        "IsOptional": false,
        "IsPeer": false
    }
]
```
This ensures the game will alert the user to load the Harmony library before your mod.
  
## Version Explanation
The mod version combines the current Harmony version used and adds our build id after it. For instance, ``2.4.2.1`` indicates the Harmony version of ``2.4.2`` and the current Daggerfall.Harmony build id is ``1``.