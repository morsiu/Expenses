namespace Mors.Expenses.Application
{
    public interface ICommandEnvironment
    {
        void PublishEvent(object @event);
    }
}
