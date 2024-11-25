namespace Application.Exceptions
{
	public class ServiceException:InvalidOperationException
	{
		public ServiceException(string messageError) : base($"Произошла непредвиденная ошибка {messageError}.")
		{
		}
	}
}
