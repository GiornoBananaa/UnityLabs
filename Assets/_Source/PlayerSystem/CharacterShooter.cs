using BulletSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private Transform firePoint;
        
        public void Shoot()
        {
            if (bulletPool.TryGetFromPool(out GameObject bulletInstance))
            {
                bulletInstance.transform.position = firePoint.position;
                bulletInstance.transform.rotation = firePoint.rotation;
            }
        }
    
    }
}
