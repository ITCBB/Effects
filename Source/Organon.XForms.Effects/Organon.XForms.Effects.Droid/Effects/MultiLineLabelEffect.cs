using System.Linq;
using Android.Widget;
using Organon.XForms.Effects.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(MultiLineLabelEffect), nameof(MultiLineLabelEffect))]
namespace Organon.XForms.Effects.Droid.Effects
{
    public class MultiLineLabelEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            TextView control = Control as TextView;

            if (control != null)
            {
                var effect = (XForms.Effects.MultiLineLabelEffect)Element.Effects.FirstOrDefault(item => item is XForms.Effects.MultiLineLabelEffect);
                if (effect != null && effect.Lines > 0)
                {
                    control.SetSingleLine(false);
                    control.SetLines(effect.Lines);
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}