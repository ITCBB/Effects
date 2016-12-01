using System.Linq;
using Android.Graphics;
using Android.Widget;
using Organon.XForms.Effects.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect (typeof (CustomFontEffect), nameof (CustomFontEffect))]
namespace Organon.XForms.Effects.Droid
{
    public class CustomFontEffect : PlatformEffect
    {
        protected override void OnAttached ()
        {
            var control = Control as TextView;

            if (control != null) {
                var effect = (XForms.Effects.CustomFontEffect)Element.Effects.FirstOrDefault (item => item is XForms.Effects.CustomFontEffect);
                if (effect != null && !string.IsNullOrWhiteSpace (effect.FontPath)) {

                    var font = Typeface.CreateFromAsset (Forms.Context.Assets, effect.FontPath);
                    control.Typeface = font;
                }
            }
        }

        protected override void OnDetached ()
        {
        }
    }
}