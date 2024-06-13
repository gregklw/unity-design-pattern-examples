using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    //concrete command
    public class MoveCommand : ISelectableCommand
    {
        public ChessCell PreviousCell;
        public ChessCell NewCell;
        private ChessPiece _chessPiece;
        private bool _isFirstMove;
        private TurnManager _turnManager;

        public MoveCommand(ChessCell previousCell, ChessCell newCell, ChessPiece chessPiece, TurnManager turnManager)
        {
            NewCell = newCell;
            PreviousCell = previousCell;
            _chessPiece = chessPiece;
            _turnManager = turnManager;
        }
        public void Execute()
        {
            NewCell.CurrentChessPiece = _chessPiece;
            PreviousCell.CurrentChessPiece = null;
            _chessPiece.Transform.SetParent(NewCell.transform, false);
            _isFirstMove = !_chessPiece.IsFirstMoveDone;
            if (_isFirstMove) _chessPiece.IsFirstMoveDone = _isFirstMove;
            _turnManager?.OnCellCommand.Invoke();
        }
        public void Undo()
        {
            PreviousCell.CurrentChessPiece = _chessPiece;
            NewCell.CurrentChessPiece = null;
            _chessPiece.Transform.SetParent(PreviousCell.transform, false);
            _chessPiece.IsFirstMoveDone = !_isFirstMove;
        }
    }
}