namespace Karami.Domain.Commons.Exceptions;

public class InValidEntityException : Exception
{
    public InValidEntityException(){}
    
    public InValidEntityException(string message) : base(message)
    {
        
    }
}