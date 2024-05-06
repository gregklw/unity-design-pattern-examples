//Concrete command
//ConcreteCommand
public class CookRecipeCommand : ICookingCommand
{
    private RobotChef _robotChef;
    private IRecipe _recipe;

    public CookRecipeCommand(RobotChef robotChef, IRecipe recipe)
    {
        _robotChef = robotChef;
        _recipe = recipe;
    }
    public void Execute()
    {
        _robotChef.CookRecipe(_recipe);
    }
}
