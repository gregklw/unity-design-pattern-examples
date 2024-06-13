public class TurnOnCommand : ICommand
{
    private Lightbulb _lightbulb;
    public TurnOnCommand(Lightbulb lightbulb)
    {
        _lightbulb = lightbulb;
    }
    public void Execute()
    {
        _lightbulb.TurnOn();
    }
}
