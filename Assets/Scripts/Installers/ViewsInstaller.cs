using UnityEngine;
using View;
using Zenject;

public class ViewsInstaller : MonoInstaller
{
    
    [SerializeField] private FinishBumperView _finishBumperView;
    [SerializeField] private BumperView _bumperView;
    [SerializeField] private BallView _ballView;
    [SerializeField] private VictoryPopUpView _victoryPopUpView;
    [SerializeField] private CloneBallBumperView _cloneBallBumperView;
    
    public override void InstallBindings()
    {
        Container.Bind<IBumperView>().To<BumperView>().FromComponentOn(_bumperView.gameObject).AsTransient().NonLazy();
        Container.Bind<IBallView>().To<BallView>().FromComponentOn(_ballView.gameObject).AsSingle().NonLazy();
        Container.Bind<IFinishBumperView>().To<FinishBumperView>().FromComponentOn(_finishBumperView.gameObject).AsSingle().NonLazy();
        Container.Bind<IVictoryPopUpView>().To<VictoryPopUpView>().FromComponentOn(_victoryPopUpView.gameObject).AsSingle().NonLazy();
        Container.Bind<ICloneBallBumperView>().To<CloneBallBumperView>().FromComponentOn(_cloneBallBumperView.gameObject).AsSingle().NonLazy();
    }
}