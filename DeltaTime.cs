using System.Diagnostics;

namespace Teste1
{
    internal class DeltaTime
    {
        readonly Stopwatch stopwatch = new();

        public DeltaTime()
        {
            stopwatch.Start();
        }

        public float GetDeltaTime()
        {
            float deltaTime = (float)stopwatch.Elapsed.TotalSeconds;

            stopwatch.Restart();

            return deltaTime;
        }
    }
}
