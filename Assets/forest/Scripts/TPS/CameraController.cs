using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    [Header("Camera")]
    public Transform cam;
    public bool lockCursor;
    [Range(0, 10)] public float lookSensitivity;
    public float maxUpRotation;
    public float maxDownRotation;

    private float xRotation = 0;

    void Start(){
         if(lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            }
        }
    void Update(){
        rotar_Camera();
        }
        private void LateUpdate() {
            
        }


    private void rotar_Camera() {
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        //xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        //xRotation = Mathf.Clamp(xRotation, -maxUpRotation, maxDownRotation);
        //cam.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }
}
