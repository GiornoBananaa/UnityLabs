using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCombat : MonoBehaviour
    {
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            Instantiate(bulletPrefab,firePoint);
        }
    }
}
