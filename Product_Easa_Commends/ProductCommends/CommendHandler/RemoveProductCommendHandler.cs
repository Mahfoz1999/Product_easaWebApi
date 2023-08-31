using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_Easa_Commends.Exceptions;
using Product_Easa_Commends.ProductCommends.Commend;
using Product_easa_Database.SQLConnection;

namespace Product_Easa_Commends.ProductCommends.CommendHandler;

public class RemoveProductCommendHandler : IRequestHandler<RemoveProductCommend, int>
{
    private readonly ProductEasaDbContext Context;
    public RemoveProductCommendHandler(ProductEasaDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<int> Handle(RemoveProductCommend request, CancellationToken cancellationToken)
    {
        int product = await Context.Products.Where(e => e.Id == request.ProductId).ExecuteDeleteAsync();
        await Context.SaveChangesAsync();
        if (product == 0)
            throw new NotFoundException("Product Not Found");
        return product;
    }
}
