using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private readonly float _speed;
        private readonly Transform _transform;
        
        public PlayerMovement(float speed, Transform transform)
        {
            _speed = speed;
            _transform = transform;
        }
        
        public void Move(float x,float y)
        {
            _transform.position += new Vector3(x,y,0) * (_speed * Time.deltaTime);
        }
    }
}
