using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/LoremTexts")]
    [DisableCors]
    public class LoremTextsController : Controller
    {
        private APIStudyAppDatabaseContext db = new APIStudyAppDatabaseContext();

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
        [HttpGet]
        public IActionResult GetLoremText([FromQuery]LoremText loremText)
        {

            string result;
            int maxId = db.LoremText.Max(x => x.NumberOfWords);

            StringBuilder builder = new StringBuilder();

            if (loremText == null || loremText.NumberOfWords <= 0 || loremText.NumberOfWords > maxId)
            {
                //borrowing Loremtext from animaltext column (faster)
                var text = db.AnimalText.Where(x => x.AnimalId == 1).FirstOrDefault();
                result = text.LoremText;

                return Content(result);
            }


            int id = loremText.NumberOfWords;
            int rand_num = 0;

            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.NumberOfWords == rand_num).SingleOrDefault();

                builder.Append(loremText.Lorem).Append(" ");

            }

            result = builder.ToString();
            return Content(result);
        }
        /// <summary>
        /// Gets a text with lorem by default and by numberOfWords unique identifier, it will also wait for 5 secs.
        /// </summary>
        /// <param name="loremText">Contains an object of loremtext words</param>
        /// <returns>Returns a lorem text or a unique amount of lorem words</returns>
       
        [HttpGet("slow")]
        public IActionResult GetLoremSlow([FromQuery]LoremText loremText)
        {
            string result;

            StringBuilder builder = new StringBuilder();

            System.Threading.Thread.Sleep(5000);

            int maxId = db.LoremText.Max(x => x.NumberOfWords);
            int rand_num = 0;
            if (loremText == null || loremText.NumberOfWords <= 0 || loremText.NumberOfWords > maxId)
            {


                for (int i = 1; i <= maxId; i++)
                {
                    loremText = db.LoremText.Where(x => x.NumberOfWords == i).SingleOrDefault();

                    builder.Append(loremText.Lorem).Append(" ");
                }
                result = builder.ToString();
                return Content(result);
            }

            int id = loremText.NumberOfWords;
            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.NumberOfWords == rand_num).SingleOrDefault();

                builder.Append(loremText.Lorem).Append(" ");

            }

            result = builder.ToString();

            return Content(result);
        }
        /// <summary>
        /// Gets an object of LoremTextComma where lorem words is separated by commas
        /// </summary>
        /// <returns>Returns a string of lorem words with commas by default</returns>
       
        [HttpGet("comma")]
        public IActionResult GetLoremComma()
        {
            LoremTextComma loremText = new LoremTextComma();

            string result;
            int maxId = db.LoremTextComma.Max(x => x.NumberOfWords);

            StringBuilder builder = new StringBuilder();

            for (int i = 1; i <= maxId; i++)
            {
                loremText = db.LoremTextComma.Where(x => x.NumberOfWords == i).SingleOrDefault();
                if (i == maxId)
                    builder.Append(loremText.LoremComma);
                else
                    builder.Append(loremText.LoremComma).Append(",");
            }

            result = builder.ToString();

            return Content(result);
        }
        /// <summary>
        /// Gets an animal object with spefic values
        /// </summary>
        /// <param name="animalText">The object contains properties that represents an animal</param>
        /// <returns>Returns an animal object with specific values</returns>
       
        [HttpGet("animals")]
        public IActionResult GetAnimal([FromQuery]AnimalText animalText)
        {
            StringBuilder builder = new StringBuilder();

            string animal;
            string description;
            string url;
            string loremText;

            if (animalText == null)
            {
                animalText = db.AnimalText.Find(1);

                animal = animalText.AnimalName;
                description = "*" + animalText.AnimalDetails + "*";
                url = "*" + animalText.Url + "*";
                loremText = animalText.LoremText;

                builder.Append(animal).Append(description).Append(loremText).Append(url);

                string result2 = builder.ToString();
                return Content(result2);

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
                return Content(result2);

            }
            animal = animals.AnimalName;
            description = "*" + animals.AnimalDetails + "*";
            url = "*" + animals.Url + "*";
            loremText = animals.LoremText;

            builder.Append(animal).Append(description).Append(loremText).Append(url);

            string result = builder.ToString();

            return Content(result);
        }
      
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