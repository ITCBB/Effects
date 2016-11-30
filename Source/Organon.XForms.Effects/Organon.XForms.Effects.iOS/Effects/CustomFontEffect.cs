using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Organon.XForms.Effects.iOS;
using UIKit;
using System.Linq;

[assembly: ExportEffect (typeof (CustomFontEffect), nameof (CustomFontEffect))]
namespace Organon.XForms.Effects.iOS
{
    public class CustomFontEffect : PlatformEffect
    {
        protected override void OnAttached ()
        {
            var control = Control as UILabel;

            if (control != null) {
                var effect = (XForms.Effects.CustomFontEffect)Element.Effects.FirstOrDefault (item => item is XForms.Effects.CustomFontEffect);
                if (effect != null && !string.IsNullOrWhiteSpace (effect.FontPath)) {
                    control.Font = UIFont.FromName (effect.FontFamilyName, control.Font.PointSize);
                }
            }
        }

        protected override void OnDetached ()
        {
        }
    }
}