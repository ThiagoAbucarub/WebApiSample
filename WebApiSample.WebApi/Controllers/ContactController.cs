using System.Collections.Generic;
using System.Web.Http;
using WebApiSample.Domain;

namespace WebApiSample.WebApi.Controllers
{
    [RoutePrefix("WebApiSample")]
    public class ContactController : ApiController
    {
        Contact contact = new Contact();
        List<Contact> listContact = new List<Contact>();

        // GET: WebApiSample/Contact/GetAll
        [AcceptVerbs("GET")]
        [Route("Contact/GetAll")]
        public List<Contact> GetAll()
        {
            listContact = contact.GetAll();
            return listContact;
        }

        // GET: WebApiSample/Contact/GetById/5
        [AcceptVerbs("GET")]
        [Route("Contact/GetById/{User_Id}")]
        public Contact GetById (int User_Id)
        {
            contact.User_Id = User_Id;
            contact.GetById();
            return contact;
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
