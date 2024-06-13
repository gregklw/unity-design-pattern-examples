namespace MazeExample
{
    //abstract command
    public interface IMazeCommand
    {
        void Execute();
        void Undo();
    }
}

