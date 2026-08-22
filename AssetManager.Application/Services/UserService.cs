using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services.Interfaces;

namespace AssetManager.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}