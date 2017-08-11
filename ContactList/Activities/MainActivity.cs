using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using ContactList.Adapter;
using ContactList.Models;
using Newtonsoft.Json;

namespace ContactList.Activities
{
    [Activity(Label = "ContactList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static string NEW_CONTACT_KEY = "NEW_CONTACT_KEY";
        private static int ADD_CONTACT_REQUEST_CODE = 200; 
        private List<Contact> contactList;
        private ContactListAdapter adapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button
            Button button = FindViewById<Button>(Resource.Id.addButton);

            button.Click += delegate
            {
                StartActivityForResult(typeof(AddActivity), ADD_CONTACT_REQUEST_CODE);
            };

            Initialize();

            var contactListView = FindViewById<ListView>(Resource.Id.contactListView);
            adapter = new ContactListAdapter(contactList, this);
            contactListView.Adapter = adapter;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == ADD_CONTACT_REQUEST_CODE && data != null)
            {
                var newContact = JsonConvert.DeserializeObject<Contact>(data.GetStringExtra(NEW_CONTACT_KEY));

                contactList.Add(newContact);
                adapter.NotifyDataSetChanged();
            }
        }

        private void Initialize()
        {
            contactList = new List<Contact>();

            for (int i = 1; i <= 2; i++)
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

