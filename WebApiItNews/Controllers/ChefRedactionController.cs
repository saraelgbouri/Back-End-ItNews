using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiItNews.Data;
using WebApiItNews.Models;

namespace WebApiItNews.Controllers
{
    public class ChefRedactionController : ApiController
    {
        public IHttpActionResult GetArticles(string status = "")
        {
            var articles = new List<ViewArticleJournalist>();

            //ViewModelJournalist jr = new ViewModelJournalist();

            using (var context = new NewsEntities())
            {
                //var article = context.Article.ToList();

                var article = context.Article.Where(f => f.Status == status).ToList();
                if (article == null)
                {
                    return NotFound();
                }

                foreach (var n in article)
                {
                    ViewArticleJournalist vm = new ViewArticleJournalist();
                    vm.img = n.Img;
                    vm.Titre = n.Titre;
                    vm.body = n.Body;
                    vm.Date = n.Date;
                    vm.Journalistes = n.Journalistes.Nom;
                    articles.Add(vm);
                }
            }
            return Ok(articles);
        }
    }
}
