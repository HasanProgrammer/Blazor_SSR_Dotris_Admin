using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.Permission.ValueObjects;

public class Name : ValueObject
{
    public readonly string Value;
    
    public Name() {}

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InValidValueObjectException("فیلد نام الزامی می باشد !");

        if (value.Length is > 50 or < 3)
            throw new InValidValueObjectException("فیلد نام نباید بیشتر از 50 و کمتر از 3 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}