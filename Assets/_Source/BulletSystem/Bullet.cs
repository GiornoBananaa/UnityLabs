using System;
using UnityEngine;

namespace BulletSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false;
        }

        private void Update()
        {
            MoveForward();
        }

        void MoveForward()
        {
            _rb.velocity = transform.up * speed;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
