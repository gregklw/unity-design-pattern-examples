using ChessExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class Bishop : ChessPiece
    {
        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardLeftCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetUpwardRightCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardLeftCell, x, y);
            EnableLegalCellsInTargetDirection(chessGrid.GetDownwardRightCell, x, y);
            ToggleLegalCells(true);
        }
    }
}

