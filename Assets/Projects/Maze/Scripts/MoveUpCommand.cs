using UnityEngine;

namespace MazeExample
{
    //concrete command
    public class MoveUpCommand : IMazeCommand
    {
        private CharacterToMove _characterToMove;
        private Vector2 _direction;
        public MoveUpCommand(CharacterToMove characterToMove)
        {
            _characterToMove = characterToMove;
            _direction = Vector2.up;
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

