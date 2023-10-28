﻿using UnitTestTutorial.Common;
using UnitTestTutorial.Domain.Entities.Users;
using UnitTestTutorial.Domain.IRepositories;
using UnitTestTutorial.Persistence.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestTutorial.Persistence.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository, IScopedDependency
    {
        public RefreshTokenRepository(CleanArchWriteDbContext dbContext)
           : base(dbContext)
        {
        }
        public async Task AddOrUpdateRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken)
        {
            var token = await TableNoTracking.SingleOrDefaultAsync(x => x.UserId == refreshToken.UserId, cancellationToken);
            if (token == null)
            {
                refreshToken.Created = DateTime.Now;
                await base.AddAsync(refreshToken, cancellationToken);
            }
            else
            {
                refreshToken.Created = token.Created;
                refreshToken.Id = token.Id;
                await base.UpdateAsync(refreshToken, cancellationToken);
            }
        }
        public async Task<bool> ValidateRefreshTokenAsync(RefreshToken refreshToken, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking.SingleOrDefaultAsync(x => x.UserId == refreshToken.UserId, cancellationToken);
            if (result == null || result.Token != refreshToken.Token)
                throw new CleanArchAppException("RefreshToken is not valid");
            return true;
        }
    }
}
