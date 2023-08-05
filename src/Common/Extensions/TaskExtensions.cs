using System.Runtime.CompilerServices;

namespace Common
{
    public static class TaskExtensions
    {
        public static bool DefaultConfigureAwait { get; } = false;

        public static Task<T> AsCompletedTask<T>(this T obj) => Task.FromResult(obj);

        public static ConfiguredTaskAwaitable DefaultAwait(this Task task) => task.ConfigureAwait(DefaultConfigureAwait);

        public static ConfiguredTaskAwaitable<T> DefaultAwait<T>(this Task<T> task) => task.ConfigureAwait(DefaultConfigureAwait);
    }
}
