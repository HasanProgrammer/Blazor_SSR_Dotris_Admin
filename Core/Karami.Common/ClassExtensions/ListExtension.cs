using Karami.Common.ClassHelpers;

namespace Karami.Common.ClassExtensions;

public static class ListExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="List"></param>
    /// <param name="Total"></param>
    /// <param name="CountSizePerPage"></param>
    /// <param name="CurrentPageNumber"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static PaginatedList<T> ConvertToPaginatedList<T>(this IEnumerable<T> List, long Total , int CountSizePerPage, int CurrentPageNumber) 
        => new(List, Total, CountSizePerPage, CurrentPageNumber);
}