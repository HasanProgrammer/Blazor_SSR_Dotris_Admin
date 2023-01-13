using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Role.ValueObjects;

namespace Karami.Domain.Permission.Entities;

public class Permission : BaseEntity<string>
{
    //Value Objects
    
    public string RoleId { get; private set; }
    public Name Name     { get; private set; }
    
    /*---------------------------------------------------------------*/
    
    //Relations
    
    public Role.Entities.Role Role { get; set; }
    
    public ICollection<PermissionUser> PermissionUsers { get; set; }

    /*---------------------------------------------------------------*/
    
    //EF Core
    private Permission() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="roleId"></param>
    public Permission(string id, string name, string roleId)
    {
        Id     = id;
        RoleId = roleId;
        Name   = new Name(name);
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="roleId"></param>
    public void Change(string name, string roleId)
    {
        RoleId = roleId;
        Name   = new Name(name);
    }
}