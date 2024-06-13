using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class UnselectedState : IChessSelectionState
    {
        private ChessGrid _chessGrid;
        private TurnManager _turnManager;
        public UnselectedState(ChessGrid chessGrid, TurnManager turnManager)
        {
            _chessGrid = chessGrid;
            _turnManager = turnManager;
        }
        public IChessSelectionState Execute(ChessCell currentCell)
        {
            //incase you clicked nothing
            if (currentCell == null) return this;

            if (currentCell.CurrentChessPiece != null && currentCell.CurrentChessPiece.PlayerOwnership == _turnManager.CurrentPlayerTurn)
            { 
                currentCell.CurrentChessPiece.ShowAllLegalActionCells(_chessGrid, currentCell.CoordinateX, currentCell.CoordinateY);
                SelectedPieceState selectedPieceState = new SelectedPieceState(_chessGrid, currentCell, _turnManager);
                return selectedPieceState;
            }
            return this;
        }
    }
}