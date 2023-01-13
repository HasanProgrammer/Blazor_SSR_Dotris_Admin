using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Karami.Common.ClassWrappers;

public class JsonWebToken
{
    /// <summary>
    /// 
    /// </summary>
    public delegate Task ClaimsIdentityDelegate(ClaimsIdentity identity);
    
    /// <summary>
    /// 
    /// </summary>
    public delegate SecurityTokenDescriptor SecurityTokenDescriptorDelegate(SecurityTokenDescriptor descriptor, ClaimsIdentity identity, SigningCredentials credentials);
    
    /// <summary>
    /// 
    /// </summary>
    public delegate JsonResult ExecuteDelegate(string token);
    
    /// <summary>
    /// 
    /// </summary>
    public delegate Task<JsonResult> ExecuteDelegateAsync(string token);
    
    /*--------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    private readonly List<Claim> _Claims;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly SigningCredentials _SigningCredentials;
    
    /*--------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    private ClaimsIdentity _Identity;
    
    /// <summary>
    /// 
    /// </summary>
    private SecurityTokenDescriptor _TokenDescriptor;
    
    /*--------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    public JsonWebToken(string key)
    {
        _Claims = new List<Claim>();
        _SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    public JsonWebToken SetClaims(params Claim[] claims) //PayLoad's Data
    {
        _Claims.AddRange(claims);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delegate"></param>
    /// <returns></returns>
    public async Task<JsonWebToken> SetClaimsIdentity(ClaimsIdentityDelegate @delegate) //Identity's Data ( Role & Username ) | Payload's Data
    {
        _Identity = new ClaimsIdentity(_Claims);
        await @delegate(_Identity);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delegate"></param>
    /// <returns></returns>
    public JsonWebToken SetTokenDescriptor(SecurityTokenDescriptorDelegate @delegate) /*در این متد ، بدنه اصلی Token بر اساس معماری JWT ، ساخته میشود*/
    {
        _TokenDescriptor = @delegate(new SecurityTokenDescriptor(), _Identity, _SigningCredentials);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Execute() //Token
    {
        var handler = new JwtSecurityTokenHandler();
        var token   = handler.CreateToken(_TokenDescriptor);
        return handler.WriteToken(token);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<string> ExecuteAsync() //Token
    {
        var handler = new JwtSecurityTokenHandler();
        var token   = handler.CreateToken(_TokenDescriptor);
        return Task.FromResult(handler.WriteToken(token));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="delegate"></param>
    /// <returns></returns>
    public JsonResult Execute(ExecuteDelegate @delegate) //Token
    {
        var handler = new JwtSecurityTokenHandler();
        var token   = handler.CreateToken(_TokenDescriptor);
        return @delegate(handler.WriteToken(token));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="delegate"></param>
    /// <returns></returns>
    public Task<JsonResult> ExecuteAsync(ExecuteDelegateAsync @delegate) //Token
    {
        var handler = new JwtSecurityTokenHandler();
        var token   = handler.CreateToken(_TokenDescriptor);
        return @delegate(handler.WriteToken(token));
    }
}