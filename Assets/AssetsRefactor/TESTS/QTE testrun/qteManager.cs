using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qteManager : MonoBehaviour
{
    int workCount, timerModifier;
    [SerializeField] GameObject _qteObjectPrefab;

    /* ref to each qteSO
    Randomizer to each action and button to press
    Ref to the gameobject which would display the qte params
    position randomizer to spawn the gameobject 
    Ref to all 'work' qte
    when 'work' qte = 0 delete any other active qte prefabs and spawn new ones*/

    void _reduceWorkCount(){
        workCount--;
        if(workCount <= 0){
            int _appliedMod = 11 + timerModifier;
            _deleteQTEs();
            _setQTEs(Random.Range(5, _appliedMod));
        }
    }

    void _deleteQTEs(){

    }

    void _setQTEs(int amount){
        int workAmount = Mathf.RoundToInt(amount%40);

        for(int i = 0; i < workAmount; i++){
            //Spawn qtes for work.
        }

        for(int i = 0; i < amount - workAmount; i++){
            //spawn random non-work qte.
        }
    }
}
