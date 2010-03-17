namespace QWars.Presentation.Entities
{
    /// <summary>
    /// Simple DTO to be passed around between views
    /// </summary>
    public class PlayerInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public PlayerInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}