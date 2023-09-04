using BookWorm_C_.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm_C_.Services
{
    public class SQLPublisherRepository
    {
        private BookWormContext context;
        public SQLPublisherRepository(BookWormContext context)
        {
            this.context = context;
        }

        public async Task<Publisher?> GetPublisher(int id)
        {
            return await context.Publishers.FindAsync(id);
        }

        public async Task<List<Publisher>> GetAllPublishers()
        {
            return await context.Publishers.ToListAsync();
        }

        public async Task<Publisher> AddPublisher(Publisher publisher)
        {
            context.Publishers.Add(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher?> UpdatePublisher(int id, Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return null;
            }

            context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return publisher;
        }

        public async Task<Publisher?> DeletePublisher(int id)
        {
            var publisher = await context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
                await context.SaveChangesAsync();
            }
            return publisher;
        }

        private bool PublisherExists(int id)
        {
            return context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}