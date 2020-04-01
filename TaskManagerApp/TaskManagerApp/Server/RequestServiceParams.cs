using Newtonsoft.Json;
using System;

namespace TaskManagerApp.Server
{
  public class RequestServiceParams
  {
    #region Parameters
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
   
    //Instancia do body da requisicao, que contém seu conteúdo 
    [JsonProperty("body")]
    public string Content { get; set; }
    #endregion

    /// <summary>
    /// Sobreescrita do método ToString para configuação do JSON
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      string newToString = string.Format($"Post Id: {Id} {Environment.NewLine} Title: {Title} {Environment.NewLine} Body: {Content}");

      return newToString;
    }
  }
}