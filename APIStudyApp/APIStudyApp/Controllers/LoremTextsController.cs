﻿using System;
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
using APIStudyApp.Security;

namespace APIStudyApp.Controllers
{
    /// <summary>
    /// API controller for example testing AJAX med Texter
    /// </summary>
    [Compress]
    [CacheFilter(TimeDuration = 100)]
    public class LoremTextsController : ApiController
    {
        private APIStudyAppDatabaseEntities db = new APIStudyAppDatabaseEntities();

        // GET: api/LoremTexts
        //public IQueryable<LoremText> GetLoremText()
        //{
        //    return db.LoremText;
        //}
       
         /// <summary>
         /// Gets a text with lorem by default and by numberOfWords unique identifier
         /// </summary>
         /// <param name="loremText">Contains an object of loremtext words</param>
         /// <returns>Returns a lorem text or a unique amount of lorem words</returns>
        public HttpResponseMessage GetLoremText([FromUri]LoremText loremText)
        {

            string result;
            int maxId = db.LoremText.Max(x => x.numberOfWords);

            StringBuilder builder = new StringBuilder();

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            if (loremText == null|| loremText.numberOfWords <= 0 || loremText.numberOfWords > maxId)
            {
                //borrowing Loremtext from animaltext column (faster)
                var text = db.AnimalText.Where(x => x.AnimalId == 1).FirstOrDefault();
                result = text.LoremText;
                resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");

                return resp;
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
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        /// <summary>
        /// Gets a text with lorem by default and by numberOfWords unique identifier, it will also wait for 5 secs.
        /// </summary>
        /// <param name="loremText">Contains an object of loremtext words</param>
        /// <returns>Returns a lorem text or a unique amount of lorem words</returns>
        [Route("api/loremtexts/slow")]
        [HttpGet]
        public HttpResponseMessage GetLoremSlow([FromUri]LoremText loremText)
        {
            string result;

            StringBuilder builder = new StringBuilder();

            System.Threading.Thread.Sleep(5000);

            int maxId = db.LoremText.Max(x => x.numberOfWords);
            int rand_num = 0;
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            if (loremText == null || loremText.numberOfWords <= 0 || loremText.numberOfWords > maxId)
            {
             
                
                for (int i = 1; i <= maxId; i++)
                {
                    loremText = db.LoremText.Where(x => x.numberOfWords == i).SingleOrDefault();

                    builder.Append(loremText.Lorem).Append(" ");
                }
                result = builder.ToString();
                resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
                return resp;
            }

            int id = loremText.numberOfWords;
            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.numberOfWords == rand_num).SingleOrDefault();

                builder.Append(loremText.Lorem).Append(" ");

            }

            result = builder.ToString();
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");

            return resp;
        }
        /// <summary>
        /// Gets an object of LoremTextComma where lorem words is separated by commas
        /// </summary>
        /// <returns>Returns a string of lorem words with commas by default</returns>
        [Route("api/loremtexts/comma")]
        [HttpGet]
        public HttpResponseMessage GetLoremComma()
        {
            LoremTextComma loremText = new LoremTextComma();

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
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
          
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
       /// <summary>
       /// Gets an animal object with spefic values
       /// </summary>
       /// <param name="animalText">The object contains properties that represents an animal</param>
       /// <returns>Returns an animal object with specific values</returns>
        [Route("api/loremtexts/animals")]
        [HttpGet]
        public HttpResponseMessage GetAnimal([FromUri]AnimalText animalText)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
          StringBuilder builder = new StringBuilder();

            string animal;
            string description;
            string url;
            string loremText; 

            if (animalText == null)
            {
                 animalText= db.AnimalText.Find(1);

                animal = animalText.AnimalName;
                 description = "*" + animalText.AnimalDetails + "*";
                 url = "*" + animalText.Url + "*";
                 loremText = animalText.LoremText;

                builder.Append(animal).Append(description).Append(loremText).Append(url);

                string result2 = builder.ToString();
                resp.Content = new StringContent(result2, Encoding.UTF8, "text/plain");
                return resp;
              
            }

            AnimalText animals = db.AnimalText.Find(animalText.AnimalId);
            if (animals == null)
            {
                 animalText = db.AnimalText.Find(1);

                animal = animalText.AnimalName;
                description = "*" + animalText.AnimalDetails + "*";
                url = "*" + animalText.Url + "*";
                loremText = animalText.LoremText;

                builder.Append(animal).Append(description).Append(loremText).Append(url);

                string result2 = builder.ToString();
                resp.Content = new StringContent(result2, Encoding.UTF8, "text/plain");
                return resp;

            }
            animal = animals.AnimalName;
             description = "*" + animals.AnimalDetails + "*";
             url = "*" + animals.Url + "*";
             loremText = animals.LoremText;

            builder.Append(animal).Append(description).Append(loremText).Append(url);

            string result = builder.ToString();
        
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        //// GET: api/LoremTexts/5
        //[ResponseType(typeof(LoremText))]
        //public IHttpActionResult GetLoremText(int id)
        //{
        //    LoremText loremText = db.LoremText.Find(id);
        //    if (loremText == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(loremText);
        //}

        // PUT: api/LoremTexts/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutLoremText(int id, LoremText loremText)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != loremText.numberOfWords)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(loremText).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoremTextExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/LoremTexts
        //[ResponseType(typeof(LoremText))]
        //public IHttpActionResult PostLoremText(LoremText loremText)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.LoremText.Add(loremText);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (LoremTextExists(loremText.numberOfWords))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = loremText.numberOfWords }, loremText);
        //}

        //// DELETE: api/LoremTexts/5
        //[ResponseType(typeof(LoremText))]
        //public IHttpActionResult DeleteLoremText(int id)
        //{
        //    LoremText loremText = db.LoremText.Find(id);
        //    if (loremText == null)
        //    {
        //        return NotFound();
        //    }

        //    db.LoremText.Remove(loremText);
        //    db.SaveChanges();

        //    return Ok(loremText);
        //}
        /// <summary>
        /// If out of scope. Disposed activates
        /// </summary>
        /// <param name="disposing">For disposing out of scope operations</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       

    }
}