using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiItNews.Data;
using WebApiItNews.Models;

namespace EnveronementNews.Controllers
{
    public class ArticlesController : ApiController
    {
        public IHttpActionResult GetArticle()
        {
            var articles = new List<ViewArticleJournalist>();

            //ViewModelJournalist jr = new ViewModelJournalist();

            using (var context = new NewsEntities())
            {
                //var article = context.Article.ToList();
                var status = "posted";
                var article = context.Article.Where(f => f.Status == status).ToList().OrderByDescending(a=>a.Date).Take(8);
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
                    vm.Journalistes= n.Journalistes.Nom;
                    articles.Add(vm);
                }
            }
            return Ok(articles);
        }
        public IHttpActionResult GetArticle(int id)
        {
            ViewArticleJournalist article;
            using (var context = new NewsEntities())
            {
                var A = context.Article.Where(f => f.ID == id).FirstOrDefault();
                if (A == null)
                {
                    return NotFound();
                }
                article = new ViewArticleJournalist();
                article.ID = id;
                article.Titre = A.Titre;
                article.body = A.Body;
                article.img = A.Img;
                article.video = A.video;
                article.Date = A.Date;
                article.Journalistes = A.Journalistes.Nom;
            }
            return Ok(article);
        }
        [ResponseType(typeof(Commentaire))]
        public IHttpActionResult PostArticle(Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new NewsEntities())
            {
                context.Commentaire.Add(commentaire);
                context.SaveChanges();

            }



            return CreatedAtRoute("DefaultApi", new { id = commentaire.ID }, commentaire);
        }




       
    }
}





