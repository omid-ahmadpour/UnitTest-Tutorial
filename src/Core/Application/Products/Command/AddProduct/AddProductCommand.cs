using MediatR;

namespace UnitTestTutorial.Application.Products.Command.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
