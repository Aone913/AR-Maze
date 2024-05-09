using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public bool hit = false;
    public GameObject WinPage, MazePage; 
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void OnEnable()
    {
        WinPage = GameObject.Find("mng").GetComponent<GameManger>().WinPage;
        MazePage = GameObject.Find("mng").GetComponent<GameManger>().MazePage;
    }

    private void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.tag == "Ball")
        {

            hit = true;
            print("HIT");
            WinPage.gameObject.SetActive(true);
            MazePage.gameObject.SetActive(false);
        }
    }
}
    