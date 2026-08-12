using Quadro_de_pendencias.Data;

namespace Quadro_de_pendencias
{
    public partial class App : Application
    {
        private readonly DatabaseService _databaseService;
        public App(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;

#if DEBUG
            UserAppTheme = AppTheme.Dark;
#endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            _databaseService.InitializeAsync().GetAwaiter().GetResult();

            return new Window(new AppShell());
        }
    }
}