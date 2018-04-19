using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/JsonApi")]
    public class JsonApiController : Controller
    {
        private APIStudyAppDatabaseContext db = new APIStudyAppDatabaseContext();
      
        /// <summary>
        /// Get random loremtext in an array. Four by default. NumberOfWords parameter is to be used to specify the amount of words.
        /// </summary>
        /// <param name="loremText"></param>
        /// <returns>Returns a specific amount of words in an array or four words by default</returns>
        [HttpGet("lorem_json_array")]
        public IActionResult GetJsonText([FromQuery]LoremText loremText)
        {
            int maxId = db.LoremText.Max(x => x.NumberOfWords);
            string[] result;

            int rand_num = 0;
            if (loremText == null || loremText.NumberOfWords <= 0 || loremText.NumberOfWords > maxId)
            {
                string[] array2 = new string[4];

                for (int i = 0; i < 4; i++)
                {
                    Random rand = new Random();
                    rand_num = rand.Next(1, maxId);

                    loremText = db.LoremText.Where(x => x.NumberOfWords == rand_num).SingleOrDefault();
                    array2[i] += loremText.Lorem;

                }
                result = array2;

                return Ok(result);
            }
            int id = loremText.NumberOfWords;
            string[] array = new string[id];
            for (int i = 1; i <= id; i++)
            {
                Random rand = new Random();
                rand_num = rand.Next(1, maxId);

                loremText = db.LoremText.Where(x => x.NumberOfWords == rand_num).SingleOrDefault();
                array[i - 1] += loremText.Lorem;

            }
            result = array;
            return Ok(result);
        }
        /// <summary>
        /// Gets random numbers into an int array consisting of numbers 1-6.
        /// </summary>
        /// <param name="dice"></param>
        /// <returns>Returns an int array with specified amount of dice.</returns>
     
        [HttpGet("dice_json_array")]
        public IActionResult GetJsonNumber([FromQuery]diceModel dice)
        {
            int rand_num = 0;
            Random rand = new Random();
            if (dice == null || dice.numberOfDice <= 0)
            {
                int[] array = new int[1];

                rand_num = rand.Next(1, 7);
                array[0] += rand_num;

                return Ok(array);
            }
            dice.dice_array = new int[dice.numberOfDice];

            for (int i = 0; i < dice.numberOfDice; i++)
            {
                rand_num = rand.Next(1, 7);
                dice.dice_array[i] += rand_num;
            }
            return Ok(dice.dice_array);
        }
        /// <summary>
        /// Get a blog in an object array and with a relation to a tag object array.
        /// </summary>
        /// <returns>Returns blog_posts as an object array consisting properties and another object array with tags</returns>
        [HttpGet("simple_json")]
        public IActionResult GetSimpleJson()
        {
            Blog_posts result = new Blog_posts();

            var data = db.Detail.Select(r => new Blog_post_detail
            {
                detailId = r.DetailId,
                title = r.Title,
                date = r.Date,
                text = r.Text,
                tags = r.ItemTags.Select(x => x.Tag).ToList()
            }).Where(x => x.detailId < 4).ToList();
            result.blog_posts = data.ToArray();


            result.About = "This is a blog by the Gugge himself. It is filled with nonsense bacon ipsum. Enjoy!";
            result.Author = "Gugge Tenderloin Svensson";
            return Ok(result);
        }
        /// <summary>
        /// Gets an object array consisting blog posts.
        /// </summary>
        /// <returns>Returns a list of blog posts with tags</returns>
        [HttpGet("blog_json")]
        public IActionResult GetBlogJson()
        {
            Blog_posts2 result = new Blog_posts2();

            var data = db.Detail.Select(r => new Blog_post_detail2
            {
                detailId = r.DetailId,
                title = r.Title,
                author = r.Author,
                date = r.Date,
                text = r.Text,
                tags = r.ItemTags.Select(x => x.Tag).ToList()
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
        [HttpGet("employees_json")]
        public IActionResult GetEmployeeJson()
        {
            CompanyDTO comp = new CompanyDTO();

            var data = db.Employee.Select(r => new Employee_details
            {
                name = r.Name,
                employee_id = r.EmployeeId,
                department = r.Department,
                email = r.Email,
                direct_number = r.DirectNumber,
                skills = r.ItemsSkill.Select(x => x.Skills).ToList(),
                work_experience = r.WorkExperience.ToList(),
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
        [HttpGet("animals_json")]
        public IActionResult GetAnimalJson([FromQuery]Animal animal)
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
            else if (animal.AnimalId > maxId)
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
        
    }
}