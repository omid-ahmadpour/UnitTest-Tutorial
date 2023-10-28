using UnitTestTutorial.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestTutorial.Domain.IRepositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task AddOrUpdateRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
        Task<bool> ValidateRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
    }
}
