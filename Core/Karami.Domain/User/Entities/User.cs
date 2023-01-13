#pragma warning disable CS0649

using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Enumerations;
using Karami.Domain.User.ValueObjects;

namespace Karami.Domain.User.Entities;

public class User : BaseEntity<string>
{
    //Value Objects

    public FirstName FirstName { get; private set; }
    public LastName LastName   { get; private set; }
    public Username Username   { get; private set; }
    public Password Password   { get; private set; }
    public IsActive IsActive   { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations

    public ICollection<RoleUser.Entities.RoleUser> RoleUsers               { get; set; }
    public ICollection<Permission.Entities.PermissionUser> PermissionUsers { get; set; }

    /*---------------------------------------------------------------*/

    //EF Core
    private User() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="isActive"></param>
    public User(string id, string firstName, string lastName, string username, string password, bool isActive)
    {
        Id        = id;
        FirstName = new FirstName(firstName);
        LastName  = new LastName(lastName);
        Username  = new Username(username);
        Password  = new Password(password);
        IsActive  = isActive ? IsActive.Active : IsActive.InActive;
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="isActive"></param>
    public void Change(string firstName, string lastName, string username, string password, bool isActive)
    {
        FirstName = new FirstName(firstName);
        LastName  = new LastName(lastName);
        Username  = new Username(username);
        Password  = new Password(password);
        IsActive  = isActive ? IsActive.Active : IsActive.InActive;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Active() => IsActive = IsActive.Active;
    
    /// <summary>
    /// 
    /// </summary>
    public void InActive() => IsActive = IsActive.InActive;
}