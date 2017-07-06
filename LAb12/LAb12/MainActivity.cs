using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace LAb12
{
    [Activity(Label = "LAb12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string Mail = "";
        string Pass = "";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, Resource.Layout.ListItem, Resource.Id.textView1, 
                Resource.Id.textView2, Resource.Id.imageView1);
            Validate();            
        }

        private async void Validate()
        {
            var ServiceValidation = new SALLab12.ServiceClient();
            var TextResult = FindViewById<TextView>(Resource.Id.ValidarText);
            var Device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceValidation.ValidateAsync(Mail, Pass, Device);
            TextResult.Text = $"{Result.Status}\n{Result.FullName}\n{Result.Token}";
            TextResult.SetTextColor(Color.Aqua);
        }
    }
}

