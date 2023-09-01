<div align="center">   

<h1>PlayerLoopAPI Runner Morpeh plugin</h1>
Plugin for <a href="https://github.com/scellecs/morpeh/tree/stage-2023.1">Morpeh</a> which allows integrate world systems update using <a href="https://github.com/skelitheprogrammer/PlayerLoop-customization-API-Runner-Addon">PlayerLoopAPI.Runner</a>.
</div>

# Features
- Auto lifecycle management by using extension method
- Easy and fast Integration

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
"com.skillitronic.playerloopcustomizationapi.addons.runner.morpehplugin": "https://github.com/skelitheprogrammer/Morpeh-PlayerLoop-Runner-Plugin.git"
```

# Getting Started

## Create world
```c#
using Scellecs.Morpeh;

public class SomeStartup : IDisposable
{
    private World _world;

    public void Init()
    {
        _world = World.Create();
    }
    
    public void Dispose()
    {
        _world.Dispose();
    }
}
```

## Integrate loop
```c#
using Scellecs.Morpeh;
using PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin;

public class SomeStartup : IDisposable
{
    private World _world;

    public void Init()
    {
        _world = World.Create();
        _world.IntegrateLoop();
    }
    
    public void Dispose()
    {
        _world.Dispose();
    }
}
```

## Create your Dream game!

