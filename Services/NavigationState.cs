namespace AmidPortfolio.Services
{
    public class NavigationState
    {
        public string ActiveSection { get; set; } = "home";

        public event Action? OnChange;

        public void SetActiveSection(string section)
        {
            ActiveSection = section;
            OnChange?.Invoke();
        }
    }
}
