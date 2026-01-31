using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20f;
    public float maxBulletDistance = 20f;

    GameObject player;
    GameManager gameManager;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);

        if(Vector3.Distance(transform.position, player.transform.position) > maxBulletDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Death Enemy")
        {
            gameManager.enemyKillCounter++;
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
}
