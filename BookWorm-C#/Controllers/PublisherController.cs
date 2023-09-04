using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly SQLPublisherRepository _repository;

        public PublisherController(SQLPublisherRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Publisher
        [HttpGet("/GetAllPublishers")]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetAllPublishers()
        {
            var publishers = await _repository.GetAllPublishers();
            if (publishers == null || publishers.Count == 0)
            {
                return NotFound();
            }
            return Ok(publishers);
        }

        // GET: api/Publisher/5
        [HttpGet("/GetPublisher/{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            var publisher = await _repository.GetPublisher(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST: api/Publisher
        [HttpPost]
        public async Task<ActionResult<Publisher>> AddPublisher(Publisher publisher)
        {
            var addedPublisher = await _repository.AddPublisher(publisher);
            return CreatedAtAction("GetPublisher", new { id = addedPublisher.PublisherId }, addedPublisher);
        }

        // PUT: api/Publisher/5
        [HttpPut("/UpdatePublisher/{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, Publisher publisher)
        {
            var updatedPublisher = await _repository.UpdatePublisher(id, publisher);
            if (updatedPublisher == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE: api/Publisher/5
        [HttpDelete("/DeletePublisher/{id}")]
        public async Task<ActionResult<Publisher>> DeletePublisher(int id)
        {
            var deletedPublisher = await _repository.DeletePublisher(id);
            if (deletedPublisher == null)
            {
                return NotFound();
            }
            return Ok(deletedPublisher);
        }
    }
}