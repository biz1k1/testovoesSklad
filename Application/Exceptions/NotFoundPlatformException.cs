namespace Application.Exceptions
{
	public class NotFoundPlatformException: InvalidOperationException
	{
		public NotFoundPlatformException(int platformId) : base($"Площадка с Id: {platformId} не найдена!")
		{
		}
	}
}
