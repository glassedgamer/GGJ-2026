using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainScreen;
    public GameObject credits;
    public GameObject levels;
    public GameObject loading;

    public bool continueToLevel = false;
    public bool load = false;

    string levelToLoad;
     
    private void Start()
    {
        AudioManager.instance.StopMusic(FMODEvents.instance.music);
        continueToLevel = false;
        load = false;

        MainScreen();
        levels.SetActive(false);
        loading.SetActive(false);

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        AudioManager.instance.InitializeMusic(FMODEvents.instance.music);
    }

    //Stuff to do when UI buttons are pressed

    public void Level01()
    {
        levelToLoad = "Level01";
        Loading();

    }
    public void Level02()
    {
        levelToLoad = "Level02";
        Loading();
    }
    public void Level03()
    {
        levelToLoad = "Level03";
        Loading();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        mainScreen.SetActive(false);
        credits.SetActive(true);
    }
    public void MainScreen()
    {
        load = false; 

        mainScreen.SetActive(true);
        credits.SetActive(false);
        levels.SetActive(false);
    }
    public void Enlist()
    {
        mainScreen.SetActive(false);
        levels.SetActive(true);
    }

    public void Loading()
    {
        load = true;

        loading.SetActive(true);
        mainScreen.SetActive(false);
        credits.SetActive(false);
        levels.SetActive(false);
    }

    //Input Actions
    public void OnContinue(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && load)
            SceneManager.LoadScene(levelToLoad);
    }

    public void test(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        print("what's up");
    }

}
