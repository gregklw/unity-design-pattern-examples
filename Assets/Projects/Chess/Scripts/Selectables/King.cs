using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class King : ChessPiece
    {
        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetLeftwardCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetRightwardCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardLeftCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardRightCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardLeftCell, x, y, 1);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardRightCell, x, y, 1);
        }
    }
}