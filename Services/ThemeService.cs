using MudBlazor;

namespace AmidPortfolio.Services
{
    public class ThemeService
    {
        public bool IsDarkMode { get; private set; } = true;

        public MudTheme CurrentTheme { get; private set; }

        public event Action? OnChange;

        public ThemeService()
        {
            CurrentTheme = BuildTheme(false);
        }

        public void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            CurrentTheme = BuildTheme(IsDarkMode);
            OnChange?.Invoke();
        }

        private MudTheme BuildTheme(bool dark)
        {
            return new MudTheme()
            {
                PaletteLight = new PaletteLight()
                {
                    Primary = "#3B82F6",
                    Background = "#F5F7FB",
                    Surface = "#FFFFFF"
                },
                PaletteDark = new PaletteDark()
                {
                    Primary = "#3B82F6",
                    Secondary = "#8B5CF6",

                    Background = "#0F172A",
                    Surface = "#1E293B",

                    AppbarBackground = "#0F172A",
                    DrawerBackground = "#1E293B",

                    TextPrimary = "#F8FAFC",
                    TextSecondary = "#94A3B8"
                }
                //PaletteDark = new PaletteDark()
                //{
                //    Primary = "#3B82F6",
                //    Background = "#0F172A",
                //    Surface = "#111827",
                //    AppbarBackground = "#111827",
                //    TextPrimary = "#FFFFFF",
                //    TextSecondary = "#CBD5E1"
                //}
            };
        }
    }
    }
