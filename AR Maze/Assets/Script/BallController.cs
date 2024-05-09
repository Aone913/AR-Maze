using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick FixedJoystick;
    private Rigidbody RigidBody;
    public int face;

    private void OnEnable()
    {
        FixedJoystick = FindAnyObjectByType<FixedJoystick>();
        RigidBody = gameObject.GetComponent<Rigidbody>();
        

    }
    public void FixedUpdate()
    {
        face = GameObject.Find("XR Origin").GetComponent<CameraOrientation>().Face;
        float DefaultJoystickMoveX = FixedJoystick.Horizontal;
        float DefaultJoystickMoveY = FixedJoystick.Vertical;
        if (face == 1)
        {
            float xVal = DefaultJoystickMoveX;
            float yVal = DefaultJoystickMoveY;

            Vector3 Movement = new Vector3(xVal, 0, yVal);
            RigidBody.velocity = Movement * speed;

            if (xVal != 0 && yVal != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        else if (face == 2)
        {
            float xVal = DefaultJoystickMoveY;
            float yVal = -DefaultJoystickMoveX;

            Vector3 Movement = new Vector3(xVal, 0, yVal);
            RigidBody.velocity = Movement * speed;

            if (xVal != 0 && yVal != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
            
        else if (face == 3)
        {
            float xVal = -DefaultJoystickMoveY;
            float yVal = DefaultJoystickMoveX;

            Vector3 Movement = new Vector3(xVal, 0, yVal);
            RigidBody.velocity = Movement * speed;

            if (xVal != 0 && yVal != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        else if (face == 4)
        {
            float xVal = -DefaultJoystickMoveX;
            float yVal = -DefaultJoystickMoveY;

            Vector3 Movement = new Vector3(xVal, 0, yVal);
            RigidBody.velocity = Movement * speed;

            if (xVal != 0 && yVal != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
           
    }
    
}


