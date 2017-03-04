### Please post your issues and pull requests on https://github.com/FormsCommunityToolkit/FormsCommunityToolkit, we're migrating all code and samples and closing this repo.

Included effects:

| Effect                     | Description | iOS | Android | UWP |
|----------------------------|-------------|-----|---------|-----|
| **ENTRY** |
| CapitalizeKeyboardEffect | Enforces caps on the keyboard for an Entry | x | x | x |
| ClearEntryEffect | Adds a clear button to an Entry | x | x | - |
| DisableAutoCorrectEffect | Disables auto-correction and entry suggestions from an entry | x | x | - |
| ItalicPlaceholderEffect | Italicizes Placeholder of an Entry | x | Todo? | - |
| RemoveBorderEffect | Removes the border from an Entry on iOS | x | - | x |
| RemoveEntryLineEffect | Removes the underline from an Entry on Android | - | x | - |
| SelectAllTextEntryEffect | Select text in an Entry when receive focus | x | x | x |
| **LABEL** |
| CustomFontEffect | Custom font for a Label | x | x | Todo |
| MultiLineLabelEffect | Limit lines to given amount | x | x | x |
| SizeFontToFitEffect | Shrinks fonts to fit | x | x | Todo |
| **PICKER** |
| ChangeColorPickerEffect | Change colors of picker title | x | x | x |
| **SWITCH** |
| ChangeColorSwitchEffect | Change colors of switch | x | x | Todo |
| **VIEW** |
| ViewBlurEffect | Blur any view | x | Todo | x |

###### iOS

To use this on iOS you need to call

```
Organon.XForms.Effects.iOS.iOSEffects.Init();
```

from your AppDelegate. This ensures the assembly is loaded and the effects are available.

###### Samples iOS

![ClearEntryEffect and CapitalizeKeyboardEffect](Media/ClearEntryAndAllCaps_thumb.gif)

![RemoveBorderEffect](Media/NoBorders_thumb.gif)

![BlurEffect](Media/BlurEffectiOS_thumb.gif)

![SwitchColorEffect](Media/SwitchColorEffectiOS_thumb.gif)

![LabelEffects](Media/LabelEffectsiOS_thumb.png)

###### Samples Android
![Android Effects](Media/AndroidEffects_thumb.gif)

![Android Effects](Media/SwitchColorEffectAndroid_thumb.gif)

![LabelEffects](Media/LabelEffectsAndroid_thumb.png)

###### Samples UWP
![UWP Blur Effect](Media/BlurEffectUWP_thumb.gif)

![UWP Entry Effects](Media/EntryEffectsUWP_thumb.gif)
