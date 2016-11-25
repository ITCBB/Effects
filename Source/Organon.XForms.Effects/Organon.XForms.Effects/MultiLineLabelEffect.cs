using System.Diagnostics.Contracts;
using Xamarin.Forms;

namespace Organon.XForms.Effects
{
    public class MultiLineLabelEffect : RoutingEffect
    {
        public int Lines { get; set; }

        public MultiLineLabelEffect() : base("Organon.Effects.MultiLineLabelEffect")
        {
        }
    }
}
