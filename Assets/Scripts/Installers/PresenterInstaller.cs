using Pinball.Presenter;
using Presenter;
using Zenject;

public class PresenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBallPresenter>().To<BallPresenter>().AsSingle().Lazy();
        Container.Bind<IFinishBumperPresenter>().To<FinishBumperPresenter>().AsSingle().Lazy();
        Container.Bind<IBumperPresenter>().To<BumperPresenter>().AsTransient().Lazy();
        Container.Bind<IVictoryPopUpPresenter>().To<VictoryPopUpPresenter>().AsTransient().Lazy();
        Container.Bind<ICloneBallBumper>().To<CloneBallBumper>().AsTransient().Lazy();
    }
}