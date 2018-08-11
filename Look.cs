using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {
    #region Variables
    public Transform Player;
    float Sensitivity = 3f;
    float xAxisClamp = 0;
    #endregion
    //Locks the cursor at the beggining of the game
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Controls Methods and updates once per physics interaction
    private void FixedUpdate() {
        RotateCamera();
        
    }
    //Manages Camera's Rotation
    void RotateCamera() {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        float RotAmntX = MouseX * Sensitivity;
        float RotAmntY = MouseY * Sensitivity;
        Vector3 TargetRot = transform.rotation.eulerAngles;
        Vector3 TargetRotPl = Player.rotation.eulerAngles;
        TargetRot.x -= RotAmntY;
        TargetRotPl.y += RotAmntX;
        TargetRot.z = 0;
        xAxisClamp -= RotAmntY;
        
        if (xAxisClamp > 90) {
            xAxisClamp = 90;
            TargetRot.x = 90;
        }
        else if (xAxisClamp < -90) {
            xAxisClamp = -90;
            TargetRot.x = 270;
        }

        transform.rotation = Quaternion.Euler(TargetRot);
        Player.rotation = Quaternion.Euler(TargetRotPl);
    }
}
