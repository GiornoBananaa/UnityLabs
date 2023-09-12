using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCombat
    {
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab,firePoint);
        }
    }
}
