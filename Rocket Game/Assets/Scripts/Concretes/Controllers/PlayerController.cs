using System.Collections;
using System.Collections.Generic;
using RocketGame.Inputs;
using RocketGame.Movements;
using UnityEngine;

namespace RocketGame.Controllers
{

    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float turnSpeed = 10f;
        [SerializeField] float force = 50f;

        DefaultInput _input;
        Mover _mover;
        Rotator _rotator;

        bool _isForceUp;
        float _LeftRight;

        public float TurnSpeed { get => turnSpeed; set => turnSpeed = value; }
        public float Force { get => force; set => force =value; }

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
        }

        private void Update()
        {
            

            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }
            _LeftRight = _input.LeftRight;
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }
            _rotator.FixedTick(_LeftRight);
        }
    }
}
