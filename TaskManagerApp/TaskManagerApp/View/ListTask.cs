﻿using System;
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
  [Activity(Label = "@string/list_task")]
  public class ListTask : Activity
  {
    Button btn_back;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      SetContentView(Resource.Layout.ListTaskLayout);
      //btn_back = FindViewById<Button>();
    }
  }
}