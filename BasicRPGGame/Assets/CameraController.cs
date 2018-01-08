using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public Vector3 offsetFromTarget;
    public float pitch = 1f;
    public float zoomSpeed = 4f;

    public float rotateSpeed = 100f;


    private float currentZoom = 10f;
    private float currentRotation = 0f;

	// Use this for initialization
	private void Start () {
        transform.position = target.transform.position;
    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentRotation -= Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
    }

    private void LateUpdate () {

        transform.position = target.transform.position - offsetFromTarget * currentZoom;


        transform.LookAt(target.transform.position + Vector3.up * pitch);

        transform.RotateAround(target.transform.position, Vector3.up, currentRotation);
	}
}
