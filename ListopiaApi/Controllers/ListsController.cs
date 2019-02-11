using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using ListopiaApi.Models;
using ListopiaApi.Providers;
using ListopiaApi.Results;
using ListopiaApi.Models;

namespace ListopiaApi.Controllers
{
    [Authorize]
    public class ListsController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET api/Lists
        public IEnumerable<List> Get()
        {
            var userId = User.Identity.GetUserId();
            var lists = _context.Lists.Where(l => l.OwnerId == userId).ToList();
            return lists;
        }

        // GET api/Lists/1
        public List Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var list = _context.Lists.SingleOrDefault(l => l.OwnerId == userId && l.Id == id);
            return list;
        }

        // POST api/Lists
        public void Post([FromBody]List value)
        {
            value.OwnerId = User.Identity.GetUserId();

            _context.Lists.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}