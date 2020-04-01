using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using TaskManagerApp.Control;
using TaskManagerApp.DataBase;

namespace TaskManagerApp.View
{
  [Activity(Label = "@string/list_task")]
  public class ListTaskActivity : Activity
  {
    #region Parameters
    ListView listTaskView;
    DataBaseConfig dataBase;
    Button btn_back;
    List<Model.Task> listTask;
    #endregion

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      SetContentView(Resource.Layout.ListTaskLayout);
      btn_back = FindViewById<Button>(Resource.Id.btn_backList);
      listTaskView = FindViewById<ListView>(Resource.Id.list_taskView);

      dataBase = new DataBaseConfig();
      dataBase.CheckInitDataBase();

      #region Events
      btn_back.Click += delegate
      {
        var main = new Intent(this, typeof(MainActivity));
        StartActivity(main);
      };
      #endregion

      #region Functions
      GetListView();
      #endregion
    }

    private void GetListView()
    {
      listTask = dataBase.GetListTasks();
      var adapter = new ListTaskAdapter(this, listTask);
      listTaskView.Adapter = adapter;
    }
  }
}