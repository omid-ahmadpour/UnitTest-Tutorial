﻿using UnitTestTutorial.Api.Controllers.v1.Users.Requests;
using UnitTestTutorial.ApiFramework.Tools;
using UnitTestTutorial.Application.Users.Command.CreateUser;
using UnitTestTutorial.Application.Users.Command.Login;
using UnitTestTutorial.Application.Users.Command.RefreshToken;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestTutorial.Api.Controllers.v1.Users
{
    [ApiVersion("1")]
    public class UserController : BaseControllerV1
    {
        [HttpPost("signup")]
        [SwaggerOperation("sign up user")]
        [AllowAnonymous]
        public virtual async Task<ApiResult<bool>> SingUpAsync(SingUpRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateUserCommand>();

            var result = await Mediator.Send(command, cancellationToken);
            return new ApiResult<bool>(result);
        }

        [HttpPost("login")]
        [SwaggerOperation("login by username and password")]
        [AllowAnonymous]
        public virtual async Task<ApiResult<LoginResponse>> LoginAsync([FromForm] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<LoginCommand>();

            var result = await Mediator.Send(command, cancellationToken);
            return new ApiResult<LoginResponse>(result);
        }

        [HttpPost("refreshToken")]
        [SwaggerOperation("get new refresh and access token")]
        [AllowAnonymous]
        public virtual async Task<ApiResult<RefreshTokenResponse>> RefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<RefreshTokenCommand>();

            var result = await Mediator.Send(command, cancellationToken);
            return new ApiResult<RefreshTokenResponse>(result);
        }
    }
}
