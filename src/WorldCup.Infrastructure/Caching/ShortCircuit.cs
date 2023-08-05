namespace WorldCup.Infrastructure.Caching
{
    internal class ShortCircuit<T>
    {
        private bool isShorted = false;

        public void CutCircuit()
        {
            isShorted = true;
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
