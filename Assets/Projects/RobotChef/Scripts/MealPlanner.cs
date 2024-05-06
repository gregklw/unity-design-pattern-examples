//Client
using UnityEngine;

public class MealPlanner : MonoBehaviour
{
    private RobotChef _robotChef;
    private IRecipe _recipe;
    public void ScheduleCookingCommand()
    {
        ICookingCommand cookSomething = new CookRecipeCommand(_robotChef, _recipe);
        CookingCommandScheduler.ScheduleMeal(cookSomething);
    }
}
