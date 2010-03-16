namespace QWars.Presentation
{
    public interface ICreateGangView
    {
        object PlayerId { get; }
        string GangName { get; }
        string BossBenefit { get; }
    }
}