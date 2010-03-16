namespace QWars.Dummy.Entities
{
    public class Task
    {
        public string Description { get; private set; }

        public Task(string description)
        {
            Description = description;
        }
    }
}