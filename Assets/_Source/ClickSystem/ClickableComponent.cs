using ScoreSystem;
using UnityEngine;

namespace ClickSystem
{
    [RequireComponent (typeof (Collider))]
    public class ClickableComponent : MonoBehaviour
    {
        private Score _score;
        private bool _addScore;
        public void Construct(Score score, bool addScore)
        {
            _score = score;
            _addScore = addScore;
        }

        private void OnMouseDown()
        {
            if (_addScore)
            {
                _score.AddScore(); 
            }
            else
            {
                _score.ReduceScore();
            }
        }
    }
}
