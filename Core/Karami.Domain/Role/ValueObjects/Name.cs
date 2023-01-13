using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.Role.ValueObjects;

public class Name : ValueObject
{
    public readonly string Value;
    
    public Name() {}

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            throw new InValidValueObjectException("فیلد نام الزامی می باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}