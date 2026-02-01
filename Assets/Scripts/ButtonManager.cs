using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainScreen;
    public GameObject credits;

    private void Start()
    {
        MainScreen();

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }


    public void Level01()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Level02()
    {
        SceneManager.LoadScene("Level02");
    }
    public void Level03()
    {
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
    }
}
