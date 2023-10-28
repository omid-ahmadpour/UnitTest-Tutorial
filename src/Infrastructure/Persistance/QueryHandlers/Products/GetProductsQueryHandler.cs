using UnitTestTutorial.Application.Products.Query.GetProducts;
using UnitTestTutorial.Common.Utilities;
using UnitTestTutorial.Domain.Entities.Products;
using UnitTestTutorial.Persistence.Db;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestTutorial.Persistence.QueryHandlers.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<Product>>
    {
        private readonly CleanArchReadOnlyDbContext _dbContext;

        public GetProductsQueryHandler(CleanArchReadOnlyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<PagedResult<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Set<Product>().GetPaged(request.Page, request.PageSize);

            return products;
        }
    }
}
