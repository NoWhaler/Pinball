using Pinball.Presenter;
using TMPro;
using UnityEngine;
using Zenject;

namespace View
{
    public class BallView : MonoBehaviour, IBallView
    {
        private TMP_Text _ballScoreText;
        private Canvas _canvas;
        
        [Inject]
        private IBallPresenter _ballPresenter;

        private void Awake()
        {
            _canvas = GetComponentInChildren<Canvas>();
            _ballScoreText = _canvas.GetComponentInChildren<TMP_Text>();
        }

        public void SetScore(int score)
        {
            _ballScoreText.text = score.ToString();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var bumperView = col.collider.GetComponent<BumperView>();
            if (bumperView != null)
            {
                _ballPresenter.ChangeBallScore();
            }

            var finishBumperView = col.collider.GetComponent<FinishBumperView>();
            if (finishBumperView != null)
            {
                _ballPresenter.ChangeFinishBumperScore();
            }
        }
    }
}