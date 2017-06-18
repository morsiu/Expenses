using System.Windows;

namespace Mors.Expenses.Client.Wpf
{
    public sealed class Bootstrapper
    {
        public UIElement Bootstrap()
        {
            return new MainPanel();
        }
    }
}
