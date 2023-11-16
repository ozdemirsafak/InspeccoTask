namespace InspeccoWebApi.Models.UserModels
{
	public class UserUpdateRequestModel
	{
        public int UserId { get; set; }
        public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
        public int UserRoleId { get; set; }
		public int Status { get; set; }
    }
}
  