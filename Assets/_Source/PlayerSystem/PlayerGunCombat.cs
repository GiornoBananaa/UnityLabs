using UnityEngine;

namespace PlayerSystem
{
    public class PlayerGunCombat: PlayerCombat
    {
        private GameObject _bulletPrefab;
        private Transform _firePoint;

        public PlayerGunCombat(GameObject bulletPrefab,Transform firePoint)
        {
            _bulletPrefab = bulletPrefab;
            _firePoint = firePoint;
        }
        
        public override void Attack()
        {
            Object.Instantiate(_bulletPrefab,_firePoint.position,_firePoint.rotation);
        }
        public override void DisarmPlayer() { }
    }
}