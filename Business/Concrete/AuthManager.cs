using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
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

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Gender = userForRegisterDto.Gender,
                DateOfBirth = userForRegisterDto.DateOfBirth,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                CreadtedAt = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null || !userToCheck.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt) == false)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var roles = _userService.GetRoles(user);

            var accessToken = _tokenHelper.CreateToken(user, claims.Data,roles.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<RefreshToken> CreateRefreshToken()
        {
            var refreshToken = _tokenHelper.GenerateRefreshToken();
            return new SuccessDataResult<RefreshToken>(refreshToken);
        }
        public IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user)
        {
            _tokenHelper.SetRefreshToken(refreshToken, response, user);
            return new SuccessResult();
        }

        public IDataResult<JObject> CreateTokens(User user, HttpResponse response)
        {
            var accessToken = CreateAccessToken(user).Data;
            var refreshToken = _tokenHelper.GenerateRefreshToken();

            _tokenHelper.SetRefreshToken(refreshToken, response, user); // refresh tokken adding cookie

            JObject tokens = new JObject(
                new JProperty("AccessToken", accessToken.Token),
                new JProperty("RefreshToken", refreshToken.Token)
                );

            _userService.Update(user);

            return new SuccessDataResult<JObject>(tokens);

        }


    }
}
