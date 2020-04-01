
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
    private readonly Activity context;
    private readonly List<Task> tasks;

    public ListTaskAdapter(Activity _context, List<Task> _alunos)
    {
      this.context = _context;
      this.tasks = _alunos;
    }

    public override int Count
    {
      get
      {
        return tasks.Count;
      }
    }

    public override long GetItemId(int position)
    {
      return tasks[position].IdTask;
    }

    public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
    {
      Android.Views.View view = context.LayoutInflater.Inflate(Resource.Layout.ListTaskAdapter, parent, false);

      var txt_getTask = view.FindViewById<TextView>(Resource.Id.txt_task);
      var txt_getLocal = view.FindViewById<TextView>(Resource.Id.txt_local);
      var txt_getDate = view.FindViewById<TextView>(Resource.Id.txt_date);
      var txt_getTime = view.FindViewById<TextView>(Resource.Id.txt_time);

      txt_getTask.Text = tasks[position].Description;
      txt_getLocal.Text = tasks[position].Local;
      txt_getDate.Text = Convert.ToString(tasks[position].Date);
      txt_getTime.Text = tasks[position].Time;

      return view;
    }

    public override Java.Lang.Object GetItem(int position)
    {
      return null;
    }
  }
}