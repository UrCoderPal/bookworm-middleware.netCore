using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace BookWorm_C_.Repositories
{
    public class IInvoiceDetailImpl : IInvoiceDetail
    {

        private readonly Appdbcontext context;

        public IInvoiceDetailImpl(Appdbcontext context)
        {
            this.context = context;
        }

        public async Task<InvoiceDetail> deleteInvoiceDetailsById(long id)
        {
            InvoiceDetail invdetails = context.InvoiceDetail.Find(id);
            if (invdetails != null)
            {
                context.InvoiceDetail.Remove(invdetails);
                await context.SaveChangesAsync();
            }
            return invdetails;
        }

        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> getAllInvoiceDetails()
        {
            if (context.InvoiceDetail == null)
            {
                return null;
            }
            return await context.InvoiceDetail.ToListAsync();
        }

        public async Task<ActionResult<InvoiceDetail>?> getByBasePrice(double basePrice)
        {
            if (context.InvoiceDetail == null)
            {
                return null;
            }
            var invdetails = await context.InvoiceDetail.FindAsync(basePrice);

            if (invdetails == null)
            {
                return null;
            }

            return invdetails;

        }

        public async Task<ActionResult<InvoiceDetail>?> getByInvDtlId(long invDtlId)
        {
            if (context.InvoiceDetail == null)
            {
                return null;
            }
            var invdetails = await context.InvoiceDetail.FindAsync(invDtlId);

            if (invdetails == null)
            {
                return null;
            }

            return invdetails;
        }

        public async Task<ActionResult<InvoiceDetail>?> getByTranType(string tranType)
        {
            if (context.InvoiceDetail == null)
            {
                return null;
            }
            var invdetails = await context.InvoiceDetail.FindAsync(tranType);

            if (invdetails == null)
            {
                return null;
            }

            return invdetails;
        }

        public async Task<ActionResult<InvoiceDetail>> setInvoiceDetails(InvoiceDetail invdetails)
        {
            context.InvoiceDetail.Add(invdetails);
            await context.SaveChangesAsync();
            return invdetails;
        }

        public Task<InvoiceDetail> updateQuantity(int id, InvoiceDetail invdetails)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetail> updateTranType(int id, InvoiceDetail invdetails)
        {
            throw new NotImplementedException();
        }
    }
}
