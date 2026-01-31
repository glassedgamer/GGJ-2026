using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Multiple Killable Objects")]
    public int enemyKillGoal = 1;

    [HideInInspector] public int enemyKillCounter = 0;

    private void Update()
    {
        KillAllTheThings();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Kill X amount of things
    void KillAllTheThings()
    {
        if (enemyKillCounter >= enemyKillGoal)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
