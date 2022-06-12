using AutoMapper;
using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Services;
using ElearningApplication.Models.Entities;
using ElearningApplication.Models.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElearningApplication.Services;

public class AccountService : IAccountService
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly IMapper _mapper;
    private readonly ITokenService _token;


    private readonly ILogger<AccountService> _logger;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper,
        ILogger<AccountService> logger,
        ITokenService token)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _logger = logger;
        _token = token;
    }

    public async Task<DataResponse> Signin(SigninModel signinModel)
    {
        var user = await _userManager.Users.Where(u=>u.UserName==signinModel.UserName)
                        .Include(u => u.UserRoles.Where(us => us.RoleId==signinModel.Role))
                        .ThenInclude(r=>r.Role)
                        .SingleOrDefaultAsync();

        if (user == null) throw new NotFoundException("User is not found");

        var isCorrect = await _userManager.CheckPasswordAsync(user, signinModel.Password);

        if (!isCorrect) throw new BadRequestException("Password is wrong for this user.");

        var userRoleDTO = _mapper.Map<UserRoleDTO>(user);
        
        var roles = new List<string>();
        foreach (var role in userRoleDTO.Roles)
        {
            roles.Add(role.Name);
        }

        var token = _token.tokenGeneration(userRoleDTO.UserName,userRoleDTO.Id,roles);

        return new DataResponse(true,token,null!);
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