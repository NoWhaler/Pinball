using View;
using Zenject;

namespace Pinball.Presenter
{
    public class CloneBallBumper: ICloneBallBumper
    {
        [Inject] private ICloneBallBumperView _cloneBallBumperView;

        public CloneBallBumper(ICloneBallBumperView cloneBallBumperView)
        {
            _cloneBallBumperView = cloneBallBumperView;
        }
    }
}