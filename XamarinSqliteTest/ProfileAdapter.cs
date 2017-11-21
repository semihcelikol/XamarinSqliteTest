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
using XamarinSqliteTest.Model;

namespace XamarinSqliteTest
{
    class ProfileAdapter:BaseAdapter
    {
        private Activity context;
        private int[] id;
        private string[] name;
        private string[] surname;
        private string[] email;

        public ProfileAdapter(Activity context, List<Profile> profile)
        {
            this.context = context;
            this.id = profile.Select(x => x.Id).ToArray();
            this.name = profile.Select(x => x.Name).ToArray();
            this.surname = profile.Select(x => x.Surname).ToArray();
            this.email = profile.Select(x => x.Email).ToArray();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Profile bilgilerini göstereceğimiz layotu burada belirtiyoruz.
            var view = context.LayoutInflater.Inflate(Resource.Layout.ProfileLayout, parent, false);

            // + Ekrandaki objeler çekilir, yani ProfileLayout.xaml dosyamızda ki objeler.
            TextView txtName = (TextView)view.FindViewById(Resource.Id.txtName);
            TextView txtSurname = (TextView)view.FindViewById(Resource.Id.txtSurname);
            TextView txtEmail = (TextView)view.FindViewById(Resource.Id.txtEmail);
            // -

            // + Veriler atanır.
            txtName.Text = this.name[position];
            txtSurname.Text = this.surname[position];
            txtEmail.Text = this.email[position];
            // -

            return view;
        }

        public override int Count
        {
            get
            {
                return id.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return id[position];
        }
    }
}