using CodeApp.Application.Dtos.Token;

namespace CodeApp.Application.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute);
    }

}
