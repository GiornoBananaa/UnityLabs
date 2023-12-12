using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _transform;

        public void Move(float x,float y)
        {
            _transform.position += new Vector3(x,y,0) * (_speed * Time.deltaTime);
        }
    }
}
