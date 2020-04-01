using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using TaskManagerApp.Control;
using TaskManagerApp.DataBase;
using TaskManagerApp.View;

namespace TaskManagerApp
{
  [Activity(Label = "@string/app_name", MainLauncher = true)]
  public class MainActivity : Activity
  {
    Button btn_list, btn_insert, btn_exit, btn_send, btn_service;
    DataBaseConfig dataBaseConfig;
    EditText get_email;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      SetContentView(Resource.Layout.Main);

      dataBaseConfig = new DataBaseConfig();

      get_email = FindViewById<EditText>(Resource.Id.txt_emailAddress);

      #region Buttons
      btn_list = FindViewById<Button>(Resource.Id.btn_listM);
      btn_exit = FindViewById<Button>(Resource.Id.btn_exit);
      btn_insert = FindViewById<Button>(Resource.Id.btn_insertM);
      btn_send = FindViewById<Button>(Resource.Id.btn_send);
      btn_service = FindViewById<Button>(Resource.Id.btn_service);
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

      btn_send.Click += Btn_send_Click;

      btn_service.Click += delegate
      {
        var serviceActivity = new Intent(this, typeof(ServiceActivity));
        StartActivity(serviceActivity);
      };
      #endregion
    }

    private void Btn_send_Click(object sender, EventArgs e)
    {
      Intent email = new Intent(Intent.ActionSend);

      email.PutExtra(Intent.ExtraEmail, new string[] { get_email.Text.ToString() });
      email.PutExtra(Intent.ExtraSubject, "Registered Tasks");

      List<string> listTasks = new List<string>();

      var getTasks = dataBaseConfig.GetListTasks();

      foreach (var task in getTasks)
      {
        listTasks.Add(task.Description);
      }

      email.PutExtra(Intent.ExtraText, string.Join(System.Environment.NewLine, listTasks));
      email.SetType("message/rfc822");

      StartActivity(Intent.CreateChooser(email, "Enviar email: "));
    }

  }
}