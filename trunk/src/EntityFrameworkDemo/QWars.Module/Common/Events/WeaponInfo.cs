namespace QWars.Module.Common.Events
{
    public class WeaponInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public WeaponInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("WeaponInfo({0} - {1})", Id, Name);
        }
    }
}
