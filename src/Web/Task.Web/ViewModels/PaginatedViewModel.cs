﻿using Task.Application.Responses;

namespace Task.Web.ViewModels
{
    public class PaginatedViewModel<T> where T : class
    {
        public T Items { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public PaginatedViewModel()
        {
            
        }
        public PaginatedViewModel(T items, PaginatedResponse<T> paginatedResponse)
        {
            Items = items;
            HasNextPage = paginatedResponse.HasNextPage;
            HasPreviousPage = paginatedResponse.HasPreviousPage;
            Page = paginatedResponse.Page;
            PageSize = paginatedResponse.PageSize;
            TotalCount = paginatedResponse.TotalCount;
            TotalPages = paginatedResponse.TotalPages;
        }
    }
}
