namespace Pinball.Presenter
{
    public interface IFinishBumperPresenter
    {
        int ScorePoints { get; set; }
        void ChangeBumperPoints();
    }
}