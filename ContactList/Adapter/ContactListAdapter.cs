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
using Java.Lang;
using ContactList.Models;

namespace ContactList.Adapter
{
    public class ContactListAdapter : BaseAdapter<Contact>
    {
        private List<Contact> contacts;
        private Activity parent;

        public ContactListAdapter(List<Contact> contacts, Activity parent)
        {
            this.contacts = contacts;
            this.parent = parent;
        }
        public override Contact this[int position] => contacts[position];

        public override int Count => contacts.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ContactViewHolder viewHolder = null;

            if (convertView == null)
            {
                convertView = this.parent.LayoutInflater.Inflate(Resource.Layout.view_contact, null);

                viewHolder = new ContactViewHolder()
                {
                    NameTextView = convertView.FindViewById<TextView>(Resource.Id.nameTextView),
                    PhoneTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumberTextView),
                    EmailImageView = convertView.FindViewById<ImageView>(Resource.Id.emailImageView),
                    PhoneImageView= convertView.FindViewById<ImageView>(Resource.Id.phoneImageView),
                };

                viewHolder.EmailImageView.Click += EmailImageViewClicked;
                viewHolder.PhoneImageView.Click += PhoneImageViewClicked;

                viewHolder.EmailImageView.Tag = position;
                viewHolder.PhoneImageView.Tag = position;

                convertView.Tag = viewHolder;
            }

            if (viewHolder == null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }
            var contact = contacts[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneTextView.Text = contact.PhoneNumber;

            return convertView;
        }

        private void EmailImageViewClicked(object sender, EventArgs args)
        {
            var contact = contacts[(int) (sender as ImageView).Tag];
            var intent = new Intent(Intent.ActionSend);
            intent.PutExtra(Intent.ExtraEmail, new string[] {contact.Email});

            parent.StartActivity(intent);
        }
        private void PhoneImageViewClicked(object sender, EventArgs args)
        {
            var contact = contacts[(int)(sender as ImageView).Tag];

            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse($"tel:{ contact.PhoneNumber }"));

            parent.StartActivity(intent);
        }
        
    }
}