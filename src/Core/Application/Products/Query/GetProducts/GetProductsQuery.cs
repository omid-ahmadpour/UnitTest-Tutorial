using UnitTestTutorial.Common.Utilities;
using UnitTestTutorial.Domain.Entities.Products;
using MediatR;

namespace UnitTestTutorial.Application.Products.Query.GetProducts
{
    public class GetProductsQuery : IRequest<PagedResult<Product>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
