namespace InspeccoWebApi.Models
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
    }

    public class ErrorResponseModel : BaseResponseModel
    {
        public string ErrorMessage { get; set; }
    }
}
