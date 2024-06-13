using UnityEngine;

namespace ChessExample
{
    public class SelectedPieceState : IChessSelectionState
    {
        private ChessGrid _chessGrid;
        private ChessCell _cellDuringSelection;
        private TurnManager _turnManager;
        public SelectedPieceState(ChessGrid chessGrid, ChessCell cellDuringSelection, TurnManager turnManager)
        {
            _chessGrid = chessGrid;
            _cellDuringSelection = cellDuringSelection;
            _cellDuringSelection.ChangeHighlightColour(ChessCellStateColours.SelectedCellColour);
            _turnManager = turnManager;
        }

        public IChessSelectionState Execute(ChessCell currentCell)
        {
            ChessPiece previouslySelectedPiece = _cellDuringSelection.CurrentChessPiece;
            //need to somehow reference the cell that was initially selected
            if (currentCell != null)
            {
                if (currentCell.CurrentChessPiece != null)
                {
                    if (currentCell.CurrentChessPiece.PlayerOwnership == _turnManager.CurrentPlayerTurn)
                    {
                        return DifferentPieceSameOwnerCase(previouslySelectedPiece, currentCell);
                    }
                    else
                    {
                        return DifferentPieceOwnerCase(previouslySelectedPiece, currentCell);
                    }
                }
                else if (currentCell.IsLegalSelectableCell)
                {
                    LegalCellSelectionCase(currentCell);
                }
            }
            previouslySelectedPiece.ToggleLegalCells(false);
            _cellDuringSelection.ChangeHighlightColour(ChessCellStateColours.InactiveCellColour);
            return new UnselectedState(_chessGrid, _turnManager);
        }

        public void SetCellDuringSelection(ChessCell previousCell)
        {
            _cellDuringSelection = previousCell;
        }

        private IChessSelectionState DifferentPieceSameOwnerCase(ChessPiece previouslySelectedPiece, ChessCell currentCell)
        {
            previouslySelectedPiece.ToggleLegalCells(false);
            _cellDuringSelection.ChangeHighlightColour(ChessCellStateColours.InactiveCellColour);
            _cellDuringSelection = currentCell;
            _cellDuringSelection.ChangeHighlightColour(ChessCellStateColours.SelectedCellColour);
            currentCell.CurrentChessPiece.ShowAllLegalActionCells(_chessGrid, currentCell.CoordinateX, currentCell.CoordinateY);
            return this;
        }

        private IChessSelectionState DifferentPieceOwnerCase(ChessPiece previouslySelectedPiece, ChessCell currentCell)
        {
            previouslySelectedPiece.ToggleLegalCells(false);
            _cellDuringSelection.ChangeHighlightColour(ChessCellStateColours.InactiveCellColour);
            return new UnselectedState(_chessGrid, _turnManager);
        }

        private void LegalCellSelectionCase(ChessCell currentCell)
        {
            _cellDuringSelection.CurrentChessPiece.Execute(new MoveCommand(_cellDuringSelection, currentCell, _cellDuringSelection.CurrentChessPiece, _turnManager));
        }
    }
}

