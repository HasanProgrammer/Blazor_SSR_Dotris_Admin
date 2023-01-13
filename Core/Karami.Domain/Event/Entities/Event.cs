using Karami.Domain.Commons.Enumerations;
using Karami.Domain.Commons.ValueObjects;
using MD.PersianDateTime.Standard;

#pragma warning disable CS0649

namespace Karami.Domain.Event.Entities;

public class Event : Commons.Contracts.Abstracts.Entity<string>
{
    //Value Objects
    
    public string Type        { get; private set; } //Name Of Event
    public string Service     { get; private set; } //Name Of Service
    public string Payload     { get; private set; }
    public string Table       { get; private set; }
    public string Action      { get; private set; } //CREATE | UPDATE | DELETE
    public string User        { get; private set; } //Username
    
    /*---------------------------------------------------------------*/

    //EF Core
    private Event() {}

    public Event(string type, string service, string payload, string table, string action, string user)
    {
        Id = Guid.NewGuid().ToString();
        
        DateTime Now      = DateTime.Now;
        string NowPersian = new PersianDateTime(Now).ToShortDateString();
        
        Type     = type;
        Service  = service;
        Payload  = payload;
        Table    = table;
        Action   = action;
        User     = user;

        CreatedAt = new CreatedAt(Now, NowPersian);
        UpdatedAt = new UpdatedAt(Now, NowPersian);
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors

    public void ChangeActivation(IsActive isActive) => IsActive = isActive;
}