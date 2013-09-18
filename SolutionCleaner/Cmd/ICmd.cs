namespace SolutionCleaner.Cmd
{
    public interface ICmd
    {
        void Do(object options);

        bool Redo();
    }
}