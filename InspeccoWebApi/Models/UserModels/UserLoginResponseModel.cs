using Utilities.Response;

namespace InspeccoWebApi.Models.UserModels
{
    public class UserLoginResponseModel
    {
        public Result Result { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int Id { get; set; }
    }
}
  