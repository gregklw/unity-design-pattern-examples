public class Lightswitch
{
    private ICommand _onCommand;
    public Lightswitch(ICommand onCommand)
    {
        _onCommand = onCommand;
    }

    public void PowerOn()
    {
        _onCommand.Execute();
    }
}
