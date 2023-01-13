using Karami.UseCase.Commons.Contracts.Interfaces;

namespace Karami.UseCase.UserUseCase.Commands.SignInUser;

public class SignInUserCommand : ICommand<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}