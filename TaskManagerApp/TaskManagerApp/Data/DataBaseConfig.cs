
using Android.Util;
using SQLite;
using System.Collections.Generic;
using TaskManagerApp.Model;


namespace TaskManagerApp.DataBase
{
  public class DataBaseConfig : IDataBase
  {
    //Parametrizacao do caminho do diretório
    private readonly string _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

    public DataBaseConfig()
    {
      CheckInitDataBase();
    }

    /// <summary>
    /// Inicializa o bando de dados e cria uma tabela do tipo Task
    /// </summary>
    /// <returns></returns>
    public bool CheckInitDataBase()
    {
      try
      {
        //Conexao com serviço do banco de dados
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          //Criando a tabela
          connection.CreateTable<Task>();
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível criar a tabela.{System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }

    /// <summary>
    /// Insere uma task no banco de dados
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public bool InsertTask(Task task)
    {
      try
      {
        //Conexao com serviço do banco de dados
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          connection.Insert(task);
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível inserir uma nova tarefa.{System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }

    /// <summary>
    /// Retorna a lista de tabelas cadastradas no banco de dados
    /// </summary>
    /// <returns></returns>
    public List<Task> GetListTasks()
    {
      try
      {
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          return connection.Table<Task>().ToList();
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível retornar a visáo das tarefas. {System.Environment.NewLine}Erro: ", e.Message);
        return null;
      }
    }

    /// <summary>
    /// Atualiza taks no banco de dados
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public bool UpdateTask(Task task)
    {
      try
      {
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          connection.Query<Task>("UPDATE Task SET IdTask = ?, Description = ?, Local = ?, Time = ?, Date = ?", task.IdTask, task.Description, task.Local, task.Time, task.Date);
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível atualizar a tarefa. {System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }

    /// <summary>
    /// Exclui task no banco de dados
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public bool DeleteTask(Task task)
    {
      try
      {
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          connection.Delete(task);
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível apagar a tarefa.{System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }

    /// <summary>
    /// Seleciona uma tarefa através do ID
    /// </summary>
    /// <param name="idTask"></param>
    /// <returns></returns>
    public bool GetTask(int idTask)
    {
      try
      {
        using (SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_path, "Task.db")))
        {
          connection.Query<Task>("SELECT * FROM Aluno Where IdTask = ?", idTask); ;
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível localizar a tarefa.{System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }
  }
}