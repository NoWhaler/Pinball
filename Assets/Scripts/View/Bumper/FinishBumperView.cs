using System;
using Pinball.Presenter;
using TMPro;
using UnityEngine;
using Zenject;

namespace View
{
    public class FinishBumperView : MonoBehaviour, IFinishBumperView
    {

        private TMP_Text _scorePoints;
        private Canvas _canvas;
        
        [Inject]
        private IFinishBumperPresenter _finishBumperPresenter;

        private void Awake()
        {
            _canvas = GetComponentInChildren<Canvas>();
            _scorePoints = _canvas.GetComponentInChildren<TMP_Text>();
        }
        
        private void Start()
        {
            _finishBumperPresenter.ChangeBumperPoints();
        }

        public void SetPoints(int points)
        {
            _scorePoints.text = points.ToString();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var ball = col.collider.GetComponent<IBallView>();
            if (ball != null)
            {
                _finishBumperPresenter.ChangeBumperPoints();
            }
        }
    }
}