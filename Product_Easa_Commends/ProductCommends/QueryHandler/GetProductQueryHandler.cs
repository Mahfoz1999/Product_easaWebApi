using MediatR;
using Product_Easa_Commends.Exceptions;
using Product_Easa_Commends.ProductCommends.Query;
using Product_easa_Database.SQLConnection;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.QueryHandler;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly ProductEasaDbContext Context;
    public GetProductQueryHandler(ProductEasaDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        Product? product = await Context.Products.FindAsync(request.ProductId)!;
        if (product != null) return product;
        else throw new NotFoundException("Product Not Found");
    }
}
