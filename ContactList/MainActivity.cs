using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using ContactList.Adapter;
using ContactList.Models;

namespace ContactList
{
    [Activity(Label = "ContactList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Contact> contactList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button
            Button button = FindViewById<Button>(Resource.Id.addButton);

            button.Click += delegate { };

            Initialize();

            var contactListView = FindViewById<ListView>(Resource.Id.contactListView);

            contactListView.Adapter = new ContactListAdapter(contactList, this);
        }

        private void Initialize()
        {
            contactList = new List<Contact>();

            for (int i = 1; i <= 20; i++)
            {
                contactList.Add(new Contact()
                {
                    Name = "My contact " + i,
                    PhoneNumber = i +  "05 987 89" + i,
                    Email = "contact"+i+"@gmail.com"
                });
            }
        }
    }
}

