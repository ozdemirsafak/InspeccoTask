using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.Response
{
	public class Result
	{
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

		public Result SetStatus(bool status)
		{
			this.IsSuccess = status;
			return this;
		}

		public Result SetMessage(string message)
		{
			this.Message = message;
			return this;
		}

	}

	public class Result<T>: Result where T : class,new()
	{
		public T Data { get; set; }
		public Result SetData(T data)
		{
			this.Data = data;
			return this;
		}
	}
}
