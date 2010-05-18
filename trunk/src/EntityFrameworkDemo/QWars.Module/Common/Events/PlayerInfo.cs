namespace QWars.Module.Common
{
    public class PlayerInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public PlayerInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("PlayerInfo({0} - {1})", Id, Name);
        }
    }
}
