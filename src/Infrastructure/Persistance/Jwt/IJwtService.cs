using UnitTestTutorial.Domain.Entities.Users;
using System.Threading.Tasks;

namespace UnitTestTutorial.Persistence.Jwt
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
        int? ValidateJwtAccessTokenAsync(string token);
    }
}
