using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.User.ValueObjects;

public class LastName : ValueObject
{
    public readonly string Value;

    public LastName() {}

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InValidValueObjectException("فیلد نام خانوادگی الزامی می باشد !");

        if (value.Length is > 80 or < 3)
            throw new InValidValueObjectException("فیلد نام خانوادگی نباید بیشتر از 50 و کمتر از 3 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}