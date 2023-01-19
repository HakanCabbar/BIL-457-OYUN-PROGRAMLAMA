using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    public VariableJoystick joystick;
    public Animator animCtrl;
    public Vector2 min, max;
    public float Speed = 5f; 
    public float RotationSpeed = 10f;
    void Update()
    {
        if (joystick == null)
            return;

        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, min.y, max.y));
        if (movementVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        }

        bool isWalking = direction.magnitude > 0;
        if (animCtrl == null)
            return;
        animCtrl.SetBool("IsWalking", isWalking);

        animCtrl.SetFloat("SpeedValue", direction.magnitude);
         
    }

}
