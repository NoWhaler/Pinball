using Model;
using Presenter;
using UnityEngine;
using View;
using Zenject;

namespace Pinball.Presenter
{
    public class BallPresenter : IBallPresenter
    {
        private BallModel _ballModel;
        
        [Inject]
        private IBallView _ballView;
        
        [Inject]
        private IBumperPresenter _bumperPresenter;
        
        [Inject]
        private IFinishBumperPresenter _finishBumperPresenter;

        [Inject] 
        private IVictoryPopUpPresenter _victoryPopUpPresenter;

        [Inject]
        public BallPresenter(IBallView ballView)
        {
            _ballView = ballView;
            _ballModel = new BallModel();
        }
        

        public void ChangeBallScore()
        {
            _ballModel.Score += _bumperPresenter.ScorePoints;
            Debug.Log(_ballModel.Score);
            _ballView.SetScore(_ballModel.Score);
        }

        public void ChangeFinishBumperScore()
        {
            CountScorePoints();
            if (_finishBumperPresenter.ScorePoints <= 0)
            {
                _victoryPopUpPresenter.ShowVictoryMenu();
            }

            _finishBumperPresenter.ChangeBumperPoints();
            _ballView.SetScore(_ballModel.Score);
        }

        private void CountScorePoints()
        {
            var value = _finishBumperPresenter.ScorePoints + (_ballModel.Score - _finishBumperPresenter.ScorePoints);
            var value2 = _ballModel.Score + (_finishBumperPresenter.ScorePoints - _ballModel.Score);
            
            if (_finishBumperPresenter.ScorePoints < _ballModel.Score)
            {
                _ballModel.Score -= _finishBumperPresenter.ScorePoints;
                _finishBumperPresenter.ScorePoints -= value2;
            }
            else
            {
                _ballModel.Score -= _ballModel.Score;
                _finishBumperPresenter.ScorePoints -= value;
            }
        }
    }
}