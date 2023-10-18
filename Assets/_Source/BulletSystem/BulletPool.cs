using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

namespace BulletSystem
{
    public class BulletPool
    {
        private Queue<GameObject> _bullets;
        private List<GameObject> _releasedBullets;
        private Player _player;
        private int _count;
        

        public BulletPool(Player player)
        {
            _player = player;
            _releasedBullets = new List<GameObject>();
            _bullets = new Queue<GameObject>();
        }
        
        public bool TryGetFromPool(out GameObject bulletInstance)
        {
            if (_bullets.Count == 0)
            {
                if (_count < _player.PoolSize)
                {
                    CreateBullet();
                }
                else if (_count >= _player.PoolSize)
                {
                    bulletInstance = null;
                    return false;
                }
            }

            bulletInstance = null;
            while (bulletInstance == null)
            {
                bulletInstance = _bullets.Dequeue();
            }
            _releasedBullets.Add(bulletInstance);
            bulletInstance.SetActive(true);
            return true;
        }

        public void ReturnToPool(GameObject bulletInstance)
        {
            _releasedBullets.Remove(bulletInstance);
            _bullets.Enqueue(bulletInstance);
            bulletInstance.SetActive(false);
        }

        private void CreateBullet()
        {
            GameObject bulletInstance = Object.Instantiate(_player.BulletPrefab);
            if (bulletInstance.TryGetComponent(out Bullet bullet))
            {
                bullet.OnLifeEnd += () => ReturnToPool(bullet.gameObject);
                bullet.OnBulletDestroy += () => _count--;
            }
            ReturnToPool(bulletInstance);
            _count++;
        }
    }
}
