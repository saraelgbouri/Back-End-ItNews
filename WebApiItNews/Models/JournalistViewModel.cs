using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiItNews.Models
{
    public class JournalistViewModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Image { get; set; }
        public int NombrArticle { get; set; }
        public List<ArticleModel> articles { get; set; }
    }
}