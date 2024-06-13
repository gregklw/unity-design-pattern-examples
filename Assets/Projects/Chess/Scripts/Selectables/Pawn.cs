using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class Pawn : ChessPiece
    {
        private Func<int, int, ChessCell> _pawnCellDirection;

        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            if (PlayerOwnership == PlayerEnum.PLAYER1) _pawnCellDirection = chessGrid.GetUpwardCell;
            else if (PlayerOwnership == PlayerEnum.PLAYER2) _pawnCellDirection = chessGrid.GetDownwardCell;

            ChessCell initialUpwardCell = _pawnCellDirection(x, y);
            if (!IsFirstMoveDone)
            {
                EnableLegalCellsInTargetDirection(_pawnCellDirection, x, y, 2);
            }
            else
            {
                EnableLegalCellsInTargetDirection(_pawnCellDirection, x, y, 1);
            }
            ToggleLegalCells(true);
        }

    }
}