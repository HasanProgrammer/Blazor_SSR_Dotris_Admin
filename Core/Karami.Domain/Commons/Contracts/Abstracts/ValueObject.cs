namespace Karami.Domain.Commons.Contracts.Abstracts;

public abstract class ValueObject
{
    private static bool BaseEqual(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        return ReferenceEquals(left, right) || left.Equals(right);
    }

    private static bool BaseNotEqual(ValueObject left, ValueObject right) => !BaseEqual(left, right);
    
    protected abstract IEnumerable<object> GetEqualityComponents();
    
    /*---------------------------------------------------------------*/

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        ValueObject right = (ValueObject) obj;

        return GetEqualityComponents().SequenceEqual(right.GetEqualityComponents());
    }

    public override int GetHashCode()
        => GetEqualityComponents().Select(c => c != null ? c.GetHashCode() : 0)
                                  .Aggregate((x, y) => x ^ y);
    
    public static bool operator ==(ValueObject left, ValueObject right) => BaseEqual(left, right);

    public static bool operator !=(ValueObject left, ValueObject right) => BaseNotEqual(left, right);
}