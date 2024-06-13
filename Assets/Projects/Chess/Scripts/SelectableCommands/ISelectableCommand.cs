namespace ChessExample 
{
    //abstract command
    public interface ISelectableCommand
    {
        void Execute();
        void Undo();
    }
}