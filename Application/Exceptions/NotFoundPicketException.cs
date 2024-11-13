namespace Application.Exceptions
{
	public class NotFoundPicketException:InvalidOperationException
	{
		public NotFoundPicketException(int picketId) : base($"Пикет с Id: {picketId} не найден!")
		{
		}
	}
}
