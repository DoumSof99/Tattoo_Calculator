using Tattoo_Calculator.Controls;

namespace Tattoo_Calculator {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TattooPage), typeof(TattooPage));
        }
    }
}
