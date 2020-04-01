using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Util;
using System;
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
      SetContentView(Resource.Layout.ListTaskAdd);

      #region Buttons
      btn_insert = FindViewById<Button>(Resource.Id.btn_insertAdd);
      btn_back = FindViewById<Button>(Resource.Id.bt_backAdd);
      #endregion

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
          task.Date = get_date.Text.ToString();

          dataBase.InsertTask(task);

          var actualActivity = new Intent(this, typeof(ListTaskAddActivity));
          StartActivity(actualActivity);
        }
        catch (Exception e)
        {
          Log.Info($"Não foi possível inserir uma nova tarefa.{System.Environment.NewLine}Erro: ", e.Message);
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