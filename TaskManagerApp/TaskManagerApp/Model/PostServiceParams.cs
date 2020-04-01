using Newtonsoft.Json;
using System;

namespace TaskManagerApp.Model
{
  public class PostServiceParams
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Content { get; set; }

    public override string ToString()
    {
      return string.Format($"Post Id: {Id} {Environment.NewLine} Title: {Title} {Environment.NewLine} Body: {Content}");
    }
  }
}