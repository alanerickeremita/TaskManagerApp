using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TaskManagerApp.Server;

namespace TaskManagerApp.Control
{
  [Activity(Label = "@string/service_act")]
  public class ServiceActivity : Activity
  {
    #region Parameters
    Button btn_backService, btn_send, btn_readJson;
    TextView txt_viewService;
    #endregion

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.Services);

      #region Layout Items
      btn_backService = FindViewById<Button>(Resource.Id.btn_backList);
      btn_send = FindViewById<Button>(Resource.Id.btn_send);
      btn_readJson = FindViewById<Button>(Resource.Id.btn_ReadJson);
      txt_viewService = FindViewById<TextView>(Resource.Id.txt_viewService);
      #endregion

      #region Events
      btn_backService.Click += delegate
      {
        var main = new Intent(this, typeof(MainActivity));
        StartActivity(main);
      };

      //Post Request - Envio de Json
      btn_send.Click += async delegate
      {
        using (HttpClient connection = new HttpClient())
        {
          //Configuração dos Parametros para utilização do serviço de POST 
          RequestServiceParams novoPost = new RequestServiceParams
          {
            UserId = 11,
            Title = "TaskManagerApp - Post",
            Content = "My 1st post with Xamarin Mobile "
          };

          //Converção do objeto novoPost para JSON
          string json = JsonConvert.SerializeObject(novoPost);

          //Encoding do conteúdo do JSON para string assincrona
          StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

          //Configuração para a request
          string uri = "http://jsonplaceholder.typicode.com/posts";

          //Request e StatusCode
          HttpResponseMessage result = await connection.PostAsync(uri, content);
          result.EnsureSuccessStatusCode();

          //Conversao do resultado para uma string assincrona
          string resultString = await result.Content.ReadAsStringAsync();

          //Deserializacao do resultado para um JSON
          RequestServiceParams post = JsonConvert.DeserializeObject<RequestServiceParams>(resultString);

          //Set na view o conteúdo retornado pelo WS
          txt_viewService.Text = post.ToString();
        }
        
      };

      //Get Request - Reposta de Json
      btn_readJson.Click += async delegate
      {
        //Configuracao de GET para receber dados do JSON
        using (HttpClient connection = new HttpClient())
        {
          string uri = "http://jsonplaceholder.typicode.com/posts";
          string result = await connection.GetStringAsync(uri);

          //Lista com as respostas do JSON retornado pela requisição GET
          List<RequestServiceParams> responses = JsonConvert.DeserializeObject<List<RequestServiceParams>>(result);
          
          //Set da resposta
          RequestServiceParams response = responses.First();

          //Set na view o conteúdo retornado pelo WS
          txt_viewService.Text = string.Format($"Primeiro post:{System.Environment.NewLine} {response}");
        }
      };
      #endregion
    }
  }
}