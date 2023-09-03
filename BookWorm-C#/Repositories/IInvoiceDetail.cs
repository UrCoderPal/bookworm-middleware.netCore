using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BookWorm_C_.Repositories
{
    public interface IInvoiceDetail
    {
        Task<ActionResult<InvoiceDetail>?> getByInvDtlId(long invDtlId);
        Task<ActionResult<IEnumerable<InvoiceDetail>>> getAllInvoiceDetails();
        Task<ActionResult<InvoiceDetail>?> getByBasePrice(Double basePrice);
        Task<ActionResult<InvoiceDetail>?> getByTranType(String tranType);
        Task<ActionResult<InvoiceDetail>> setInvoiceDetails(InvoiceDetail invdetails);
        Task<InvoiceDetail> deleteInvoiceDetailsById(long id);
        Task<InvoiceDetail> updateQuantity(int id, InvoiceDetail invdetails);
        Task<InvoiceDetail> updateTranType(int id, InvoiceDetail invdetails);

    }
}
