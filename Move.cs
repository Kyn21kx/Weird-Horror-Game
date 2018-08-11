using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    #region Variables
    CharacterController characterController;
    float walkSpeed = 5f;
    float runSpeed;
    float jumpSpeed;
    #endregion

    private void Start() {
        characterController = this.gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        Movement();
    }

    void Movement() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movDirX = transform.right * h * walkSpeed;
        Vector3 movDirF = transform.forward * v * walkSpeed;

        characterController.SimpleMove(movDirX);
        characterController.SimpleMove(movDirF);
    }

}
