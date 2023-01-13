using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.User.ValueObjects;

public class Username : ValueObject
{
    public readonly string Value;
    
    public Username() {}

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InValidValueObjectException("فیلد نام کاربری الزامی می باشد !");

        if (value.Length is > 30 or < 8)
            throw new InValidValueObjectException("فیلد نام کاربری نباید بیشتر از 30 و کمتر از 8 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}