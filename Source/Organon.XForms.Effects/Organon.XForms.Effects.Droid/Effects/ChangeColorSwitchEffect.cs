using System;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Widget;
using Organon.XForms.Effects.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;
using Switch = Android.Widget.Switch;

[assembly: ExportEffect(typeof(ChangeColorSwitchEffect), nameof(ChangeColorSwitchEffect))]
namespace Organon.XForms.Effects.Droid.Effects
{
    /// <summary>
    /// http://stackoverflow.com/questions/11253512/change-on-color-of-a-switch
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChangeColorSwitchEffect : PlatformEffect
    {
        private string _trueColor;
        private string _falseColor;

        protected override void OnAttached()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                _trueColor = (string)Element.GetValue(ChangeColorEffect.TrueColorProperty);
                _falseColor = (string)Element.GetValue(ChangeColorEffect.FalseColorProperty);

                ((SwitchCompat)Control).CheckedChange += OnCheckedChange;

                //Supported formats for Parse are: #RRGGBB #AARRGGBB 'red', 'blue', 'green', 'black', 'white', 'gray', 'cyan', 'magenta', 'yellow', 'lightgray', 'darkgray' 
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(Android.Graphics.Color.ParseColor(_falseColor), PorterDuff.Mode.Multiply);
            }

            //TODO: Glenn - From lollipop mr1 you can also use the TintList instead of working with events... not sure what the best approach is
            //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.LollipopMr1)
            //{
            //    ColorStateList buttonStates = new ColorStateList(new int[][]
            //        {
            //            new int[] {Android.Resource.Attribute.StateChecked},
            //            new int[] {-Android.Resource.Attribute.StateEnabled},
            //            new int[] {}
            //        },
            //        new int[]
            //        {
            //            Android.Graphics.Color.Red,
            //            Android.Graphics.Color.Blue,
            //            Android.Graphics.Color.Green
            //        }
            //    );

            //    ((SwitchCompat)Control).ThumbDrawable.SetTintList(buttonStates);
            //}
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs checkedChangeEventArgs)
        {
            if (checkedChangeEventArgs.IsChecked)
            {
                ((SwitchCompat) Control).ThumbDrawable.SetColorFilter(Android.Graphics.Color.ParseColor(_trueColor), PorterDuff.Mode.Multiply);
                //((SwitchCompat) Control).TrackDrawable.SetColorFilter(Android.Graphics.Color.Green, PorterDuff.Mode.Multiply);
            }
            else
            {
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(Android.Graphics.Color.ParseColor(_falseColor), PorterDuff.Mode.Multiply);
                //((SwitchCompat)Control).TrackDrawable.SetColorFilter(Android.Graphics.Color.Green, PorterDuff.Mode.Multiply);
            }
        }

        protected override void OnDetached()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean && Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.LollipopMr1)
            {
                ((Switch)Control).CheckedChange -= OnCheckedChange;
            }
        }
    }
}