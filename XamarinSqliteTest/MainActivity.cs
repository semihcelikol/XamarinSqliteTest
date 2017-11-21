using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace XamarinSqliteTest
{
    [Activity(Label = "XamarinSqliteTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Database oluşturulur.
            SQLHelper.ProfileHelper.createDatabase();

            Model.Profile profileRecord = new Model.Profile();
            profileRecord.Name = "Semih";
            profileRecord.Surname = "Çelikol";
            profileRecord.Email = "semihcelikol@outlook.com";

            //Sqlite insert ediyoruz.
            SQLHelper.ProfileHelper.insert(profileRecord);

            //Profile tablosunda ki verileri çekiyoruz.
            List<Model.Profile> listProfile = SQLHelper.ProfileHelper.getProfileAll();

            //Adapteri kullanarak verilerimizi ProfileLayout.axml dosyasında ilgili yerlere yazıyoruz.
            ProfileAdapter profileAdapter = new ProfileAdapter(this, listProfile);

            //Main.axml dosyamızda ki Listview objemizi çekiyoruz.
            ListView mainListView = FindViewById<ListView>(Resource.Id.mainListView);

            //ProfileLayout.axml dosyasında ki verileri main.axml dosyasında ki mainListview objesine atıyoruz.
            mainListView.Adapter = profileAdapter;
        }
    }
}