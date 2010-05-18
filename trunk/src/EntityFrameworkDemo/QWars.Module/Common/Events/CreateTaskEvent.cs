using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using QWars.Entities;

namespace QWars.Module.Common.Events
{
    class CreateTaskEvent : CompositePresentationEvent<Task>
    {
    }
}
