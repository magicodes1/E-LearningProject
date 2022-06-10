using AutoMapper;
using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Services;
using ElearningApplication.Models.Entities;
using ElearningApplication.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Services;

public class AccountService : IAccountService
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly IMapper _mapper;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<DataResponse> Signup(SignupModel signupModel)
    {
        var user = new ApplicationUser
        {
            UserName = signupModel.UserName,
            Email = signupModel.Email,
            PhoneNumber = signupModel.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, signupModel.Password);

        if (!result.Succeeded) throw new BadRequestException($"Sign up fail.");


        var userDTO = _mapper.Map<UserDTO>(user);

        return new DataResponse(true, userDTO, null!);
    }
}