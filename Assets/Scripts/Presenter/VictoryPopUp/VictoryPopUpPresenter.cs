using View;
using Zenject;

namespace Presenter
{
    public class VictoryPopUpPresenter : IVictoryPopUpPresenter
    {
        [Inject]
        private IVictoryPopUpView _victoryPopUpView;

        [Inject]
        public VictoryPopUpPresenter(IVictoryPopUpView victoryPopUpView)
        {
            _victoryPopUpView = victoryPopUpView;
        }

        public void LoadNextLevel()
        {
            _victoryPopUpView.NextLevelButton(1);
        }

        public void LoadPreviousLevel()
        {
            _victoryPopUpView.PreviousLevelButton(0);
        }

        public void ShowVictoryMenu()
        {
            _victoryPopUpView.PopUp();
        }
    }
}