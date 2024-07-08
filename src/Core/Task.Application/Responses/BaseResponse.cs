namespace Task.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
    }
    public class BaseResponse<T> : BaseResponse
    {
        public T Result { get; set; }
    }
}
