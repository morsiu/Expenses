namespace Mors.Expenses.Application.Test
{
    internal sealed class CommandEnvironmentDummy : ICommandEnvironment
    {
        public void PublishEvent(object @event)
        {
        }
    }
}
