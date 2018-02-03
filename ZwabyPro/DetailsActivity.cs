
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ZwabyPro
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            this.SetContentView(Resource.Layout.Details);

            var text1 = FindViewById<TextView>(Resource.Id.textView1);
            text1.Text = this.Intent.GetStringExtra("Name");

            var text2 = FindViewById<TextView>(Resource.Id.textView2);
            text2.Text = this.Intent.GetStringExtra("Specialty");
        }
    }
}
