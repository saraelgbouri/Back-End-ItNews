using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiItNews.Data;

namespace WebApiItNews.Models
{
    public class CategorieModel
    {
        public int ID { get; set; }
        public string Titre { get; set; }
        public List<ViewArticleJournalist> Article { get; set; }
    }
}