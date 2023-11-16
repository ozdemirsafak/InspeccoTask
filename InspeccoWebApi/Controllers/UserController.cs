using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using InspeccoWebApi.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Utilities.Response;

namespace InspeccoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel request)
        {
            UserRegisterResponseModel responseModel = new UserRegisterResponseModel();
            if (request!=null)
            {
				Result<User> addResult = _userService.Register(new User
                {
                    Username = request.UserName,
                    Password = request.Password,
                    Email = request.Email,
                    Status = 1,
					UserRoleId = request.UserId.HasValue != true ? 0 : request.UserId.Value
				});

                if (addResult.IsSuccess)
                    responseModel.UserId = addResult.Data.Id;

				responseModel.Result = addResult;
			}
            return Ok(responseModel);
        }  

		[Route("Update")]
		[HttpPost]
		public IActionResult Update(UserUpdateRequestModel request)
		{
			UserUpdateResponseModel responseModel = new UserUpdateResponseModel();
			if (request != null)
			{
				Result<User> addResult = _userService.Update(new User
				{
					Username = request.UserName,
					Password = request.Password,
					Email = request.Email,
					UserRoleId = request.UserRoleId,
					Id = request.UserId,
					Status = request.Status,
				});

				if (addResult.IsSuccess)
					responseModel.UserId = addResult.Data.Id;

				responseModel.Result = addResult;
			}
			return Ok(responseModel);
		}

		[Route("Login")]
		[HttpPost]
		public IActionResult UserLogin([FromBody]UserLoginRequestModel requestModel)
		{
            UserLoginResponseModel result = new UserLoginResponseModel();

            if (requestModel!=null && !string.IsNullOrEmpty(requestModel.Email))
			{
				Result<User> userResult = _userService.Login(requestModel.Email, requestModel.Password);
				result.Result = userResult;
				if (userResult.IsSuccess)
				{
					result.UserEmail = userResult.Data.Email;
					result.UserName = userResult.Data.Username;
					result.Id = userResult.Data.Id;
				}
			}


			return Ok(result);
		}

		[Route("Remove")]
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			UserUpdateResponseModel responseModel = new UserUpdateResponseModel();
			if (Id != null)
			{
				Result<User> addResult = _userService.Remove(Id);

				if (addResult.IsSuccess)
					responseModel.UserId = addResult.Data.Id;

				responseModel.Result = addResult;
			}
			return Ok(responseModel);
		}
	}

	
}
