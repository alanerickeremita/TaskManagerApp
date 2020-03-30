using Android.Util;
using SQLite;
using System;
using System.Collections.Generic;
using TaskManagerApp.Model;


namespace TaskManagerApp.DataBase
{
  public class DataBaseConfig : IDataBase
  {
    //Diretorio
    private string _path;

    public DataBaseConfig()
    {
      CheckInitDataBase();
    }

    public string PathSqLite
    {
      get
      {
        if (string.IsNullOrEmpty(_path))
        {
          _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
        return _path;
      }
    }


    //Inicializa o banco de dados
    public bool CheckInitDataBase()
    {
      try
      {
        //Conexao com serviço do banco de dados
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
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

    //Insere tarefas na tabela
    public bool InsertTask(Task task)
    {
      try
      {
        //Conexao com serviço do banco de dados
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
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

    //Retorna Tabela como uma lista de objetos
    public List<Task> GetListTasks()
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
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

    //Atualiza Tabela de Tarefas
    public bool UpdateTask(Task task)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
        {
          connection.Query<Task>("UPDATE Task SET IdTask=?, Description=?, Local=?, Time=?, Date=?", task.IdTask, task.Description, task.Local, task.Time, task.Date);
          return true;
        }
      }
      catch (SQLiteException e)
      {
        Log.Info($"Não foi possível atualizar a tarefa. {System.Environment.NewLine}Erro: ", e.Message);
        return false;
      }
    }

    //Exclui determinada tarefa
    public bool DeleteTask(Task task)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
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

    //Recebe uma determinada tarefa
    public bool GetTask(int idTask)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(PathSqLite, "Task.db")))
        {
          connection.Query<Task>("SELECT * FROM Aluno Where IdTask=?", idTask); ;
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