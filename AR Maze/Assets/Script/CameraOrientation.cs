using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    // Start is called before the first frame update
    public int Face;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button click
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;

            // Convert the mouse position to a ray in the game world
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            // Perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // A collider was hit, do something with the hit information
                if(hit.collider.tag== "DefaultFace")
                {
                    //print("Default Face");
                    Face = 1;
                }
                else if (hit.collider.tag== "LeftFace")
                {
                    //print("LeftFace");
                    Face = 2;
                }
                else if (hit.collider.tag == "RightFace")
                {
                    //print("RightFace");
                    Face = 3;
                }
                else if (hit.collider.tag == "BackFace")
                {
                    //print("BackFace");
                    Face = 4;
                }
            }
        }
    }


}
