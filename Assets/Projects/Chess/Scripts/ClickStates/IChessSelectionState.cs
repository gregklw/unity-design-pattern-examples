namespace ChessExample
{
    //should handle selection input of clicking chess cell
    public interface IChessSelectionState
    {
        IChessSelectionState Execute(ChessCell currentCell);
    }
}