using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiItNews.Models
{
    public class ViewArticleJournalist
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string Titre { get; set; }
        public string body { get; set; }
        public string img { get; set; }
        public string video { get; set; }
        public string Journalistes { get; set; }
        public int? Categorie { get; set; }
    }
}