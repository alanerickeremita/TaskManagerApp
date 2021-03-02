
using Android.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using TaskManagerApp.Model;

namespace TaskManagerApp.Control
{
  [Activity(Label = "@string/list_task")]
  public class ListTaskAdapter : BaseAdapter
  {
    #region Parameters
    private readonly Activity context;
    private readonly List<Task> tasks;
    #endregion

    public ListTaskAdapter(Activity _context, List<Task> _tasks)
    {
      this.context = _context;
      this.tasks = _tasks;
    }

    //Sobrescrita do método Count - para retornar a quantidade de tarefas da lista
    public override int Count
    {
      get
      {
        return tasks.Count;
      }
    }

    /// <summary>
    /// Retorna cada Id dos itens da lista de tarefas
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public override long GetItemId(int position)
    {
      return tasks[position].IdTask;
    }

    /// <summary>
    /// Recebe os parametros necessários para preencher um ListView e retorna através de um LayoutInflate a instancia
    /// das views de cada posicao da lista
    /// </summary>
    /// <param name="position"></param>
    /// <param name="convertView"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
    {
      Android.Views.View view = context.LayoutInflater.Inflate(Resource.Layout.ListTaskAdapter, parent, false);

      #region View parent Items
      var txt_getTask = view.FindViewById<TextView>(Resource.Id.txt_task);
      var txt_getLocal = view.FindViewById<TextView>(Resource.Id.txt_local);
      var txt_getDate = view.FindViewById<TextView>(Resource.Id.txt_date);
      var txt_getTime = view.FindViewById<TextView>(Resource.Id.txt_time);
      #endregion

      #region Filling Parameters
      txt_getTask.Text = tasks[position].Description;
      txt_getLocal.Text = tasks[position].Local;
      txt_getDate.Text = tasks[position].Date;
      txt_getTime.Text = tasks[position].Time;
      #endregion

      return view;
    }

    /// <summary>
    /// Retorna a posição de cada item da lista
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public override Java.Lang.Object GetItem(int position)
    {
      return position;
    }
  }
}