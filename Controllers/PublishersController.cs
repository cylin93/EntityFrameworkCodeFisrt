using EntityFrameworkCodeFisrt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFisrt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(ILogger<PublishersController> logger)
        {
            _logger = logger;
        }

        //CRUD

        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            using (var dbContext = new BookStoreDBComtext())
            {
                return dbContext.Publishers.ToList();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IEnumerable<Publisher> Delete(int id)
        {
            using (var dbContext = new BookStoreDBComtext())
            {
                var publisher = dbContext.Publishers.Where(w => w.PublisherId == id).FirstOrDefault();
                dbContext.Publishers.Remove(publisher);
                dbContext.SaveChanges();
                return dbContext.Publishers.ToList();
            }
        }

        [HttpPost]
        public IEnumerable<Publisher> Post(Publisher publisher)
        {
            using (var dbContext = new BookStoreDBComtext())
            {
                var p = dbContext.Publishers.Add(publisher);
                dbContext.SaveChanges();
                return dbContext.Publishers.ToList();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IEnumerable<Publisher> Put(int id,Publisher publisher)
        {
            using (var dbContext = new BookStoreDBComtext())
            {
                var obj = dbContext.Publishers.Where(w => w.PublisherId == id).FirstOrDefault();
                obj.PublisherName = publisher.PublisherName;
                dbContext.Update(obj);
                dbContext.SaveChanges();
                return dbContext.Publishers.ToList();
            }
        }
    }
}
