using System.Collections.Generic;

//Invoker
//Not tightly coupled with a single cooking command to encourage reuse
public static class CookingCommandScheduler
{
    private static Queue<ICookingCommand> _mealQueue = new Queue<ICookingCommand>();

    public static void ScheduleMeal(ICookingCommand cookingCommand)
    {
        _mealQueue.Enqueue(cookingCommand);
    }

    public static void CookNextMeal()
    {
        ICookingCommand activeCookingCommand = _mealQueue.Dequeue();
        activeCookingCommand?.Execute();
    }
}
