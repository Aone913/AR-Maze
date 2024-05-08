using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

public class Raycast_Script : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public GameObject Background1;
    public GameObject Background2;
    public Button TryAgainButton, BackButton, MazeButton;
    GameObject SpawnedObject;
    bool ObjectSpawned;
    ARRaycastManager Arrayman;
    List<ARRaycastHit> Hits = new List<ARRaycastHit>();
    private ARPlaneManager ARPlaneManager;
    private void Awake()
    {
        if (TryAgainButton != null)
        {
            TryAgainButton.onClick.AddListener(() => StartAR());
        }
        if (BackButton != null)
        {
            BackButton.onClick.AddListener(() => StartAR());
        }
        if (MazeButton != null)
        {
            MazeButton.onClick.AddListener(() => StartAR());
        }
    }
    void Start()
    {
        ObjectSpawned = false;
        Arrayman = GetComponent<ARRaycastManager>();
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.enabled = !ARPlaneManager.enabled;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlacePrefab();
        
    }
    public void StartAR()
    {
        ARPlaneManager.enabled = true;
        Destroy(SpawnedObject);
        Background2.gameObject.SetActive(false);
        Background1.gameObject.SetActive(true);
        ObjectSpawned = false;
        PlacePrefab();

    }

    public void PlacePrefab()
    {
        if (Input.touchCount > 0)
        {
            if (Arrayman.Raycast(Input.GetTouch(0).position, Hits, TrackableType.PlaneWithinPolygon))
            {
                var HitPose = Hits[0].pose;
                if (!ObjectSpawned)
                {
                    Background2.gameObject.SetActive(true);
                    Background1.gameObject.SetActive(false);
                    SpawnedObject = Instantiate(SpawnPrefab, HitPose.position, HitPose.rotation);
                    ObjectSpawned = true;
                    ARPlaneManager.enabled = !ARPlaneManager.enabled;
                    foreach (ARPlane plane in ARPlaneManager.trackables)
                    {
                        plane.gameObject.SetActive(ARPlaneManager.enabled);
                    }
                }

            }

        }
    }
}
