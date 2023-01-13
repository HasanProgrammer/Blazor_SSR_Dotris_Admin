using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.Commons.ValueObjects;

public class UpdatedAt
{
    public DateTime? EnglishDate { get; private set; }
    public string PersianDate    { get; private set; }
    
    public UpdatedAt(DateTime? englishDate , string persianDate)
    {
        if (englishDate == null || string.IsNullOrWhiteSpace(persianDate))
            throw new InValidValueObjectException("فیلد تاریخ بروز رسانی الزامی می باشد !");
        
        EnglishDate = englishDate;
        PersianDate = persianDate;
    }
}