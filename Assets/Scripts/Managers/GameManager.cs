using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text levelGoal;

    [Header("Multiple Killable Objects")]
    public int enemyKillGoal = 1;

    [HideInInspector] public int enemyKillCounter = 0;

    private void Start()
    {
        AudioManager.instance.StopMusic(FMODEvents.instance.music);
        levelGoal.text = $"There are {enemyKillGoal - enemyKillCounter} enemies left";

        AudioManager.instance.InitializeMusic(FMODEvents.instance.music);
    }

    private void Update()
    {
        levelGoal.text = $"There are {enemyKillGoal - enemyKillCounter} enemies left";
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
