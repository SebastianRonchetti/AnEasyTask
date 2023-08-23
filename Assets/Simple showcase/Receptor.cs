using System;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    [SerializeField] LayerMask objectsToPickUp;
    [SerializeField] public bool complete;
    [SerializeField] Transform dropPoint;
    [SerializeField] GameObject[] itemsInPlace;
    [SerializeField] List<GameObject> acceptedItems;
    public event EventHandler<EventArgs> onComplete;
    GameManagerSimple _manager;

    private void Awake() {
        itemsInPlace = new GameObject[acceptedItems.Count];
        _manager = GameManagerSimple.Instance;
        _manager.addToList(this);
    }

    void assignItem(GameObject _item){
        foreach(GameObject i in acceptedItems) {
            if(_item == i) {
                for(int p = 0; p <= itemsInPlace.Length; p++){
                    if(itemsInPlace[p] == null) {
                        itemsInPlace[p] = _item;
                        itemsInPlace[p].gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }

        if(itemsInPlace[acceptedItems.Count - 1] != null) {
            complete = true;
        }
    }

    public void guardarObjeto(GameObject objeto){
        assignItem(objeto);
            if(complete) {
                onComplete?.Invoke(this, new EventArgs());
            }
    }

    private void Update() {
        Collider2D _col = Physics2D.OverlapCircle(dropPoint.position, 2.5f, objectsToPickUp);
        if(_col != null){
            guardarObjeto(_col.gameObject);
        }
    }
}
