using MediatR;
using Product_Easa_Commends.ProductCommends.Commend;
using Product_easa_Database.SQLConnection;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.CommendHandler;

public class AddProductCommendHandler : IRequestHandler<AddProductCommend, Product>
{
    private readonly ProductEasaDbContext Context;
    public AddProductCommendHandler(ProductEasaDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<Product> Handle(AddProductCommend request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Id = request.Product.Id,
            Name = request.Product.Name,
            Description = request.Product.Description,
        };
        await Context.Products.AddAsync(product);
        await Context.SaveChangesAsync();
        return product;
    }
}
