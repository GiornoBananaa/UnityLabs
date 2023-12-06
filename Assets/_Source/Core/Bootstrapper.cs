using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private IObservable _timer;
        private IObserver _sky;
        private void Awake()
        {
            _sky = new Sky();
            _timer = new Timer();
        }

        private void OnEnable()
        {
            _timer.RegisterObserver(_sky);
        }
        
        private void OnDisable()
        {
            _timer.RemoveObserver(_sky);
        }
    }
}
