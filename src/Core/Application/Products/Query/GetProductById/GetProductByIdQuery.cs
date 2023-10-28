﻿using MediatR;

namespace UnitTestTutorial.Application.Products.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductQueryModel>
    {
        public int ProductId { get; set; }
    }
}