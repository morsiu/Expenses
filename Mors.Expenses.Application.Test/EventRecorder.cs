using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mors.Expenses.Application.Test
{
    internal sealed class EventRecorder : ICommandEnvironment
    {
        private List<object> _events = new List<object>();

        void ICommandEnvironment.PublishEvent(object @event)
        {
            _events.Add(@event);
        }

        internal void AssertRecordedEvent(Predicate<object> predicate)
        {
            Assert.Contains(_events, predicate);
        }

        internal void AssertRecordedNoEvents()
        {
            Assert.True(_events.Count == 0);
        }

        internal TEvent FindEvent<TEvent>()
        {
            return _events.OfType<TEvent>().FirstOrDefault(e => e != null);
        }
    }
}
