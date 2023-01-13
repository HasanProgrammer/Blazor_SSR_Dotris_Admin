using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Role.ValueObjects;

#pragma warning disable CS0649

namespace Karami.Domain.Role.Entities;

public class Role : BaseEntity<string>
{
    //Value Objects
    
    public Name Name { get; private set; }

    /*---------------------------------------------------------------*/
    
    //Relations
    
    public ICollection<RoleUser.Entities.RoleUser> RoleUsers       { get; set; }
    public ICollection<Permission.Entities.Permission> Permissions { get; set; }

    /*---------------------------------------------------------------*/

    //EF Core
    private Role() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public Role(string id, string name)
    {
        Id   = id;
        Name = new Name(name);
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public void Change(string name)
    {
        Name = new Name(name);
    }
}