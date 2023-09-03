<div align="center">   

<h1>PlayerLoopAPI Runner Morpeh plugin</h1>
Plugin for <a href="https://github.com/scellecs/morpeh/tree/stage-2023.1">Morpeh</a> which allows integrate world systems update using <a href="https://github.com/skelitheprogrammer/PlayerLoop-customization-API-Runner-Addon">PlayerLoopAPI.Runner</a>.
</div>

# Features
- Fully automatic integration With Morpeh.
- Create your game, let [PlayerCustomizationLoopAPI](https://github.com/skelitheprogrammer/PlayerLoopCustomizationAPI). update systems for you
> [!WARNING]
> Plugin depends on [stage-2023.1](https://github.com/scellecs/morpeh/tree/stage-2023.1) version due opened dispose check extension in that version.

# Installation

### Add [Morpeh (stage2023-1)](https://github.com/scellecs/morpeh/tree/stage-2023.1#-how-to-install) to the project

### Add scoped registry to manifest.json
```
"scopedRegistries": [
{
  "name": "package.openupm.com",
  "url": "https://package.openupm.com",
  "scopes": [
    "com.skillitronic.playerloopcustomizationapi",
    "com.skillitronic.playerloopcustomizationapi.addons.runner",
  ]
}
],
```

### Add dependency in manifest.json
```
"com.skillitronic.playerloopcustomizationapi.addons.runner.morpehplugin": "https://github.com/skelitheprogrammer/PlayerLoopCustomizationAPI.Runner.Morpeh-Plugin.git"
```

### Add [Define symbol](https://github.com/skelitheprogrammer/PlayerLoop-customization-API-Runner-Addon#ready-solution)
```
MORPEH_DISABLE_AUTOINITIALIZATION
```
# How it works

1. [Registrar](Runtime/Registrar.cs) creates `PlayerLoopSystem` systems that will be placed inside `PlayerLoop` using [PlayerCustomizationLoopAPI](https://github.com/skelitheprogrammer/PlayerLoopCustomizationAPI).
2. [DispatcherWorldPlugin](Runtime/DispatcherWorldPlugin.cs) register `IWorldPlugin` interface on `[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]` timing.
3. Every new created World will have [PlayerLoopCustomizationAPI.Runner](https://github.com/skelitheprogrammer/PlayerLoopCustomizationAPI.Runner) integration.
