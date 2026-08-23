using AssetManager.Application.DTOs.Users;
using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Security.Interfaces;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Entities;
using AssetManager.Application.Validators.Users;

namespace AssetManager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly RegisterUserValidator _registerUserValidator;
    private readonly LoginUserValidator _loginUserValidator;

    public UserService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    RegisterUserValidator registerUserValidator,
    LoginUserValidator loginUserValidator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _registerUserValidator = registerUserValidator;
        _loginUserValidator = loginUserValidator;
    }

    public async Task<User> RegisterAsync(RegisterUserDto request)
    {
        _registerUserValidator.Validate(request);

        if (await _userRepository.ExistsByUsernameAsync(request.Username))
            throw new InvalidOperationException("Username already exists.");

        if (await _userRepository.ExistsByPhoneNumberAsync(request.PhoneNumber))
            throw new InvalidOperationException("Phone number already exists.");

        var user = new User
        {
            Username = request.Username,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = _passwordHasher.Hash(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        return await _userRepository.CreateAsync(user);
    }
    public async Task<User?> LoginAsync(LoginUserDto request)
    {
        _loginUserValidator.Validate(request);

        var users = await _userRepository
            .GetByUsernameOrPhoneAsync(request.UsernameOrPhone);

        var user = users.FirstOrDefault();

        if (user is null)
            return null;

        var isPasswordValid = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash);

        if (!isPasswordValid)
            return null;

        return user;
    }
}