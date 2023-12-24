using SkySystem;
using StarsSystem;
using SunSystem;
using TimerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        private IObserver _sky;
        private IObserver _stars;
        private IObserver _sun;
        
        private void Awake()
        {
            _sky = new Sky();
            _stars = new Stars();
            _sun = new Sun();
            _timer.RegisterObserver(_sky);
            _timer.RegisterObserver(_stars);
            _timer.RegisterObserver(_sun);
        }
        
        private void OnDestroy()
        {
            _timer.RemoveObserver(_sky);
            _timer.RemoveObserver(_stars);
            _timer.RemoveObserver(_sun);
        }
    }
}
