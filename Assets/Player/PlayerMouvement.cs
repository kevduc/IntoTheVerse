using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//coucou
public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed = 8f;

    public float gravity = -39.24f;

    public float jumpHeight = 3f;

    public float turnSmoothTime = 0.2f;

    float turnSmoothVelocity;

    Vector3 velocity;

    bool isGrounded;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        isGrounded =
            Physics
                .CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle =
                Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                cam.eulerAngles.y;
            float angle =
                Mathf
                    .SmoothDampAngle(transform.eulerAngles.y,
                    targetAngle,
                    ref turnSmoothVelocity,
                    turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir =
                Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Loop y position (when player falls)
        // if (controller.transform.position.y < -20f)
        // {
        //     controller.transform.position =
        //         new Vector3(controller.transform.position.x,
        //             20f,
        //             controller.transform.position.z);
        //     // Physics.SyncTransforms(); // could be needed https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/
        // }
    }
}
