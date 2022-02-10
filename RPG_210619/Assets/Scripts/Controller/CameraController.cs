using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    private float currentZoom = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        currentZoom -= mouseWheel * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
