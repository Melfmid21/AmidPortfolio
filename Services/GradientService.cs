using System.Timers;
namespace AmidPortfolio.Services
{
    public class GradientService : IDisposable
    {
        private readonly string[] _gradients =
        [
            "gradient-1",
            "gradient-2",
            "gradient-3",
            "gradient-4"
        ];

        private int _index = 0;
        private readonly System.Timers.Timer _timer;

        public string CurrentGradient { get; private set; } = "gradient-1";

        public event Action? OnChange;

        public GradientService()
        {
            _timer = new System.Timers.Timer(5000);

            _timer.Elapsed += (_, _) =>
            {
                _index++;

                if (_index >= _gradients.Length)
                    _index = 0;

                CurrentGradient = _gradients[_index];

                OnChange?.Invoke();
            };

            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
