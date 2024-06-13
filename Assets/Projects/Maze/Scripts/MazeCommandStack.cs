using System.Collections.Generic;
using UnityEngine;

namespace MazeExample 
{
    //invoker
    public class MazeCommandStack : MonoBehaviour
    {
        private Stack<IMazeCommand> _mazeCommands = new Stack<IMazeCommand>();

        public void ExecuteAndStoreMoveHistory(IMazeCommand mazeCommand) 
        {
            _mazeCommands.Push(mazeCommand);
            mazeCommand?.Execute();
        }

        public void UndoMove()
        {
            if (_mazeCommands.Count > 0) _mazeCommands?.Pop().Undo();
        }
    }
}
