using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemReceptorSO : simpleWorldItemSO
{
    [SerializeField] LayerMask objectsToPickUp;
    [SerializeField] bool complete;
    [SerializeField] Transform dropPoint;
    [SerializeField] simplePickableItemSO[] itemsInPlace;
    [SerializeField] List<simplePickableItemSO> acceptedItems;

    private void Awake() {
        itemsInPlace = new simplePickableItemSO[acceptedItems.Count];
    }

    public void assignItem(simplePickableItemSO _item){
        foreach(simplePickableItemSO i in acceptedItems) {
            if(_item == i) {
                for(int p = 0; p <= itemsInPlace.Length; p++){
                    if(itemsInPlace[p] == null) {
                        _item.placeInReceptor();
                    }
                }
            }
        }
    }

    private void Update() {
        Collider2D _col = Physics2D.OverlapCircle(dropPoint.position, 2.5f, objectsToPickUp);
    }
}
