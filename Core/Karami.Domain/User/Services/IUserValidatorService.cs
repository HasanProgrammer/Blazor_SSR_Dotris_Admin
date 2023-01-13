namespace Karami.Domain.User.Services;

public interface IUserValidatorService
{
    public void CheckUsernameAlreadyExists(string username) => throw new NotImplementedException();
    public Task CheckUsernameAlreadyExistsAsync(string username) => throw new NotImplementedException();
    public void CheckPhoneNumberAlreadyExists(string phoneNumber) => throw new NotImplementedException();
    public Task CheckPhoneNumberAlreadyExistsAsync(string phoneNumber) => throw new NotImplementedException();
    public void CheckEmailAlreadyExists(string email) => throw new NotImplementedException();
    public Task CheckEmailAlreadyExistsAsync(string email) => throw new NotImplementedException();
}