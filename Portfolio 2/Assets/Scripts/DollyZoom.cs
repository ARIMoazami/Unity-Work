using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoom : MonoBehaviour
{
    public Transform traget;
    public Camera zoomCamera;

    private float initHeightAtDistance;
    private bool dollyZoomEnabled;

   float FrustrumHeightAtDistance(float distnace)
    {
        return 2.0f * distnace * Mathf.Tan(zoomCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    float FOVForHeightAndDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(initHeightAtDistance * 0.5f / distance) * Mathf.Rad2Deg;
    }

    void StartDollyZoomEffect()
    {
        var distance = Vector3.Distance(transform.position, traget.position);
        initHeightAtDistance = FrustrumHeightAtDistance(distance);
        transform.LookAt(traget.transform);
        dollyZoomEnabled = true;
    }

    void StopDollyZoomEffect()
    {
        dollyZoomEnabled = false;
    }

    void Start()
    {
        StartDollyZoomEffect();
    }

    void Update()
    {
        if (dollyZoomEnabled)
        {
            var currDistance = Vector3.Distance(transform.position, traget.position);
            zoomCamera.fieldOfView = FOVForHeightAndDistance(initHeightAtDistance, currDistance);
        }

        if ((Input.GetKey("[") || (Input.GetKey("]"))))
        {
            transform.Translate(Input.GetAxis("AltVertical") * Vector3.forward * Time.deltaTime);
        }
    }
}
