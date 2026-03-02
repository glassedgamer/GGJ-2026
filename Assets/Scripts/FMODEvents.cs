using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    public  static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("More than one FMOD Events scripts in the scene");
        }
        instance = this;
    }
}
