using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TaskManagerApp.View
{
  //Configuração para exibiçao da imagem
  public class TaskIcon
  {
    #region Parameters
    public string Name { get; set; }

    public int Id { get; set; }
    #endregion

    public TaskIcon(string _name, int _id)
    {
      this.Name = _name;
      this.Id = _id;
    }
  }
}