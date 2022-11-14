using Presenter;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace View
{
    public class VictoryPopUpView : MonoBehaviour, IVictoryPopUpView
    {
        [SerializeField] private Canvas _canvas;
        
        [Inject]
        private IVictoryPopUpPresenter _victoryPopUpPresenter;

        public void PopUp()
        {
            
            _canvas.gameObject.SetActive(true);
            
        }

        public void NextLevelButton(int sceneID)
        {
            PopUp();
            SceneManager.LoadScene(sceneID);
        }

        public void PreviousLevelButton(int sceneID)
        {
            PopUp();
            SceneManager.LoadScene(sceneID);
        }
    }
}