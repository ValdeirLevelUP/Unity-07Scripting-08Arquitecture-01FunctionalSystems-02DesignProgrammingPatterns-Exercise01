public interface ICommand
{
    bool SelfTarget
    {
        get;
    }
    void Execute(ICharacter target);
}
