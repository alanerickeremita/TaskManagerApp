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

namespace TaskManagerApp.View
{
  [Activity(Label = "@string/list_task")]
  public class ListTaskActivity : Activity
  {
    LinearLayout container;
    List<Model.Task> listTask;
    Button btn_back;
    DataBaseConfig dataBase;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      dataBase = new DataBaseConfig();

      SetContentView(Resource.Layout.ListTaskLayout);
      btn_back = FindViewById<Button>(Resource.Id.btn_backList);
      container = FindViewById<LinearLayout>(Resource.Id.container);

      #region Events
      btn_back.Click += delegate
      {
        var main = new Intent(this, typeof(MainActivity));
        StartActivity(main);
      };
      #endregion

      listTask = dataBase.GetListTasks();

      foreach (var task in listTask)
      {
        LayoutInflater layoutInflater = (LayoutInflater)BaseContext.GetSystemService(Context.LayoutInflaterService);
        var newView = layoutInflater.Inflate(Resource.Layout.ListTaskView, null);
        TextView get_task = FindViewById<TextView>(Resource.Id.txt_task);
        TextView get_local = FindViewById<TextView>(Resource.Id.txt_local);
        TextView get_time = FindViewById<TextView>(Resource.Id.txt_time);
        TextView get_date = FindViewById<TextView>(Resource.Id.txt_date);
        get_task.Text = task.Description;
        get_local.Text = task.Local;
        get_time.Text = task.Time;
        //get_date = task.Date;
        container.AddView(newView);
      }
    }
  }
}