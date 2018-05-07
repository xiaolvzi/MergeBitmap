using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace App29
{
    [Activity(Label = "App29", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Rect mSrcRect, mDestRect;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //your background picture ---markImageImageView
            Bitmap background = BitmapFactory.DecodeResource(Resources, Resource.Drawable.pause);
            //your foreground picture ---FingerPaintCanvasView
            Bitmap foreground = BitmapFactory.DecodeResource(Resources, Resource.Drawable.play);

            Paint p = new Paint();
            p.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcOver));

            //use background to create a canvas
            Bitmap workingBitmap = Bitmap.CreateBitmap(background);
            Bitmap mutableBitmap = workingBitmap.Copy(Bitmap.Config.Argb4444, true);
            Canvas c = new Canvas(mutableBitmap);

            int mBWith = background.Width;
            int mBHeight = background.Height;

            int mFWith = foreground.Width;
            int mFHeight = foreground.Height;
            mSrcRect = new Rect(0, 0, mBWith, mBHeight);
            mDestRect = new Rect(0, 0, mFWith, mFHeight);

            //draw foreground on the backaground, then they will be single bitmap
            c.DrawBitmap(foreground, mSrcRect, mDestRect, p);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.iv);
            imageView.SetImageBitmap(mutableBitmap);
        }
    }
}

