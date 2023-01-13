using Karami.Domain.Commons.Exceptions;

namespace Karami.Domain.Commons.ValueObjects;

public class CreatedAt
{
    public DateTime? EnglishDate { get; private set; }
    public string PersianDate    { get; private set; }

    public CreatedAt(DateTime? englishDate , string persianDate)
    {
        if (englishDate == null || string.IsNullOrWhiteSpace(persianDate))
            throw new InValidValueObjectException("فیلد تاریخ ساخت الزامی می باشد !");
        
        EnglishDate = englishDate;
        PersianDate = persianDate;
    }
}