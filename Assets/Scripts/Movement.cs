using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

   // [SerializeField] Transform orientation;
    [SerializeField] Transform shootPoint;

    [SerializeField] GameObject bullet;

    [SerializeField] KeyCode shoot;

    public float planeSpeed;

    public float sensX = 2f;
    public float sensY = 1f;
    public float yClamp;
    public float tilt = 30f;

    float xRot;
    float yRot;
    
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);
        CameraMovement();


        Shooting();
    }

    void CameraMovement()
    {
        float inputX = Input.GetAxis("Mouse X") * sensX;
        float inputY = Input.GetAxis("Mouse Y") * sensY;

        yRot += inputX;

        xRot -= inputY;
        xRot = Mathf.Clamp(xRot, -yClamp, yClamp);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        //orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }

    void Shooting()
    {
        if(Input.GetKeyDown(shoot))
        {
            Instantiate(bullet, shootPoint.position, this.transform.rotation);
        }
    }
}
