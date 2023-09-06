using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        public void Move(Rigidbody rb, float speed, Vector3 moveDirection)
        {
            Vector3 velocity = moveDirection * speed;
            rb.velocity = new Vector3(velocity.x,rb.velocity.y,velocity.z);
        }

        public void Jump(Rigidbody rb, float force)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        public void Rotate(Rigidbody rb, float rotationSpeed,Vector3 lookPoint)
        {
            Vector3 position = rb.transform.position;
            Vector3 lookDirection = new Vector3(lookPoint.x,position.y,lookPoint.z) - position;
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, rotation, rotationSpeed);
        }
    }
}
