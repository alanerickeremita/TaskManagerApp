using Android.Widget;
using System.Collections.Generic;
using System.ServiceModel;

namespace TaskManagerApp.Model
{
  //interface para design pattern
  public interface IDataBase 
  {
    public bool CheckInitDataBase();
    public bool InserTask(Task task);
    public List<Task> GetListTasks();
    public bool UpdateTask(Task task);
    public bool DeleteTask(Task task);
    public bool GetTask(int idTask);
  }
}