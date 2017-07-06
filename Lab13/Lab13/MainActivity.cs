using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            var ImageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            ImageButton.Click += (s, e) =>
            {
                Validate();
            };
        }

        private async void Validate()
        {
            var client = new SALLab13.ServiceClient();
            string email = "";
            string pass = "";
            var Result = await client.ValidateAsync(this, email, pass);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token})");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();


        }
    }
}

