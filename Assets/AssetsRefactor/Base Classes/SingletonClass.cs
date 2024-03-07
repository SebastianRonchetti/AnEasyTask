using UnityEngine;
//Base singleton class that allows for ease of the singleton pattern
public class SingletonClass<T> : MonoBehaviour where T:Component
{
    private static T instance;
    public static T Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<T>();
                if(instance == null){
                    GameObject gameObject = new GameObject("Controller");
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }

        private set{}
    }

    protected void _instantiate() {
        if(instance == null){
            instance = this as T;
        } else {
            if(instance != this){
                Destroy(instance);
            }
        }
    }
}