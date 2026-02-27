using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

   // [SerializeField] Transform orientation;
    [SerializeField] Transform shootPoint;

    [SerializeField] GameObject bullet;

    //[SerializeField] KeyCode shoot;

    Vector2 lookInput;

    public float planeSpeed;

    public float mouseSens = 2f;
    public float stickSens = 120f;
    //public float sensY = 1f;
    public float yClamp;

    public float tilt = 30f;

    float xRot;
    float yRot;
    float zRot;

    float rollInput;

    bool usingGamepad;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        CameraMovement();
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);

        //Shooting();
    }

    void CameraMovement()
    {
        float sens = usingGamepad ? stickSens : mouseSens;

        float inputX = lookInput.x * sens * Time.deltaTime;
        float inputY = lookInput.y * -sens * Time.deltaTime;

        // X and Y rotation
        transform.Rotate(Vector3.up, inputX, Space.Self);
        transform.Rotate(Vector3.right, -inputY, Space.Self);

        zRot = tilt * rollInput;
        zRot = Mathf.Clamp(zRot, -tilt, tilt);
        //transform.Rotate(Vector3.forward, zRot, Space.Self);



        /*
        yRot += inputX;

        xRot -= inputY;
        xRot = Mathf.Clamp(xRot, -yClamp, yClamp);


        transform.rotation = Quaternion.Euler(xRot, yRot, zRot);
        */
    }

    /*
    void Shooting()
    {
        if(Input.GetKeyDown(shoot))
        {
            Instantiate(bullet, shootPoint.position, this.transform.rotation);
        }
    }
    */

    // Grabs Vector2 input from context and also checks if you're using a controller or not
    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        usingGamepad = context.control.device is UnityEngine.InputSystem.Gamepad;
    }

    public void OnShoot(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Instantiate(bullet, shootPoint.position, this.transform.rotation);
    }

    public void RollLeft(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed) 
            rollInput = 1f;
        if (context.canceled) 
            rollInput = 0f;
    }

    public void RollRight(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed) 
            rollInput = -1f;
        if (context.canceled) 
            rollInput = 0f;
    }
}
