using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.IdentityModel.Tokens;
using UsingAuthorizationWithSwagger.Models;

namespace UsingAuthorizationWithSwagger.Endpoints;

public class AuthEndpoint : Endpoint<LoginModel>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("endpointlogin");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginModel? model, CancellationToken ct)
    {
        if (model == null)
        {
            await SendNotFoundAsync(ct);
        }

        if (model?.UserName == "johndoe" && model.Password == "johndoe2410")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "CodeMaze",
                audience: "https://localhost:5001",
                claims: new List<Claim>{new Claim(ClaimTypes.Role, "admin")},
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            await SendOkAsync(new { Token = tokenString }, ct);
        }
        else
        {
            await SendUnauthorizedAsync(ct);
        }
    }
}