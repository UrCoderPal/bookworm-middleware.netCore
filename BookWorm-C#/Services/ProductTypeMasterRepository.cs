using Ebookproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductTypeMasterRepository : IProductTypeMaster
{
    private readonly AppdbContext _context;

    public ProductTypeMasterRepository(AppdbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<ProductTypeMaster>> Add(ProductTypeMaster pro)
    {
        _context.productTypeMasters.Add(pro);  // Corrected typo: 'ProductTypeMastert' -> 'ProductTypeMasters'
        await _context.SaveChangesAsync();
        return pro;
    }

    public async Task<ProductTypeMaster> Delete(long typeId)
    {
        var productType = await _context.productTypeMasters.FindAsync(typeId);
        if (productType == null)
        {
            return null;
        }

        _context.productTypeMasters.Remove(productType);
        await _context.SaveChangesAsync();
        return productType;
    }

    public async Task<IEnumerable<ProductTypeMaster>> GetAllProducts()
    {
        return await _context.productTypeMasters.ToListAsync();
    }

    public async Task<ProductTypeMaster> GetProduct(long typeId)
    {
        return await _context.productTypeMasters.FindAsync(typeId);
    }

    public async Task<ProductTypeMaster> Update(long typeId, ProductTypeMaster pro)
    {
        if (typeId != pro.TypeId)
        {
            throw new ArgumentException("TypeIds do not match.");
        }

        _context.Entry(pro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductTypeMasterExists(typeId))
            {
                return null;
            }
            throw;
        }

        return pro;
    }

    Task<ActionResult<IEnumerable<ProductTypeMaster>>> IProductTypeMaster.GetAllProducts()
    {
        throw new NotImplementedException();
    }

    Task<ActionResult<ProductTypeMaster>?> IProductTypeMaster.GetProduct(long TypeId)
    {
        throw new NotImplementedException();
    }

    private bool ProductTypeMasterExists(long typeId)
    {
        return _context.productTypeMasters.Any(e => e.TypeId == typeId);
    }
}
