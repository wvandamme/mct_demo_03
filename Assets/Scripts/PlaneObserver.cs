using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneObserver : MonoBehaviour
{

    public Camera m_camera;
    public ARRaycastManager raycast_manager;
    public GameObject cursor;

    private Vector2 screenpoint = new Vector2(Screen.width / 2, Screen.height / 2);
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject marker;

    private void OnEnable()
    {
        marker = Instantiate(cursor, gameObject.transform);
    }
     
    private void Update()
    {
        if (raycast_manager.Raycast(screenpoint, hits))
        {
            marker.transform.position = hits[0].pose.position;
            marker.transform.rotation = hits[0].pose.rotation;
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }
    }

    public Transform GetCursor()
    {
        if (marker)
        {
            if (marker.activeSelf)
            {
                return marker.transform;
            }
        }
        return null;
    }

}
