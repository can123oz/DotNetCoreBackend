using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IConfiguration configuration, ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userService.GetByEmail(userForLogin.Email);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.WrongPassword);
            }

            return new SuccessDataResult<User>(userToCheck.Data ,Message.SuccessLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                FirstName=userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                Email=userForRegisterDto.Email,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,"Successfuly Registered");
        }

        public IResult UserExist(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user.Success)
            {
                return new SuccessResult(Message.UserExist);
            }
            return new ErrorResult(Message.UserNotFound);
        }

        public IDataResult<AccessToken> CreateAcccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access Token Created");
        }
    }
}
