namespace CodeApp.Application.Wrapper
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {

        }
        public BaseResponse(T data)
        {
            Data = data;
        }
        public BaseResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public BaseResponse(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public BaseResponse(T data, bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }
        public BaseResponse(string message, bool isSuccess, T data)
        {
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
        }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }
}
