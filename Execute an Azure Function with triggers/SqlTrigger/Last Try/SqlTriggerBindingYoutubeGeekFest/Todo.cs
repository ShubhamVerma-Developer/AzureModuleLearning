using System;

namespace SqlTriggerBindingYoutubeGeekFest
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class TodoItems { 
        public Todo[] Items { get; set; }
    }

}