using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //[SerializeField] float rotatingVelocity = 50f;
    //[SerializeField] float forceMultiplayer = 2f;
    [SerializeField] float movingSpeed = 2f;
    public bool IsOn = true;

    Rigidbody receiver;

    void Start()
    {
        receiver = GameObject.FindGameObjectWithTag("InputReceiver").GetComponent<Rigidbody>();
        if (receiver == null)
        {
            Debug.LogError("Input RigidBody is not set. Create a GameObject with RigidBody and tag it \"InputReceiver\"");
        }
    }

    void FixedUpdate()
    {
        if (!IsOn) return;

        if (Input.GetMouseButton(0))
        {
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = targetPos - receiver.position;
            direction.z = 0;
            if (direction.sqrMagnitude > 0.5f)
            {
                receiver.AddForce(direction.normalized * Time.deltaTime * movingSpeed, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("up"))
        {
            receiver.AddForce(Vector3.up * Time.deltaTime * movingSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey("down"))
        {
            receiver.AddForce(Vector3.down * Time.deltaTime * movingSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey("right"))
        {
            receiver.AddForce(Vector3.right * Time.deltaTime * movingSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey("left"))
        {
            receiver.AddForce(Vector3.left * Time.deltaTime * movingSpeed, ForceMode.VelocityChange);
        }
    }
}
