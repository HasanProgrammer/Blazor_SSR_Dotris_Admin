using Karami.Domain.Commons.Contracts.Abstracts;

namespace Karami.Domain.RoleUser.Entities;

public class RoleUser : BaseEntity<string>
{
    //Value Objects
    
    public string UserId { get; private set; }
    public string RoleId { get; private set; }
    
    /*---------------------------------------------------------------*/
    
    //Relations
    
    public Role.Entities.Role Role        { get; set; }
    public Domain.User.Entities.User User { get; set; }
    
    /*---------------------------------------------------------------*/

    //EF Core
    private RoleUser() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    public RoleUser(string id, string userId , string roleId)
    {
        Id     = id;
        UserId = userId;
        RoleId = roleId;
    }
}