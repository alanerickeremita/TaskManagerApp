using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using TaskManagerApp.Model;
using TaskManagerApp.Server;

namespace TaskManagerApp.Control
{
  [Activity(Label = "@string/service_act")]
  public class ServiceActivity : Activity
  {
    Button btn_backService, btn_send, btn_readJson;
    TextView txt_viewService;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.Services);

      #region Button
      btn_backService = FindViewById<Button>(Resource.Id.btn_backList);
      btn_send = FindViewById<Button>(Resource.Id.btn_send);
      btn_readJson = FindViewById<Button>(Resource.Id.btn_ReadJson);
      #endregion

      txt_viewService = FindViewById<TextView>(Resource.Id.txt_viewService);

      #region Events
      btn_backService.Click += delegate
      {
        var main = new Intent(this, typeof(MainActivity));
        StartActivity(main);
      };

      btn_send.Click += async delegate
      {
        using (var connection = new HttpClient())
        {
          var novoPost = new PostServiceParams
          {
            UserId = 12,
            Title = "TaskManagerApp - Post",
            Content = "My 1st post with Xamarin Mobile "
          };

          var json = JsonConvert.SerializeObject(novoPost);
          var content = new StringContent(json, Encoding.UTF8, "application/json");

          var uri = "http://jsonplaceholder.typicode.com/posts";
          var result = await connection.PostAsync(uri, content);
          result.EnsureSuccessStatusCode();

          var resultString = await result.Content.ReadAsStringAsync();
          var post = JsonConvert.DeserializeObject<PostServiceParams>(resultString);

          txt_viewService.Text = post.ToString();
        }
        
      };

      btn_readJson.Click += async delegate
      {
        using (var connection = new HttpClient())
        {
          var uri = "http://jsonplaceholder.typicode.com/posts";
          var result = await connection.GetStringAsync(uri);

          var responses = JsonConvert.DeserializeObject<List<PostServiceParams>>(result);

          var response = responses.First();
          txt_viewService.Text = string.Format($"Primeiro post:{System.Environment.NewLine} {response}");
        }
      };
      #endregion
    }
  }
}