using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSample.Domain;

namespace WebApiSample.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("WebApiSample")]
    public class UsersController : ApiController
    {
        Users users = new Users();
        List<Users> listUsers = new List<Users>();

        // GET: WebApiSample/Users/GetAll
        [AcceptVerbs("GET")]
        [Route("Users/GetAll")]
        public List<Users> GetAll()
        {
            listUsers = users.GetAll();
            return listUsers;
        }

        // GET: WebApiSample/Users/GetById/5
        [AcceptVerbs("GET")]
        [Route("Users/GetById/{UserId}")]
        public Users GetById (int UserId)
        {
            users.UserId = UserId;
            users.GetById();
            return users;
        }

        // GET: WebApiSample/Users/Post
        [AcceptVerbs("Post")]
        [Route("Users/Post")]
        public Users Post(string Name, string Phone, string Email, string BornDate, string Gender)
        {
            users.Name = Name;
            users.Phone = Phone;
            users.Email = Email;
            users.BornDate = BornDate;
            users.Gender = Gender;
            users.Post();

            return users;
            
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
