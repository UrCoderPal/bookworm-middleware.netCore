using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Repositories
{
    public interface IPublisherMasterRepository
    {
        Task<ActionResult<Publisher>?> GetPublisher(int Id);
        Task<ActionResult<IEnumerable<Publisher>>> GetAllPublishers();
        Task<ActionResult<Publisher>> AddPublisher(Publisher publisher);
        Task<Publisher> UpdatePublisher(int id, Publisher publisher);
        Task<Publisher> DeletePublisher(int Id);
    }
}
