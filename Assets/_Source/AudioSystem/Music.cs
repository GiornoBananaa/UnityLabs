using UnityEngine;

namespace AudioSystem
{
    public class Music : MonoBehaviour
    {
        public static Music Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(gameObject);
        }
    }
}
