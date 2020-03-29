using Android.App;
using Android.OS;
using Android.Widget;

namespace TaskManagerApp
{
  [Activity(Label = "TaskManagerApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
    EditText _get_task, _get_local, _get_time;
    CalendarView _calendarView;
    Button _bttInserir;


    protected override void OnCreate(Bundle savedInstanceState)
        {
          base.OnCreate(savedInstanceState);
          Xamarin.Essentials.Platform.Init(this, savedInstanceState);
          // Set our view from the "main" layout resource
          SetContentView(Resource.Layout.activity_main);

        }/*
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }*/
    }
}