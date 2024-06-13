using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class Queen : ChessPiece
    {
        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardCell,x,y);
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardLeftCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardRightCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetLeftwardCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetRightwardCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardLeftCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardRightCell, x, y);
            ToggleLegalCells(true);
        }
    }
}

