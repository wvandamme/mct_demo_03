
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class TouchContoller : MonoBehaviour
{

    public ARRaycastManager raycast_manager;
    public Camera m_camera;
    public GameObject world;
    public PlaneObserver plane_observer;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private TouchPhase last_phase = TouchPhase.Began;

    void FixedUpdate()
    {

        if (Input.touchCount != 1) return;
        
        Touch touch = Input.GetTouch(0);

        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }

        if ((touch.phase == TouchPhase.Ended) && (last_phase != TouchPhase.Ended))
        {
            var cursor = plane_observer.GetCursor();
            if (cursor)
            {
                Instantiate(world, cursor.position, Quaternion.identity);
            }
        }

        last_phase = touch.phase;

    }
}
