using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APIStudyApp.Models;

namespace APIStudyApp.Controllers
{
    public class LoremTextsController : ApiController
    {
        private APIStudyAppDatabaseEntities db = new APIStudyAppDatabaseEntities();

        // GET: api/LoremTexts
        //public IQueryable<LoremText> GetLoremText()
        //{
        //    return db.LoremText;
        //}
        public IHttpActionResult GetLoremText([FromUri]LoremText loremText)
        {
            if(loremText == null)
            {
                return NotFound();
            }

            string result;
            int maxId = db.LoremText.Max(x => x.numberOfWords);
            
            StringBuilder builder = new StringBuilder();

            if (loremText.numberOfWords == 0 || loremText.numberOfWords > maxId)
            {
                
                for (int i = 1; i <= maxId; i++)
                {
                    loremText = db.LoremText.Where(x => x.numberOfWords == i).SingleOrDefault();
                   
                    builder.Append(loremText.Lorem).Append(" ");
                }
                
                 result = builder.ToString();

                return Ok(result);
            }

            int id = loremText.numberOfWords;
            int rand_num = 0;

            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num= rand.Next(1, maxId);
                
                loremText = db.LoremText.Where(x => x.numberOfWords == rand_num).SingleOrDefault();

                builder.Append(loremText.Lorem).Append(" ");

            }

             result = builder.ToString();

            return Ok(result);
        }
        [Route("api/loremtexts/slow")]
        [HttpGet]
        public IHttpActionResult GetLoremSlow([FromUri]LoremText loremText)
        {
            if (loremText == null)
            {
                return NotFound();
            }

            string result;
            int maxId = db.LoremText.Max(x => x.numberOfWords);

            StringBuilder builder = new StringBuilder();

            System.Threading.Thread.Sleep(5000);

            int id = loremText.numberOfWords;
            int rand_num = 0;

            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.numberOfWords == rand_num).SingleOrDefault();

                builder.Append(loremText.Lorem).Append(" ");

            }

            result = builder.ToString();

            return Ok(result);
        }
        [Route("api/loremtexts/comma")]
        [HttpGet]
        public HttpResponseMessage GetLoremComma()
        {
            LoremTextComma loremText = new LoremTextComma();


            string result;
            int maxId = db.LoremText.Max(x => x.numberOfWords);

            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= maxId; i++)
            {
                loremText = db.LoremTextComma.Where(x => x.numberOfWords == i).SingleOrDefault();
                if(i == maxId)
                    builder.Append(loremText.LoremComma);
                else
                builder.Append(loremText.LoremComma).Append(",");
            }

            result = builder.ToString();
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        [Route("api/loremtexts/animals")]
        [HttpGet]
        public HttpResponseMessage GetAnimal([FromUri]AnimalText animalText)
        {

            AnimalText animals = db.AnimalText.Find(animalText.AnimalId);
            LoremText loremText = new LoremText();
            int maxId = db.LoremText.Max(x => x.numberOfWords);
            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            string animal = animals.AnimalName;
            string description = "*"+animals.AnimalDetails+"*";
            string url = "*" + animals.Url + "*";
            for (int i = 1; i <= maxId; i++)
            {              

                loremText = db.LoremText.Where(x => x.numberOfWords == i).SingleOrDefault();

                builder1.Append(loremText.Lorem).Append(" ");

            }
            string result1 = builder1.ToString();

            builder2.Append(animal).Append(description).Append(result1).Append(url);

            string result2 = builder2.ToString();
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result2, Encoding.UTF8, "text/plain");
            return resp;
        }
        // GET: api/LoremTexts/5
        [ResponseType(typeof(LoremText))]
        public IHttpActionResult GetLoremText(int id)
        {
            LoremText loremText = db.LoremText.Find(id);
            if (loremText == null)
            {
                return NotFound();
            }

            return Ok(loremText);
        }

        // PUT: api/LoremTexts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoremText(int id, LoremText loremText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loremText.numberOfWords)
            {
                return BadRequest();
            }

            db.Entry(loremText).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoremTextExists(id))
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

        // POST: api/LoremTexts
        [ResponseType(typeof(LoremText))]
        public IHttpActionResult PostLoremText(LoremText loremText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoremText.Add(loremText);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoremTextExists(loremText.numberOfWords))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loremText.numberOfWords }, loremText);
        }

        // DELETE: api/LoremTexts/5
        [ResponseType(typeof(LoremText))]
        public IHttpActionResult DeleteLoremText(int id)
        {
            LoremText loremText = db.LoremText.Find(id);
            if (loremText == null)
            {
                return NotFound();
            }

            db.LoremText.Remove(loremText);
            db.SaveChanges();

            return Ok(loremText);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoremTextExists(int id)
        {
            return db.LoremText.Count(e => e.numberOfWords == id) > 0;
        }
    }
}