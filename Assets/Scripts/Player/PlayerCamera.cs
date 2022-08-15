using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerCamera : MonoBehaviour
{
    private PlayerInput inputs;

    [SerializeField] private GameObject target;

    private float horizontalSpeed = 20.0f;
    private float verticalSpeed = 20.0f;
    public float axisY, axisX = 0.0f;

    public float axisXMax = 360.0f;
    public float axisXMin = -360.0f;

    public float axisYMax = 360.0f;
    public float axisYMin = -360.0f;


    public float height = 1.0f;
    public float distance = 7.0f;
    private Vector3 camPosition = Vector3.zero; // eigenes Cordianten System

    public Vector3 offset = new Vector3(0.0f, 2.0f, 0.0f);

    public float scrollScalle = 0.5f;
    public float distanceMax = 0.0f;
    public float distanceMin = 0.0f;
    public float changeDistanceStart;
    private float distanceStart;

    private Vector3 camPlayerVectorBetween;

    private bool isCameraMoving = false;
    [SerializeField] private float cameraDamping = 1;
    [SerializeField] private float cameraSwitchMinDistance = 0.1f;

    private void Start()
    {
        distanceStart = distance;
        distance = changeDistanceStart;
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isCameraMoving) this.updateCamera();
    }
    public void updateCamera() {

        //Debug.Log(inputs.Player.Camera.ReadValue<Vector2>());
        Vector2 mouseInput = inputs.Player.Camera.ReadValue<Vector2>();

        if (changeDistanceStart != distanceStart) distanceStart = changeDistanceStart;

        // ############## Scroll distance ##############
        //distance += -(Input.mouseScrollDelta.y * scrollScalle);

        /*float distMaxTmp = distanceStart + distanceMax;
        if (distance > distMaxTmp) distance = distMaxTmp;

        float distMinTmp = distanceStart - distanceMin;
        if (distance < distMinTmp) distance = distMinTmp;*/


        //############## berechnungen der Kamera ##############
        camPosition.y = height;
        camPosition.z = distance;

        //rotation
        // altes Input System
        /*if (Input.GetMouseButton(0))
        {
            axisY = (mouseInput.x * verticalSpeed + axisY) % 360.0f;
            axisX = (mouseInput.y * horizontalSpeed + axisX) % 360.0f;
        }*/

        axisY = (mouseInput.x * verticalSpeed * Time.deltaTime + axisY) % 360.0f;
        axisX = (mouseInput.y * horizontalSpeed * Time.deltaTime + axisX) % 360.0f;

        if (axisX > axisXMax) axisX = axisXMax;
        if (axisX < axisXMin) axisX = axisXMin;

        if (axisY > axisYMax) axisY = axisYMax;
        if (axisY < axisYMin) axisY = axisYMin;

        Quaternion rotation = Quaternion.Euler(axisX, axisY, 0.0f);

        Vector3 rotationPosition = rotation * camPosition;


        //update camera
        Vector3 focus = target.transform.position + offset;

        transform.position = focus + rotationPosition;
        transform.LookAt(focus);
    }
    private Vector3 CamPlayerVectorBetween() {
        if (target == null)
            return Vector3.zero;

        return transform.position - target.transform.position;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void changeCameraTarget(GameObject target) {
        inputs.Disable();
        camPlayerVectorBetween = CamPlayerVectorBetween();
        this.target = target;
        if (camPlayerVectorBetween == Vector3.zero) {
            camPosition.y = height;
            camPosition.z = distance;
            Quaternion rotation = Quaternion.Euler(axisX, axisY, 0.0f);

            Vector3 rotationPosition = rotation * camPosition;


            //update camera
            Vector3 focus = target.transform.position + offset;

            transform.LookAt(focus);

            camPlayerVectorBetween = offset + rotationPosition; 
        }
        isCameraMoving = true;
    }

    private void Update()
    {
        if (isCameraMoving)
        {
            //Debug.Log("Moving!");

            transform.position =  Vector3.Lerp(transform.position, target.transform.position + camPlayerVectorBetween, cameraDamping * Time.deltaTime);
            //Debug.Log("Moving!");

            if (Vector3.Distance(transform.position, target.transform.position + camPlayerVectorBetween) < cameraSwitchMinDistance)
            {
                isCameraMoving = false;
                inputs.Enable();
                //Debug.Log("False!");
            }
                
        }
    }
}
