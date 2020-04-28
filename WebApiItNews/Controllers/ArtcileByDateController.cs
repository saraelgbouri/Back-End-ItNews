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
    public class ArtcileByDateController : ApiController
    {
        public IHttpActionResult GetArticleByDate()
        {

            FooterArticle Footer = new FooterArticle();
            FooterArticleModel fa1, fa2, fa3;
            using (var context = new NewsEntities())
            {
                var today = DateTime.Now;
                List<ArticleModel> x = new List<ArticleModel>();
                fa1 = new FooterArticleModel();
                var yesterday1 = today.AddDays(-1);
                List<Article> articles = context.Article.Where(f => f.Date.Value.Day == yesterday1.Day).OrderBy(a => a.Date).Take(2).ToList();
                foreach (var A in articles)
                {
                    var article = new ArticleModel();
                    article.ID = A.ID;
                    article.Titre = A.Titre;
                    article.Body = A.Body;
                    article.Img = A.Img;
                    article.Video = A.video;
                    article.Date = A.Date.ToString();

                    x.Add(article);

                }
                fa1.listes = x;
                fa1.Img = context.Article.FirstOrDefault().Img;
                Footer.fam1 = fa1;

                fa2 = new FooterArticleModel();
                List<ArticleModel> y = new List<ArticleModel>();
                var yesterday2 = today.AddDays(-2);
                List<Article> articles1 = context.Article.Where(f => f.Date.Value.Day == yesterday2.Day).OrderBy(a => a.Date).Take(2).ToList();
                foreach (var A in articles1)
                {
                    var article = new ArticleModel();
                    article.ID = A.ID;
                    article.Titre = A.Titre;
                    article.Body = A.Body;
                    article.Img = A.Img;
                    article.Video = A.video;
                    article.Date = A.Date.ToString();
                    y.Add(article);

                    //fa2.listes.Add(article);
                }
                fa2.listes = y;
                fa2.Img = context.Article.FirstOrDefault().Img;
                Footer.fam2 = fa2;

                fa3 = new FooterArticleModel();
                List<ArticleModel> z = new List<ArticleModel>();
                var yesterday3 = today.AddDays(-3);
                List<Article> articles2 = context.Article.Where(f => f.Date.Value.Day == yesterday3.Day).OrderBy(a => a.Date).Take(2).ToList();
                foreach (var A in articles2)
                {
                    var article = new ArticleModel();
                    article.ID = A.ID;
                    article.Titre = A.Titre;
                    article.Body = A.Body;
                    article.Img = A.Img;
                    article.Video = A.video;
                    article.Date = A.Date.ToString();
                    z.Add(article);
                    //fa3.listes.Add(article);
                }
                fa3.listes = z;
                fa3.Img = context.Article.FirstOrDefault().Img;
                Footer.fam3 = fa3;





            }

            return Ok(Footer);
        }
    }
}
