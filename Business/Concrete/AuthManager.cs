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
        IConfiguration _configuration;

        public AuthManager(IUserService userService, IConfiguration configuration, ITokenHelper tokenHelper)
        {
            _configuration = configuration;
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin, string password)
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



        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }

        public IResult UserExist(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user.Success)
            {
                return new SuccessResult(Message.UserExist);
            }
            else
            {
                return new ErrorResult(Message.UserNotFound);
            }
        }
        public IDataResult<AccessToken> CreateAcccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
