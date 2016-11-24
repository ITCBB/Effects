using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Organon.XForms.Effects.Droid.Effects;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Util;

[assembly: ExportEffect(typeof(SizeFontToFitEffect), nameof(SizeFontToFitEffect))]

namespace Organon.XForms.Effects.Droid.Effects
{
    class RefitTextOnLayoutChangeListener : Java.Lang.Object, Android.Views.View.IOnLayoutChangeListener
    {
        private const string TextMeasure = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const double TextHeightScale = 0.9;
        private const float Threshold = 0.5f; // How close we have to be

        private readonly TextView _textView;

        public RefitTextOnLayoutChangeListener(TextView textView) : base()
        {
            _textView = textView;
        }

        public void OnLayoutChange(Android.Views.View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
        {
            if (_textView.Width <= 0 || _textView.Height <= 0)
                return;

            var hi = 200f;
            var lo = 2f;

            var paint = new Paint();
            paint.Set(_textView.Paint);
            var bounds = new Rect();

            while ((hi - lo) > Threshold)
            {
                float size = (hi + lo) / 2;
                paint.TextSize = size;
                paint.GetTextBounds(TextMeasure, 0, TextMeasure.Length, bounds);

                if (paint.MeasureText(_textView.Text) >= _textView.Width || bounds.Height() >= _textView.Height * TextHeightScale)
                    hi = size; // too big
                else
                    lo = size; // too small
            }

            _textView.SetTextSize(ComplexUnitType.Px, lo);
        }
    }

    [Preserve(AllMembers = true)]
    public class SizeFontToFitEffect : PlatformEffect
    {
        private RefitTextOnLayoutChangeListener _listener;

        protected override void OnAttached()
        {
            var textView = Control as TextView;
            if (textView != null)
                textView.AddOnLayoutChangeListener(_listener = new RefitTextOnLayoutChangeListener(textView));
        }

        protected override void OnDetached()
        {
            var textView = Control as TextView;
            if (textView != null)
                textView.RemoveOnLayoutChangeListener(_listener);
        }
    }
}
