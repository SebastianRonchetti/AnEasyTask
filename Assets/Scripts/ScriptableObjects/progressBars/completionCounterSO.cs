using UnityEngine;

public class completionCounterSO : progressBarSO {
    public void setGoal(int goalToSet){
        Goal = goalToSet;
    }

    public void counterUp()
    {
        counter += 1;
        if(counter >= Goal)
        {
            //finish task
        }
    }


}