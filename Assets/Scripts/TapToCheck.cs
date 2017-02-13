using System.Collections;
using System.Collections.Generic;
using Academy.HoloToolkit.Unity;
using UnityEngine;

public class TapToCheck : MonoBehaviour {

    public LayerMask raycastLayerMask;

    // For searching within Memories.
    public GameObject search;
    public GameObject toAppear;

    // Use this for initialization
    void Start () {
        Debug.Log("CHECK THIS HUY");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // Do a raycast into the world that will only hit the plane's mesh.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, Mathf.Infinity, raycastLayerMask))
        {
            GameObject memory = search.transform.Find("Bob").gameObject;
            memory.SetActive(true);
            toAppear.SetActive(true);
            Debug.Log("HUY CHECK THIS");
            /*
            GameObject mainCamera = GameObject.Find("Main Camera");

            Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * 2;
            memory.transform.position = spawnPosition;
            memory.transform.rotation = mainCamera.transform.rotation;
            */
        }
    }
}