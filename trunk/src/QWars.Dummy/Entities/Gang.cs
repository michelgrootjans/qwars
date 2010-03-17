namespace QWars.Dummy.Entities
{
    public class Gang
    {
        public string Name { get; private set; }

        public Gang(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}