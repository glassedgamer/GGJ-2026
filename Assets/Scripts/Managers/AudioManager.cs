using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one audio manager in the scene dummy");
        }

        instance = this;
    }

    public void PlayerOneShot(EventReference sound, Vector3 worldSpace)
    {
        RuntimeManager.PlayOneShot(sound, worldSpace);
    }
}
