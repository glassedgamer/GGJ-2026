using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death" || collision.gameObject.tag == "Death Enemy")
        {
            gameManager.BackToMain();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
