using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    public class Knight : ChessPiece
    {
        //callback is used because function with similar functionality is named differently
        private Func<int, int, ChessCell> _knightCorner1, _knightCorner2;

        //any non-game functioning events like toggling highlights should be disabled here
        public override void ShowAllLegalActionCells(ChessGrid chessGrid, int x, int y)
        {
            //get upward left cells
            ChessCell initialPivot = chessGrid.GetUpwardLeftCell(x, y);
            _knightCorner1 = chessGrid.GetLeftwardCell;
            _knightCorner2 = chessGrid.GetUpwardCell;

            AddKnightCornerMoveCells(initialPivot);

            //get upward right cells
            initialPivot = chessGrid.GetUpwardRightCell(x, y);
            _knightCorner1 = chessGrid.GetRightwardCell;
            _knightCorner2 = chessGrid.GetUpwardCell;

            AddKnightCornerMoveCells(initialPivot);

            //get downward left cells
            initialPivot = chessGrid.GetDownwardLeftCell(x, y);
            _knightCorner1 = chessGrid.GetLeftwardCell;
            _knightCorner2 = chessGrid.GetDownwardCell;

            AddKnightCornerMoveCells(initialPivot);

            //get downward right cells
            initialPivot = chessGrid.GetDownwardRightCell(x, y);
            _knightCorner1 = chessGrid.GetRightwardCell;
            _knightCorner2 = chessGrid.GetDownwardCell;

            AddKnightCornerMoveCells(initialPivot);
        }

        private void AddKnightCornerMoveCells(ChessCell initialPivot)
        {
            if (initialPivot == null) return;
            int x = initialPivot.CoordinateX;
            int y = initialPivot.CoordinateY;
            EnableLegalCellsInTargetDirection(_knightCorner1, x, y, 1);
            EnableLegalCellsInTargetDirection(_knightCorner2, x, y, 1);
        }
    }
}

