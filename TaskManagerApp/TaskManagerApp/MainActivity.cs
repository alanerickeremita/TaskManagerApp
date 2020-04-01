using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using TaskManagerApp.Control;
using TaskManagerApp.DataBase;
using TaskManagerApp.View;
using TaskManagerApp.Model;

namespace TaskManagerApp
{
  [Activity(Label = "@string/app_name", MainLauncher = true)]
  public class MainActivity : Activity
  {
    #region Parameters
    Button btn_list, btn_insert, btn_exit, btn_send, btn_service;
    DataBaseConfig dataBaseConfig;
    EditText get_email;
    #endregion

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      SetContentView(Resource.Layout.Main);

      //Instancia das funçoes do banco de dados
      dataBaseConfig = new DataBaseConfig();

      #region Layout Items
      btn_list = FindViewById<Button>(Resource.Id.btn_listM);
      btn_exit = FindViewById<Button>(Resource.Id.btn_exit);
      btn_insert = FindViewById<Button>(Resource.Id.btn_insertM);
      btn_send = FindViewById<Button>(Resource.Id.btn_send);
      btn_service = FindViewById<Button>(Resource.Id.btn_service);
      get_email = FindViewById<EditText>(Resource.Id.txt_emailAddress);
      #endregion

      #region Events
      btn_list.Click += delegate
      {
        var listTask = new Intent(this, typeof(ListTaskActivity));
        StartActivity(listTask);
      };

      btn_insert.Click += delegate
      {
        var listTaskAdd = new Intent(this, typeof(ListTaskAddActivity));
        StartActivity(listTaskAdd);
      };

      btn_exit.Click += delegate
      {
        this.FinishAffinity();
      };

      btn_send.Click += Btn_send_Click;

      btn_service.Click += delegate
      {
        var serviceActivity = new Intent(this, typeof(ServiceActivity));
        StartActivity(serviceActivity);
      };
      #endregion
    }

    //Configuraçao do envio de email
    private void Btn_send_Click(object sender, EventArgs e)
    {
      //Instancia da ActionSend para envio de e-mail
      Intent email = new Intent(Intent.ActionSend);

      //Endereco para envio de email inserido na tela principal
      email.PutExtra(Intent.ExtraEmail, new string[] { get_email.Text.ToString() });

      //Assunto do email
      email.PutExtra(Intent.ExtraSubject, "Tarefas Registradas");

      List<string> listTasks = new List<string>();
      List<Task> getTasks = dataBaseConfig.GetListTasks();

      //Recebimento da descriçao das tasks pra uma lista 
      foreach (Task task in getTasks)
      {
        listTasks.Add(task.Description);
      }

      //Preenchimento do corpo da mensagem com as tasks da lista
      email.PutExtra(Intent.ExtraText, string.Join(System.Environment.NewLine, listTasks));

      //Tipo e envio de email - formato MIME
      email.SetType("message/rfc822");
      StartActivity(Intent.CreateChooser(email, "Enviar email: "));
    }

  }
}