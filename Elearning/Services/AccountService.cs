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


    private readonly ILogger<AccountService> _logger;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper,
        ILogger<AccountService> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _logger = logger;
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



        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                throw new BadRequestException($"{error.Description}");
            }

        }


        var userDTO = _mapper.Map<UserDTO>(user);

        return new DataResponse(true, userDTO, null!);
    }
}