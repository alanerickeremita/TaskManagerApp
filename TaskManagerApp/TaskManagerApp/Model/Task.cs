using SQLite;
using System;

namespace TaskManagerApp.Model
{
  public class Task
  {
    #region Parameters
    [PrimaryKey, AutoIncrement]
    public int IdTask { get; set; }

    public string Description { get; set; }
    public string Local { get; set; }
    public DateTime Date { get; set; }
    #endregion
  }
}