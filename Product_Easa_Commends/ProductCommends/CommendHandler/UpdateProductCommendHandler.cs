using MediatR;
using Product_Easa_Commends.Exceptions;
using Product_Easa_Commends.ProductCommends.Commend;
using Product_easa_Database.SQLConnection;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.CommendHandler;

public class UpdateProductCommendHandler : IRequestHandler<UpdateProductCommend, Product>
{
    private readonly ProductEasaDbContext Context;
    public UpdateProductCommendHandler(ProductEasaDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<Product> Handle(UpdateProductCommend request, CancellationToken cancellationToken)
    {
        Product? product = await Context.Products.FindAsync(request.Product.Id);
        if (product != null)
        {
            product.Name = request.Product.Name;
            product.Description = request.Product.Description;
            Context.Products.Update(product);
            await Context.SaveChangesAsync();
            return product;
        }
        else throw new NotFoundException("Product Not Found");
    }
}
