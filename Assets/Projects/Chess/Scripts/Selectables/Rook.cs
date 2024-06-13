using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    //receiver
    public class Rook : ChessPiece
    {
        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardCell,x,y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetLeftwardCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetRightwardCell, x, y);
            ToggleLegalCells(true);
        }
    }
}

