using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_Easa_Commends.ProductCommends.Query;
using Product_easa_Database.SQLConnection;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.QueryHandler;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly ProductEasaDbContext Context;
    public GetAllProductsQueryHandler(ProductEasaDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await Context.Products.ToListAsync();
    }
}
