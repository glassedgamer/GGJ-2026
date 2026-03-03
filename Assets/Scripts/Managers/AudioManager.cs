using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private EventInstance musicEventInstance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one audio manager in the scene dummy");
            Destroy(this);
        }

        instance = this;
    }

    private void Start()
    {
        //InitializeMusic(FMODEvents.instance.music);
    }

    public void PlayerOneShot(EventReference sound, Vector3 worldSpace)
    {
        RuntimeManager.PlayOneShot(sound, worldSpace);
    }

    public EventInstance CreateInstance(EventReference eventRef)
    {
        EventInstance eventInst = RuntimeManager.CreateInstance(eventRef);
        return eventInst;
    }

    public void InitializeMusic(EventReference musicEventRef)
    {
        musicEventInstance = CreateInstance(musicEventRef);
        musicEventInstance.start();
    }

    public void StopMusic(EventReference musicEventRef)
    {
        musicEventInstance = CreateInstance(musicEventRef);
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
