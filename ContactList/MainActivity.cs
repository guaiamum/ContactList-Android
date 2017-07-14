using Android.App;
using Android.Widget;
using Android.OS;

namespace ContactList
{
    [Activity(Label = "ContactList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button
            Button button = FindViewById<Button>(Resource.Id.addButton);

            button.Click += delegate { };

            var contactListView = FindViewById<ListView>(Resource.Id.contactListView);

            //contactListView.Adapter = 
        }
    }
}

