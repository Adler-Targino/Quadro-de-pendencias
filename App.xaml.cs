using Microsoft.Extensions.DependencyInjection;

namespace Quadro_de_pendencias
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if DEBUG
            UserAppTheme = AppTheme.Dark;
#endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}