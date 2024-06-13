using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessExample
{
    //invoker
    public static class MoveHistory
    {
        public static Stack<ISelectableCommand> MoveHistoryStack = new Stack<ISelectableCommand>();
    }
}

