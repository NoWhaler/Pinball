using Model;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using View;
using Zenject;

namespace Pinball.Presenter
{
    public class FinishBumperPresenter : IFinishBumperPresenter
    {
        [Inject]
        private IFinishBumperView _finishBumperView;
        private FinishBumperModel _finishBumperModel;
        
        public int ScorePoints { get => _finishBumperModel.ScorePoints;
            set => _finishBumperModel.ScorePoints = Mathf.Clamp(value, 0, 150);
        }
        
        [Inject]
        public FinishBumperPresenter(IFinishBumperView finishBumperView)
        {
            _finishBumperView = finishBumperView;
            _finishBumperModel = new FinishBumperModel();
            ScorePoints = _finishBumperModel.ScorePoints;
        }

        public void ChangeBumperPoints()
        {
            _finishBumperView.SetPoints(ScorePoints);
        }
    }
}