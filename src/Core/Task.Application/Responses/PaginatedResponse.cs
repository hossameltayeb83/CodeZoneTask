namespace Task.Application.Responses
{
    public class PaginatedResponse<T>
    {
        public IReadOnlyCollection<T> Items { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasNextPage => (Page * PageSize) < TotalCount;
        public bool HasPreviousPage => Page > 1;


        public PaginatedResponse(IReadOnlyCollection<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
        }

    }
}
