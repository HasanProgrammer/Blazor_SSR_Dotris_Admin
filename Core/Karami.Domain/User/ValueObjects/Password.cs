using Karami.Common.ClassExtensions;
using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.User.ValueObjects;

public class Password : ValueObject
{
    public readonly string Value;

    public Password()
    {
        
    }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InValidValueObjectException("فیلد رمز عبور الزامی می باشد !");

        if (value.Length < 8)
            throw new InValidValueObjectException("فیلد رمز عبور نباید کمتر از 8 عبارت داشته باشد !");

        Value = value.HashAsync().Result;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}