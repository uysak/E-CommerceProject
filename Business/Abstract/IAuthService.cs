using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<JObject> CreateTokens(User user, HttpResponse response);
        IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user);
        IDataResult<RefreshToken> CreateRefreshToken();
    }
}
