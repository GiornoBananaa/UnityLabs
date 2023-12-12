using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        
        private float _currentLifeTime;
        
        private void Awake()
        {
            _currentLifeTime = lifeTime;
        }

        private void Update()
        {
            Move();
            CheckLifeTime();
        }

        private void Move()
        {
            transform.position += transform.right * (speed * Time.deltaTime);
        }
        
        private void CheckLifeTime()
        {
            _currentLifeTime -= Time.deltaTime;
            if(_currentLifeTime<0) 
                Destroy(gameObject);
        }
    }
}
