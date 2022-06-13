using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApplication.Controller;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _account;


    private readonly ILogger<AccountController> _logger;

    public AccountController(IAccountService account, ILogger<AccountController> logger)
    {
        _account = account;
        _logger = logger;
    }


    [HttpPost]
    [Route("signup")]
    [Authorize(Roles ="ADMIN,LEADERSHIP")]
    public async Task<IActionResult> Signup(SignupModel signupModel)
    {
        if (signupModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        var result = await _account.Signup(signupModel);

        return Ok(result);
    }

    [HttpPost]
    [Route("signin")]
    public async Task<IActionResult> Signin(SigninModel signinModel)
    {
        if (signinModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        var result = await _account.Signin(signinModel);

        return Ok(result);
    }

    [HttpPost]
    [Route("password-reset")]
    public async Task<IActionResult> PasswordReset(PasswordResetModel passwordResetModel)
    {
        if (passwordResetModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        await _account.PasswordReset(passwordResetModel);

        return NoContent();
    }

    [HttpPost]
    [Route("verify-otp")]
    public async Task<IActionResult> VerifyOtp(VerifyCodeModel verifyCodeModel)
    {
        if (verifyCodeModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        await _account.VerifyCode(verifyCodeModel);

        return NoContent();
    }

    [HttpPost]
    [Route("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
    {
        if (changePasswordModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        await _account.ChangePassword(changePasswordModel);

        return NoContent();
    }
}