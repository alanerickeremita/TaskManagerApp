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
      //Instancia das funções do banco de dados
      dataBase = new DataBaseConfig();
      dataBase.CheckInitDataBase();

      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.ListTaskLayout);

      #region Layout Items
      btn_back = FindViewById<Button>(Resource.Id.btn_backList);
      listTaskView = FindViewById<ListView>(Resource.Id.list_taskView);
      #endregion

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

    /// <summary>
    /// Recebe a view que carrega as tareas que serão exibidas
    /// </summary>
    private void GetListView()
    {
      listTask = dataBase.GetListTasks();

      //Adapter que recebe o contexto da activity e a lista de tarefas
      var adapter = new ListTaskAdapter(this, listTask);
      listTaskView.Adapter = adapter;
    }
  }
}