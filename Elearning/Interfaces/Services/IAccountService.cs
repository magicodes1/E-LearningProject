using ElearningApplication.DTOs.Account;
using ElearningApplication.Models.Response;

namespace ElearningApplication.Interfaces.Services;

public interface IAccountService
{
    Task<DataResponse> Signup(SignupModel signupModel);
    Task<DataResponse> Signin(SigninModel signinModel);
}