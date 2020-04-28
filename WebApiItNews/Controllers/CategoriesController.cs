using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiItNews.Data;
using WebApiItNews.Models;

namespace WebApiItNews.Controllers
{
    public class CategoriesController : ApiController
    {
        private NewsEntities db = new NewsEntities();

        // GET: api/Categories
        public IHttpActionResult GetCat()
        {
            var cats = db.Categorie.ToList();
            var catsModel = new List<CatModel>();
            foreach(var c in cats)
            {
                var catModel = new CatModel 
                {
                    ID=c.ID,
                    Titre=c.Titre,
                };
                catsModel.Add(catModel);
            }
            return Ok(catsModel);
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            CategorieModel categorieModel = new CategorieModel();
            categorieModel.ID = categorie.ID;
            categorieModel.Titre = categorie.Titre;
            List<ViewArticleJournalist> viewArticleJournalists = new List<ViewArticleJournalist>();
            foreach (var a in categorie.Article)
            {
                ViewArticleJournalist article = new ViewArticleJournalist();
                article.ID = a.ID;
                article.Titre = a.Titre;
                article.body = a.Body;
                article.Date = a.Date;
                article.img = a.Img;
                article.Journalistes = a.Journalistes.Nom;
                article.Categorie = a.CategorieID;
                
                viewArticleJournalists.Add(article);
            }
            categorieModel.Article = viewArticleJournalists;
            return Ok(categorieModel);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.ID)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorie.Add(categorie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categorie.ID }, categorie);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categorie.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categorie.Count(e => e.ID == id) > 0;
        }
    }
}