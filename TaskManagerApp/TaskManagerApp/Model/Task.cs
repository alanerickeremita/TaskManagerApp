using SQLite;
using System;

namespace TaskManagerApp.Model
{
  public class Task
  {
    #region Parameters
    [PrimaryKey, AutoIncrement]
    public int IdTask { get; set; }

    [MaxLength(50)]
    public string Description { get; set; }

    [MaxLength(50)]
    public string Local { get; set; }

    public string Time { get; set; }
    public DateTime Date { get; set; }

    [MaxLength(50)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string TimeSendEmail { get; set; }
    #endregion
  }
}