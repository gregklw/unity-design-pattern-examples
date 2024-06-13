using UnityEngine;
namespace MazeExample
{
    public class MoveRightCommand : IMazeCommand
    {
        private CharacterToMove _characterToMove;
        private Vector2 _direction;

        public MoveRightCommand(CharacterToMove characterToMove)
        {
            _characterToMove = characterToMove;
            _direction = Vector2.right;
        }
        public void Execute()
        {
            _characterToMove?.Move(_direction);
        }

        public void Undo()
        {
            _characterToMove?.Move(-_direction);
        }
    }
}