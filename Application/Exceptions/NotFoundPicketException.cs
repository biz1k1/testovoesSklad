namespace Application.Exceptions
{
	public class NotFoundPicketException:InvalidOperationException
	{
		public NotFoundPicketException() : base($"Пикет/ы не найден/ы!")
		{
		}
	}
}
