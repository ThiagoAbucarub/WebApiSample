using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSample.Domain;

namespace WebApiSample.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("WebApiSample")]
    public class PersonController : ApiController
    {
        Person person = new Person();
        List<Person> listPerson = new List<Person>();

        // GET: WebApiSample/Person/GetAll
        [AcceptVerbs("GET")]
        [Route("Person/GetAll")]
        public List<Person> GetAll()
        {
            listPerson = person.GetAll();
            return listPerson;
        }

        // GET: WebApiSample/Person/GetById/5
        [AcceptVerbs("GET")]
        [Route("Person/GetById/{PersonId}")]
        public Person GetById (int PersonId)
        {
            person.PersonId = PersonId;
            person.GetById();
            return person;
        }

        // GET: WebApiSample/Person/Post
        [AcceptVerbs("Post")]
        [Route("Person/Post")]
        public Person Post(string Name, string Phone, string Email, string BornDate, string Gender)
        {
            person.Name = Name;
            person.Phone = Phone;
            person.Email = Email;
            person.BornDate = BornDate;
            person.Gender = Gender;
            person.Post();

            return person;
            
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
