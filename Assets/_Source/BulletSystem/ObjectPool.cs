using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int poolSize;

        private Queue<GameObject> bullets;

        private void Awake()
        {
            InitPool();
        }

        public void InitPool()
        {
            bullets = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, transform);
                if (bulletInstance.TryGetComponent(out Bullet bullet))
                {
                    bullet.SetOwner(this);
                }
                ReturnToPool(bulletInstance);
            }
        }
    
        public bool TryGetFromPool(out GameObject bulletInstance)
        {
            if (bullets.Count > 0)
            {
                bulletInstance = bullets.Dequeue();;
                bulletInstance.SetActive(true);
                return true;
            }

            bulletInstance = null;
            return false;
        }

        public void ReturnToPool(GameObject bulletInstance)
        {
            bullets.Enqueue(bulletInstance);
            bulletInstance.SetActive(false);
        }
    }
}
