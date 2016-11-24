using System.Linq;
using Xamarin.Forms;

namespace Organon.XForms.Effects
{
    public static class ChangeColorEffect
    {
        public static readonly BindableProperty FalseColorProperty = BindableProperty.CreateAttached("FalseColor", typeof(string), typeof(ChangeColorEffect), string.Empty, propertyChanged: OnColorChanged);
        public static readonly BindableProperty TrueColorProperty = BindableProperty.CreateAttached("TrueColor", typeof(string), typeof(ChangeColorEffect), string.Empty, propertyChanged: OnColorChanged);

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Switch;
            if (control == null)
                return;

            string color = (string)newValue;

            var attachedEffect = control.Effects.FirstOrDefault(e => e is ChangeColorSwitchEffect);
            if (!string.IsNullOrEmpty(color) && attachedEffect == null)
            {
                control.Effects.Add(new ChangeColorSwitchEffect());
            }
            else if (string.IsNullOrEmpty(color) && attachedEffect != null)
            {
                control.Effects.Remove(attachedEffect);
            }
        }

        public static string GetFalseColor(BindableObject view)
        {
            return (string)view.GetValue(FalseColorProperty);
        }

        public static void SetFalseColor(BindableObject view, string color)
        {
            view.SetValue(FalseColorProperty, color);
        }

        public static string GetTrueColor(BindableObject view)
        {
            return (string)view.GetValue(TrueColorProperty);
        }

        public static void SetTrueColor(BindableObject view, string color)
        {
            view.SetValue(TrueColorProperty, color);
        }

    }

    public class ChangeColorSwitchEffect : RoutingEffect
    {
        public ChangeColorSwitchEffect() : base("Organon.Effects.ChangeColorSwitchEffect")
        {
        }
    }
}
