using Api.db.Repositories;
using AWSFileUploaderWithImageCompression;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _123Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICustomerRepository _custrepo;
        public ValuesController(ICustomerRepository customerRepository)
        {
            _custrepo = customerRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public  string Get()
        {

         //   HttpClient client2 = new HttpClient();
           // HttpResponseMessage response2 = await client2.GetAsync("http://universities.hipolabs.com/search?country=United+States");
           // response2.EnsureSuccessStatusCode();
          //  string responseBody = await response2.Content.ReadAsStringAsync();
            return "";
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://universities.hipolabs.com/search?country=United+States");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    //GET Method
            //    HttpResponseMessage response = await client.GetAsync("http://universities.hipolabs.com/search?country=United+States");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Department department = await response.Content.ReadAsAsync<Department>();lt 
            //        var resut = response.Content.ReadAsAsync<string>();
            //        //  Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
            //        //  Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Internal server Error");
            //    }
            //}
            //  return  _custrepo.GetCustomerNams().Result.ToArray();          
        }



        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // var apikey = Config["apikey"];
            // var secreetkey = Config["secrekey"];
            IS3ImageUploader s3ImageUploader = new S3ImageUploader("accesskey", "secretkey", Amazon.RegionEndpoint.CNNorth1, "bucketname");
            IImageService imageService = new ImageService(s3ImageUploader, config => {
                config.WaterMarkPosition = ImageMagick.Gravity.Southeast;
                config.WaterMarkTransperency = 2;
                config.MaintainAspectRatio = true;
                config.MaxWidth = 300;
                config.MaxHeight = 300;
            });
            var image5 = @"c:\users\downloads\1.jpg";
            var result = imageService.CompressAndUploadImageAsync(image5);
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
