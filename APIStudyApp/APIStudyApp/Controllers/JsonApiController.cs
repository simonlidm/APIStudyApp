using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using APIStudyApp.Models;
using APIStudyApp.Security;

namespace APIStudyApp.Controllers
{
    /// <summary>
    /// API controller for example testing AJAX med Json
    /// </summary>
    [Compress]
    [CacheFilter(TimeDuration = 100)]
    public class JsonApiController : ApiController
    {
        private APIStudyAppDatabaseEntities db = new APIStudyAppDatabaseEntities();
        public JsonApiController()
        {

            db.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// Get random loremtext in an array. Four by default. NumberOfWords parameter is to be used to specify the amount of words.
        /// </summary>
        /// <param name="loremText"></param>
        /// <returns>Returns a specific amount of words in an array or four words by default</returns>
        [Route("api/jsonapi/lorem_json_array")]
        public IHttpActionResult GetJsonText([FromUri]LoremText loremText)
        {
            int maxId = db.LoremText.Max(x => x.numberOfWords);
            string[] result;
           
            int rand_num = 0;
            if (loremText == null || loremText.numberOfWords <= 0 || loremText.numberOfWords > maxId)
            {
                string[] array2 = new string[4];

                for (int i = 0; i < 4; i++)
                {
                    Random rand = new Random();
                    rand_num = rand.Next(1, maxId);

                    loremText = db.LoremText.Where(x => x.numberOfWords == rand_num).SingleOrDefault();
                    array2[i] += loremText.Lorem;

                }
                result = array2;

                return Ok(result);
            }
            int id = loremText.numberOfWords;
            string[] array = new string[id];
            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.numberOfWords == rand_num).SingleOrDefault();
                array[i -1]+=loremText.Lorem;

            }
            result = array;
            return Ok(result);
        }
        /// <summary>
        /// Gets random numbers into an int array consisting of numbers 1-6.
        /// </summary>
        /// <param name="dice"></param>
        /// <returns>Returns an int array with specified amount of dice.</returns>
        [HttpGet]
        [Route("api/jsonapi/dice_json_array")]
        public IHttpActionResult GetJsonNumber([FromUri]diceModel dice)
        {
            int rand_num = 0;
            Random rand = new Random();
            if (dice == null || dice.numberOfDice <=0)
            {
                int[]array = new int[1];

                rand_num = rand.Next(1, 7);
                    array[0] += rand_num;
                
                return Ok(array);
            }
            dice.dice_array = new int[dice.numberOfDice];

            for (int i = 0; i < dice.numberOfDice; i++)
            {
                rand_num = rand.Next(1, 7);
                dice.dice_array[i]+=rand_num;
            }
            return Ok(dice.dice_array);
        }
        /// <summary>
        /// Get a blog in an object array and with a relation to a tag object array.
        /// </summary>
        /// <returns>Returns blog_posts as an object array consisting properties and another object array with tags</returns>
        [HttpGet]
        [Route("api/JsonApi/simple_json")]
        public IHttpActionResult GetSimpleJson()
        {
            Blog_posts result = new Blog_posts();

            var data = db.Detail.Select(r => new Blog_post_detail
            {
                detailId = r.DetailId,
                title = r.title,
                date = r.date,
                text = r.text,                
                tags =r.ItemTags.Select(x=>x.Tags).ToList()
            }).Where(x=>x.detailId < 4).ToList();
            result.blog_posts = data.ToArray();
           
            
            result.About = "This is a blog by the Gugge himself. It is filled with nonsense bacon ipsum. Enjoy!";
            result.Author = "Gugge Tenderloin Svensson";
            return Ok(result);
        }
        /// <summary>
        /// Gets an object array consisting blog posts.
        /// </summary>
        /// <returns>Returns a list of blog posts with tags</returns>
        [HttpGet]
        [Route("api/jsonapi/blog_json")]
        public IHttpActionResult GetBlogJson()
        {
            Blog_posts2 result = new Blog_posts2();

            var data = db.Detail.Select(r => new Blog_post_detail2
            {
                detailId = r.DetailId,
                title = r.title,
                author = r.author,
                date = r.date,
                text = r.text,
                tags = r.ItemTags.Select(x => x.Tags).ToList()
            }).ToList();
            result.blog_posts = data.ToArray();


            result.About = "This is a blog by the Gugge himself and his friend Robin. It is filled with nonsense bacon ipsum. Enjoy!";
            result.Contact = "You can reach Gugge on 555-555 555 or gugge_the_man@yahoo.com";
            return Ok(result);
        }
        /// <summary>
        /// Gets a list of employees with properties and relations. Company properties in an array.
        /// </summary>
        /// <returns>Returns 2 object arrays, 1 Company array and 1 Employee array consisting of more to more relations.</returns>
        [HttpGet]
        [Route("api/jsonapi/employees_json")]
        public IHttpActionResult GetEmployeeJson()
        {
            CompanyDTO comp = new CompanyDTO();

            var data = db.Employee.Select(r => new Employee_details
            {
                name = r.Name,
                employee_id = r.EmployeeId,
                department = r.Department,
                email = r.Email,
                direct_number = r.DirectNumber,
                skills = r.ItemsSkill.Select(x => x.Skill).ToList(),
                work_experience=r.WorkExperience.ToList(),
                office = r.Office.ToList()
            }).ToList();
            comp.employees = data.ToArray();

            var data2 = db.Company.Select(r => new Company_details
            {
                name = r.Name,
                address = r.Address,
                website = r.Website
              
            }).ToList();
            comp.company = data2.ToArray();

            return Ok(comp);
        }
        /// <summary>
        /// Gets an animalid 1 by default or when higher than array it is maxid by default. Query is specified by animalid.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns>Returns default values 1 or max value. If specified it returns an animal by id.</returns>
        [HttpGet]
        [Route("api/jsonapi/animals_json")]
        public IHttpActionResult GetAnimalJson([FromUri]Animal animal)
        {
            int maxId = db.Animal.Max(x => x.AnimalId);
            if (animal == null || animal.AnimalId <= 0)
            {
                var data2 = db.Animal.Select(r => new Animal_detail
                {
                    animal = r.AnimalDetail.ToList(),
                    AnimalId = r.AnimalId,
                    AnimalMaxId = maxId
                }).Where(x => x.AnimalId == 1);
                return Ok(data2);
            }
            else if(animal.AnimalId > maxId)
            {
                var data = db.Animal.Select(r => new Animal_detail
                {
                    animal = r.AnimalDetail.ToList(),
                    AnimalId = r.AnimalId,
                    AnimalMaxId = maxId
                }).Where(x => x.AnimalId == maxId);
                return Ok(data);
            }
           
            var result = db.Animal.Select(r => new Animal_detail
            {
                animal = r.AnimalDetail.ToList(),
                AnimalId = r.AnimalId,
                AnimalMaxId = maxId
            }).Where(x => x.AnimalId == animal.AnimalId);

            return Ok(result);
        }
        // GET: api/JsonApi
        //public IQueryable<LoremText> GetLoremText()
        //{
        //    return db.LoremText;
        //}

        // GET: api/JsonApi/5
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

        //// PUT: api/JsonApi/5
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

        //// POST: api/JsonApi
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

        //// DELETE: api/JsonApi/5
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool LoremTextExists(int id)
        //{
        //    return db.LoremText.Count(e => e.numberOfWords == id) > 0;
        //}
    }
}