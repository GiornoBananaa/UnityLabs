using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Transform FirePoint{ get; private set; }
        [field: SerializeField] public int PoolSize{ get; private set; }
    }
}
