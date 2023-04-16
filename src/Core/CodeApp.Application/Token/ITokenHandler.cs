using CodeApp.Application.Dtos.Token;
using System.Security.Claims;

namespace CodeApp.Application.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute, List<Claim>? authClaims);
        string CreateRefreshToken();
    }

}
