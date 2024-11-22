namespace Web.Services
{
    public class StateMessageService
    {
        public event Func<Task> OnChange;

        public async Task NotifyStateChangedAsync()
        {
            if (OnChange != null)
            {
                foreach (var handler in OnChange.GetInvocationList())
                {
                    await ((Func<Task>)handler).Invoke();
                }
            }
        }
    }
}
