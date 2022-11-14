using System;
using Pinball.Presenter;
using UnityEngine;
using Zenject;

namespace View
{
    public class CloneBallBumperView : MonoBehaviour, ICloneBallBumperView
    {
        [Inject] 
        private ICloneBallBumper _cloneBallBumper;

        [SerializeField] private GameObject _ballPrefab;

        [Inject]
        private DiContainer _diContainer;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var ball = col.collider.GetComponent<BallView>();
            if (ball != null)
            {
                _diContainer.InstantiatePrefab(_ballPrefab, transform.position, Quaternion.identity, transform.root);
                gameObject.SetActive(false);
            }
        }
    }
}