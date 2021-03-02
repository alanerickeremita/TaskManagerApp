using Android.Widget;
using System.Collections.Generic;
using SQLite;
using System.ServiceModel;

namespace TaskManagerApp.Model
{
  //Interface para os métodos de manipulação do banco de dados
  public interface IDataBase 
  {
    public bool CheckInitDataBase();
    public bool InsertTask(Task task);
    public List<Task> GetListTasks(); 
    public bool UpdateTask(Task task);
    public bool DeleteTask(Task task);
    public bool GetTask(int idTask);
  }
}