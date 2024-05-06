using UnityEngine;

//sender
namespace MazeExample
{
    public class MazeUserInput : MonoBehaviour
    {
        private CharacterToMove _characterToMove;
        private MazeCommandStack _mazeCommandQueue;

        // Start is called before the first frame update
        void Start()
        {
            _characterToMove = FindObjectOfType<CharacterToMove>();
            _mazeCommandQueue = FindObjectOfType<MazeCommandStack>();
        }

        public void MoveUp()
        {
            IMazeCommand moveUpCommand = new MoveUpCommand(_characterToMove);
            _mazeCommandQueue.ExecuteAndStoreMoveHistory(moveUpCommand);
        }

        public void MoveLeft()
        {
            IMazeCommand moveLeftCommand = new MoveLeftCommand(_characterToMove);
            _mazeCommandQueue.ExecuteAndStoreMoveHistory(moveLeftCommand);
        }

        public void MoveDown()
        {
            IMazeCommand moveDownCommand = new MoveDownCommand(_characterToMove);
            _mazeCommandQueue.ExecuteAndStoreMoveHistory(moveDownCommand);
        }
        public void MoveRight()
        {
            IMazeCommand moveRightCommand = new MoveRightCommand(_characterToMove);
            _mazeCommandQueue.ExecuteAndStoreMoveHistory(moveRightCommand);
        }

        public void UndoMove()
        {
            _mazeCommandQueue.UndoMove();
        }
    }
}