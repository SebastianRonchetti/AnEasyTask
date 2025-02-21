using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Simple pickable object", menuName = "AnEasyTaskv0.1/SimpleObject", order = 0)]
public class simplePickableItemSO : simpleWorldItemSO
{
    public itemReceptorSO receptorSO;
    [SerializeField]GameObject prefab;

    public void placeInReceptor(){
    }
}
