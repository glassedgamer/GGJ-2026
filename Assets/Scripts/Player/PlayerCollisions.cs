using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Animator anim;
    GameManager gameManager;

    [SerializeField] private string boolParameterName = "DoorsClose";

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        anim = gameObject.GetComponent<Animator>();
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
        //if(gameObject.tag == "TriggerDoor")
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetBool(DoorsClose, true);
        }
    }
}
