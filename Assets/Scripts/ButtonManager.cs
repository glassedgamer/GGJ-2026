using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainScreen;
    public GameObject credits;
    public GameObject levels;
    public GameObject loading;
     
    private void Start()
    {
        MainScreen();
        levels.SetActive(false);
        loading.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }


    public void Level01()
    {
        Loading();
        //I need you to put "spacebar" and A to continue to the next scene for this. Not familar with the system dont wanna fuck it up
        //SceneManager.LoadScene("Level01");
    }
    public void Level02()
    {
        Loading();
        //I need you to put "spacebar" and A to continue to the next scene for this. Not familar with the system dont wanna fuck it up
        SceneManager.LoadScene("Level02");
    }
    public void Level03()
    {
        Loading();
        //I need you to put "spacebar" and A to continue to the next scene for this. Not familar with the system dont wanna fuck it up
        SceneManager.LoadScene("Level03");
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
        mainScreen.SetActive(true);
        credits.SetActive(false);
        levels.SetActive(false);
    }

    //Mason's Changes -----------

    public void Enlist()
    {
        mainScreen.SetActive(false);
        levels.SetActive(true);
    }

    public void Loading()
    {
        loading.SetActive(true);
        mainScreen.SetActive(false);
        credits.SetActive(false);
        levels.SetActive(false);
    }
}
