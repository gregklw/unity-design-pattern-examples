using UnityEngine;

public class UserInput : MonoBehaviour
{
    private Lightbulb _lightbulb;
    private Lightswitch _lightswitch;

    private void Start()
    {
        ICommand turnOnCommand = new TurnOnCommand(_lightbulb);
        _lightswitch = new Lightswitch(turnOnCommand);
    }

    public void PowerOn()
    {
        _lightswitch.PowerOn();
    }
}
