using MediatR;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.Commend;

public record AddProductCommend(Product Product) : IRequest<Product>;
public record UpdateProductCommend(Product Product) : IRequest<Product>;
public record RemoveProductCommend(int ProductId) : IRequest<int>;
