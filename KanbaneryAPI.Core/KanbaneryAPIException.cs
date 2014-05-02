using System;

namespace KanbaneryAPI.Core
{
    class KanbaneryApiException : Exception
    {
         public KanbaneryApiException()
        {
        }

        public KanbaneryApiException(string message)
            : base(message)
        {

        }

        public KanbaneryApiException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
