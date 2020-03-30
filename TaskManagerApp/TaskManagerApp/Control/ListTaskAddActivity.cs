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
using TaskManagerApp.DataBase;
using TaskManagerApp.Model;

namespace TaskManagerApp.View
{
  [Activity(Label = "@string/task_insert")]
  public class ListTaskAddActivity : Activity
  {
    EditText get_task, get_local, get_time, get_date;
    Button btn_insert, btn_back;
    DataBaseConfig dataBase;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      dataBase = new DataBaseConfig();
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.ListTaskAdd);

      btn_insert = FindViewById<Button>(Resource.Id.btn_insertAdd);
      btn_back = FindViewById<Button>(Resource.Id.bt_backAdd);

      #region Texts
      get_task = (EditText)FindViewById(Resource.Id.editTask);
      get_local = (EditText)FindViewById(Resource.Id.editLocal);
      get_time = (EditText)FindViewById(Resource.Id.editTime);
      get_date = (EditText)FindViewById(Resource.Id.editDate);
      #endregion

      #region Events
      btn_insert.Click += delegate
      {
        try
        {
          Task task = new Task();
          task.Description = get_task.Text.ToString();
          task.Local = get_local.Text.ToString();
          task.Time = get_time.Text.ToString();
          //task.Date = get_date;

          dataBase.InsertTask(task);
        }
        catch (Exception e)
        {

        }
      };
      btn_back.Click += delegate
      {
        var main = new Intent(this, typeof(MainActivity));
        StartActivity(main);
      };
      #endregion
    }
  }
}