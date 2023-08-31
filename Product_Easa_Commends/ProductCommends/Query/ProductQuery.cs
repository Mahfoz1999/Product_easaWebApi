using MediatR;
using Product_Easa_Models.Core;

namespace Product_Easa_Commends.ProductCommends.Query;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
public record GetProductQuery(int ProductId) : IRequest<Product>;