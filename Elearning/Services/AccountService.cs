using AutoMapper;
using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Email;
using ElearningApplication.Interfaces.Services;
using ElearningApplication.Interfaces.Unit;
using ElearningApplication.Models.Email;
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

    private readonly IEmailSender _emailSender;

    private readonly IUnitOfWork _unitOfWork;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mapper,
        ILogger<AccountService> logger,
        ITokenService token,
        IEmailSender emailSender,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _logger = logger;
        _token = token;
        _emailSender = emailSender;
        _unitOfWork = unitOfWork;
    }

    public async Task PasswordReset(PasswordResetModel passwordResetModel)
    {
        try
        {
            var user = await _userManager.Users.Where(p => p.Id == passwordResetModel.Id)
                        .Include(p => p.OTPs)
                        .SingleOrDefaultAsync();

            if (user == null) throw new BadRequestException("User is not found.");

            if (user.Email.CompareTo(passwordResetModel.Email) != 0)
                throw new BadRequestException("Your email is not correct.");


            var otp = OtpGeneration();

            var currentDay = getCurrentDay();

            user.OTPs.Add(new OTP { Code = otp, isActive = true, isVerified = false, ReleaseDate = currentDay });

            await _unitOfWork.saveChangesAsync();

            await sendEmail(passwordResetModel.Email, otp);

        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task<DataResponse> Signin(SigninModel signinModel)
    {
        var user = await _userManager.Users.Where(u => u.UserName == signinModel.UserName)
                        .Include(u => u.UserRoles.Where(us => us.RoleId == signinModel.Role))
                        .ThenInclude(r => r.Role)
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

        var token = _token.tokenGeneration(userRoleDTO.UserName, userRoleDTO.Id, roles);

        return new DataResponse(true, token, null!);
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

    public async Task VerifyCode(VerifyCodeModel verifyCodeModel)
    {
        try
        {
            var user = await _userManager.Users.Where(p => p.Id == verifyCodeModel.Id).Include(p => p.OTPs).SingleOrDefaultAsync();

            if (user == null) throw new BadRequestException("User is not found.");

            var otp = user.OTPs.Where(o => o.Code == verifyCodeModel.Code && o.isActive == true).SingleOrDefault();

            if (otp == null && user.OTPs.Count < 4)
            {

                var otpCode = OtpGeneration();

                var currentDay = getCurrentDay();

                // deactive all old otp code

                foreach (var item in user.OTPs.ToList())
                {
                    if (item.isActive)
                    {
                        item.isActive = false;
                    }
                }

                // create new otp and save
                user.OTPs.Add(new OTP { Code = otpCode, isActive = true, isVerified = false, ReleaseDate = currentDay });

                await _unitOfWork.saveChangesAsync();


                await sendEmail(user.Email, otpCode);
                throw new BadRequestException("Your codes is not correct.");
            }

            otp!.isVerified = true;
            await _unitOfWork.saveChangesAsync();
        }
        catch (System.Exception)
        {

            throw;
        }

    }


    public async Task ChangePassword(ChangePasswordModel changePasswordModel)
    {
        var user = await _userManager.Users.Where(p => p.Id == changePasswordModel.Id)
                                .Include(p => p.OTPs)
                                .SingleOrDefaultAsync();
        if (user == null) throw new BadRequestException("User is not found.");

        var otp = user.OTPs.Where(p => p.isVerified == true).SingleOrDefault();

        if(otp==null) throw new BadRequestException("you did not verification at all.");

        var passwordHash = _userManager.PasswordHasher.HashPassword(user, changePasswordModel.NewPassword);

        user.PasswordHash = passwordHash;

        await _unitOfWork.saveChangesAsync();
    }


    private DateTime getCurrentDay()
    {
        var date = DateTime.Now;
        var d = new DateTime(date.Year, (date.Date.Month + 1), date.Day, date.Hour, date.Minute, date.Second);
        return d;
    }

    private async Task sendEmail(string email, string otpCode)
    {
        var message = new MessageModel(new List<string>() { $"{email}" }, "Password reset verification", "This is the Otp code which is used to reset your password.");

        await _emailSender.sendEmailAsync(message, otpCode);
    }


    private string OtpGeneration()
    {
        const int LENGTH = 5;

        Random random = new Random();
        char[] otp = new char[LENGTH];

        string numbers = "0123456789";

        for (int i = 0; i < LENGTH; i++)
        {

            otp[i] = numbers[random.Next(numbers.Length)];
        }

        string result = string.Empty;

        // for (int i = 0; i < otp.Length; i++)
        // {
        //     result+=otp[i];
        // }

        otp.ToList().ForEach(p => result += p);

        return result;
    }


}