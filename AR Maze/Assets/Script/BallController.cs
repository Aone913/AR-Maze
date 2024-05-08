using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick FixedJoystick;
    private Rigidbody RigidBody;

    private void OnEnable()
    {
        FixedJoystick = FindAnyObjectByType<FixedJoystick>();
        RigidBody = gameObject.GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        float xVal = FixedJoystick.Horizontal;
        float yVal = FixedJoystick.Vertical;

        Vector3 Movement = new Vector3(xVal, 0, yVal);
        RigidBody.velocity = Movement * speed;

        if (xVal != 0 && yVal != 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
    }
}

