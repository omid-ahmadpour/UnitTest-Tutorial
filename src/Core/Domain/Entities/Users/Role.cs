using Microsoft.AspNetCore.Identity;

namespace UnitTestTutorial.Domain.Entities.Users
{
    public class Role : IdentityRole<int>, IEntity
    {
        public string Description { get; set; }
    }
}
