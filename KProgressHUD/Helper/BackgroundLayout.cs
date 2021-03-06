﻿using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace KProgressHUD
{
    public class BackgroundLayout : LinearLayout
    {
        private float mCornerRadius;
        private int mBackgroundColor;

        public BackgroundLayout(Context context)
            : base(context)
        {
            Init();
        }

        public BackgroundLayout(Context context, IAttributeSet attrs)
        : base(context, attrs)
        {
            Init();
        }

        public BackgroundLayout(Context context, IAttributeSet attrs, int defStyleAttr)
        : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            int color = Context.Resources.GetColor(Resource.Color.kprogresshud_default_color);
            InitBackground(color, mCornerRadius);
        }

        private void InitBackground(int color, float cornerRadius)
        {
            GradientDrawable drawable = new GradientDrawable();
            drawable.SetShape(ShapeType.Rectangle);
            drawable.SetColor(color);
            drawable.SetCornerRadius(cornerRadius);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
            {
                Background = (drawable);
            }
            else
            {
                //noinspection deprecation
                SetBackgroundDrawable(drawable);
            }
        }

        public void SetCornerRadius(float radius)
        {
            mCornerRadius = Helper.DpToPixel(radius, Context);
            InitBackground(mBackgroundColor, mCornerRadius);
        }

        public void SetBaseColor(int color)
        {
            mBackgroundColor = color;
            InitBackground(mBackgroundColor, mCornerRadius);
        }
    }
}
