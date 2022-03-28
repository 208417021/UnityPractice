using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }

        void FixedUpdate()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
                Move(Vector3.forward, false);
            }
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // rb.AddForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
                Move(Vector3.left, false);
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // rb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
                Move(Vector3.right, false);
            }
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                // rb.AddForce(Vector3.back * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
                Move(Vector3.back, false);
            }

            if(transform.position.y < 0)
            {
                GetComponent<RollerMovement>().enabled = false;
                Invoke("DelaySequence", 1);
            }
        }
        public void Move(Vector3 moveDirection, bool jump)
        {
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}