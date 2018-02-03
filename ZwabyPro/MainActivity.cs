using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ZwabyPro
{
    [Activity(Label = "ZwabyPro", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var mainListView = FindViewById<ListView>(Resource.Id.mainListView);

            mainListView.ItemClick += OnItemClicked;

            mainListView.FastScrollEnabled = true;

            var adapter = new InstructorAdapter(this, InstructorData.Instructors);

            mainListView.Adapter = adapter;
        }

        void OnItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var intent = new Intent(this, typeof(DetailsActivity));

            intent.PutExtra("Name", instructor.Name);
            intent.PutExtra("Specialty", instructor.Specialty);

            StartActivity(intent);
        }
    }
}

