namespace Karami.Common.ClassHelpers;

public class PaginatedList<T>
{
    public int PageNumber       { get; set; } /*شماره صفحه فعلی*/
    public int CountItemPerPage { get; set; } /*تعداد داده های قابل نمایش برای هر صفحه*/
    public int TotalPages       { get; set; } /*تعداد کل صفحات بر اساس تعداد ردیف های Entity مورد نظر و با در نظر گرفتن CountSizePerPage*/

    /*----------------------------------------------------------*/
        
    public bool HasPrev => PageNumber > 1;          /*در این قسمت بررسی می شود که آیا لینک صفحه قبلی فعال باشد یا خیر*/
    public bool HasNext => PageNumber < TotalPages; /*در این قسمت بررسی می شود که آیا لینک صفحه بعدی فعال باشد یا خیر*/

    /*----------------------------------------------------------*/
    
    public IEnumerable<T> Collection { get; set; }

    /*----------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    public PaginatedList() {}
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Data"></param>
    /// <param name="CountRowData"></param>
    /// <param name="CountItemPerPage"></param>
    /// <param name="PageNumber"></param>
    public PaginatedList(IEnumerable<T> Data, long CountRowData, int CountItemPerPage, int PageNumber)
    {
        this.PageNumber       = PageNumber;
        this.CountItemPerPage = CountItemPerPage;
        this.TotalPages       = (int)Math.Ceiling(CountRowData / (double) CountItemPerPage);
        Collection            = Data;
    }
}