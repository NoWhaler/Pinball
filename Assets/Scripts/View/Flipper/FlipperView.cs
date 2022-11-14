using Pinball.Presenter;
using UnityEngine;
using View;
using Zenject;

public class FlipperView : MonoBehaviour, IFlipperView
{
    
    [SerializeField] private float _torqueForce;
    private IFlipperPresenter _flipperPresenter;
    private Rigidbody2D _rigidbody;
    private Touch _touch;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipperPresenter = new FlipperPresenter(this);
    }

    private void Update()
    {
        _flipperPresenter.AddTorque();
    }

    public void AddTorqueToFlipper()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    _rigidbody.AddTorque(_torqueForce);
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }
    }
}
