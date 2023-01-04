using Microsoft.EntityFrameworkCore;

namespace MvcOffice.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            //队列为A 数量为19 页数为19/3=7   显示数量为3
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            //比如第二页 那么显示的应该是抛去前面一页3数量剩下的 所要的的规定的数量（比如pagesize=3 ）或者少于3
            //比如第三页 那么显示的应该是抛去前面两页6数量剩下的 所要的的规定的数量（比如pagesize=3 ）或者少于3
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }



    }
}
