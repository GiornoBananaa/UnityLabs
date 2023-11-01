using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private Transform _transform;
        private float _speed;

        public PlayerMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _transform.position += direction.normalized * (_speed * Time.deltaTime);
        }
    }
}