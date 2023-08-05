namespace WorldCup.Infrastructure.Caching
{
    internal class ShortCircuit<T>
    {
        private object _lock = new object();
        private bool isShorted = false;

        public void CutCircuit()
        {
            lock(_lock)
            {
                if(!isShorted)
                {
                    isShorted = true;

                    Task.Run(() =>
                    {
                        Thread.Sleep(TimeSpan.FromMinutes(10));
                        isShorted = false;
                    });
                }
            }
        }

        public async Task PassCircuit(Func<Task> action)
        {
            if (!isShorted)
            {
                try
                {
                    await action();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<T> PassCircuit(Func<Task<T>> action, T defaultValue)
        {
            if (!isShorted)
            {
                try
                {
                    return await action();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return defaultValue;
        }
    }
}
