using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace WebApplicationBlog.Models
{
    public class Article
    {
       // [JsonProperty(PropertyName = "totalArticles")]
        public int totalArticles { get; set; }
      //  [JsonProperty(PropertyName = "articles")]
        public List<Articles> articles { get; set; }

    

    }
    public class Articles
    {
        //  [JsonProperty(PropertyName = "title")]
         public string title { get; set; }
     //   [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
      //  [JsonProperty(PropertyName = "content")]
        public string content { get; set; }
      //  [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
     //   [JsonProperty(PropertyName = "image")]
        public string image { get; set; }
     //   [JsonProperty(PropertyName = "publishedAt")]
        public string publishedAt { get; set; }

        public Boolean success { get; set; }
        public  byte estado { get; set; }
    
        //   [JsonProperty(PropertyName = "source")]
        public List<Source> source { get; set; }

      

    }

    public class Source
    {
   //     [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    //    [JsonProperty(PropertyName = "url")]
        public string url { get; set; }

    }
    
}


