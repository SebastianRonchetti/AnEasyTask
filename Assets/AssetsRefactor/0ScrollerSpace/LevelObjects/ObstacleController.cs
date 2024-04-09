using UnityEngine;

public class ObstacleController : MonoBehaviour {
    [SerializeField] int integrity;
    
    public void damage(){
        integrity --;
        if(integrity <= 0){
            Destroy(this.gameObject);
        }
    }
}