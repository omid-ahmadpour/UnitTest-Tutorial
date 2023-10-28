﻿using UnitTestTutorial.Application.Users.Command.Login;
using UnitTestTutorial.Common;
using UnitTestTutorial.Common.Exceptions;
using UnitTestTutorial.Domain.Entities.Users;
using UnitTestTutorial.Domain.IRepositories;
using UnitTestTutorial.Persistence.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestTutorial.Persistence.CommandHandlers.Users
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginCommandHandler(UserManager<User> userManager,
                                   IJwtService jwtService,
                                   IRefreshTokenRepository refreshTokenRepository)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new InvalidNullInputException(nameof(request));

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                throw new CleanArchAppException("username or password is incorrect");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                throw new CleanArchAppException("username or password is incorrect");

            var jwt = await _jwtService.GenerateAsync(user);
            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                ExpiryTime = DateTime.Now.AddDays(jwt.refreshToken_expiresIn),
                Token = jwt.refresh_token
            };
            await _refreshTokenRepository.AddOrUpdateRefreshTokenAsync(refreshToken: refreshToken, cancellationToken);
            return new LoginResponse
            {
                accessToken = jwt.access_token,
                refreshToken = jwt.refresh_token
            };
        }
    }
}
