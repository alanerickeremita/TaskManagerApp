using Android.App;
using Android.OS;
using Android.Widget;
using System;
using TaskManagerApp.View;

namespace TaskManagerApp
{
  [Activity(Label = "@string/app_name", MainLauncher = true)]
  public class MainActivity : Activity
  {
    Button btn_list, btn_insert, btn_exit;
    GridView gridView;

    private IconLayoutAdapter iconLayoutAdapter;
    private TaskIcon icon;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      SetContentView(Resource.Layout.Main);

      gridView = FindViewById<GridView>(Resource.Id.gridView1);
      iconLayoutAdapter = new IconLayoutAdapter(GetIcon(), this);
      gridView.Adapter = iconLayoutAdapter;

      #region Buttons
      btn_list = FindViewById<Button>(Resource.Id.button2);
      btn_exit = FindViewById<Button>(Resource.Id.button3);
      btn_insert = FindViewById<Button>(Resource.Id.button1);
      #endregion

      #region Events
      btn_list.Click += Btn_list_Click;
      btn_insert.Click += Btn_insert_Click;
      btn_exit.Click += Btn_exit_Click;
      #endregion
    }

    private TaskIcon GetIcon()
    {
      return icon = new TaskIcon("Icone", Resource.Id.imageView1);
    }

    private void Btn_insert_Click(object sender, System.EventArgs e)
    {
      SetContentView(Resource.Layout.ListTaskAdd);
    }

    private void Btn_exit_Click(object sender, System.EventArgs e)
    {
      throw new System.NotImplementedException();
    }

    private void Btn_list_Click(object sender, System.EventArgs e)
    {
      SetContentView(Resource.Layout.ListTaskLayout);
    }
  }
}