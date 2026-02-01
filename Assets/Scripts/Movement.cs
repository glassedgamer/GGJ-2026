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
        CameraMovement();
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);

        Shooting();
    }

    void CameraMovement()
    {
        float inputX = Input.GetAxis("Mouse X") * sensX;
        float inputY = Input.GetAxis("Mouse Y") * sensY;

        yRot += inputX;

        xRot -= inputY;
        xRot = Mathf.Clamp(xRot, -yClamp, yClamp);

        //orientation.rotation = Quaternion.Euler(0, yRot, 0);

        float targetRoll = 0f;

        if (inputX > 0f)
            targetRoll = -tilt;
        else if (inputX < 0)
            targetRoll = tilt;

        Quaternion targetRotation = Quaternion.Euler(xRot, yRot, targetRoll);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void Shooting()
    {
        if(Input.GetKeyDown(shoot))
        {
            Instantiate(bullet, shootPoint.position, this.transform.rotation);
        }
    }
}
