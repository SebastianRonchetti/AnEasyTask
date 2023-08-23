using UnityEngine;

public class depositSO : baseItemSO {
    public pickableItemSO[] itemsToDeposit;
    public Collider2D col;
    private completionCounterSO counter;

    private void OnCollisionEnter2D(Collision2D other) {
        foreach(pickableItemSO item in itemsToDeposit)
        {
            string otherName = other.gameObject.GetComponent<pickableItemSO>().name;
            if(otherName == item.name){
                Destroy(other.gameObject);
                counter.counterUp();
            }
        }
    }
}