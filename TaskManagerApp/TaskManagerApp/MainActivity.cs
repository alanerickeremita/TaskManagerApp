using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using TaskManagerApp.View;

namespace TaskManagerApp
{
  [Activity(Label = "@string/app_name", MainLauncher = true)]
  public class MainActivity : Activity
  {
    Button btn_list, btn_insert, btn_exit, btn_send;
    EditText get_email;
   
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      SetContentView(Resource.Layout.Main);

      //Get Text to use in ws that send-emails
      get_email = FindViewById<EditText>(Resource.Id.txt_emailAddress);

      #region Buttons
      btn_list = FindViewById<Button>(Resource.Id.btn_listM);
      btn_exit = FindViewById<Button>(Resource.Id.btn_exit);
      btn_insert = FindViewById<Button>(Resource.Id.btn_insertM);
      btn_send = FindViewById<Button>(Resource.Id.btn_send);
      #endregion

      #region Events
      btn_list.Click += delegate
      {
        var listTask = new Intent(this, typeof(ListTaskActivity));
        StartActivity(listTask);
      };

      btn_insert.Click += delegate
      {
        var listTaskAdd = new Intent(this, typeof(ListTaskAddActivity));
        StartActivity(listTaskAdd);
      };

      btn_exit.Click += delegate
      {
        this.FinishAffinity();
      };
      #endregion
    }
  }
}