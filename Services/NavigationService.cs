namespace AmidPortfolio.Services
{
    using Microsoft.JSInterop;


        public class NavigationService
        {
            private readonly IJSRuntime _js;

            public event Action<string>? OnSectionChanged;

            public string ActiveSection { get; private set; } = "home";

            public NavigationService(IJSRuntime js)
            {
                _js = js;
            }

            public async Task ScrollTo(string id)
            {
                await _js.InvokeVoidAsync("scrollToSection", id);
                ActiveSection = id;
                OnSectionChanged?.Invoke(id);
            }

            public void SetActiveSection(string section)
            {
                if (section == ActiveSection)
                    return;

                ActiveSection = section;
                OnSectionChanged?.Invoke(section);
            }

        public async Task UpdateActiveFromScroll()
            {
                var section = await _js.InvokeAsync<string>("getActiveSection");

                if (section != ActiveSection)
                {
                    ActiveSection = section;
                    OnSectionChanged?.Invoke(section);
                }
            }
        }
    

}
