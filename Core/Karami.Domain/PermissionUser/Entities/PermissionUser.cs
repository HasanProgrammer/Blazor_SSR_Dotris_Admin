using Karami.Domain.Commons.Contracts.Abstracts;

namespace Karami.Domain.Permission.Entities;

public class PermissionUser : BaseEntity<string>
{
    //Value Objects
    
    public string UserId       { get; private set; }
    public string PermissionId { get; private set; }
    
    /*---------------------------------------------------------------*/
    
    //Relations
    
    public Permission Permission   { get; set; }
    public User.Entities.User User { get; set; }
    
    /*---------------------------------------------------------------*/
    
    //EF Core
    private PermissionUser() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <param name="permissionId"></param>
    public PermissionUser(string id, string userId, string permissionId)
    {
        Id           = id;
        UserId       = userId;
        PermissionId = permissionId;
    }
}