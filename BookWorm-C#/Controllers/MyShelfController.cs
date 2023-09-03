using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyShelfController : ControllerBase
    {
        private readonly IMyShelf _repository;

        public MyShelfController(IMyShelf repository)
        {
            _repository = repository;
        }

        [HttpGet("getShelfById/{id}")]
        public async Task<ActionResult<MyShelf>> getShelfById(long MyShelfId)
        {
            var MyShelf = await _repository.getById(MyShelfId);
            if (MyShelf == null)
            {
                return NotFound();
            }
            return Ok(MyShelf);
        }

        [HttpGet("getShelfByCustId/{CustId}")]
        public async Task<ActionResult<MyShelf>> GetShelfByCustId(long CustomerId)
        {
            var MyShelf = await _repository.getByCustomerId(CustomerId);
            if (MyShelf == null)
            {
                return NotFound();
            }
            return Ok(MyShelf);
        }

    }
}
