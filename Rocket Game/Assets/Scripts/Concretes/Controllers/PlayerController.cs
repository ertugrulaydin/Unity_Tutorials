using System.Collections;
using System.Collections.Generic;
using RocketGame.Inputs;
using RocketGame.Movements;
using RocketGame.Managers;
using UnityEngine;


namespace RocketGame.Controllers
{

    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float turnSpeed = 35f;
        [SerializeField] float force = 55f;

        DefaultInput _input;
        Mover _mover;
        Rotator _rotator;
        Fuel _fuel;

        bool _canMove;
        bool _canForceUp;
        float _LeftRight;

        public float TurnSpeed { get => turnSpeed; set => turnSpeed = value; }
        public float Force { get => force; set => force = value; }

        public bool CanMove => _canMove;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
        }

        private void Start()
        {
            _canMove = true;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnEventTriggered;
            GameManager.Instance.OnMissionSucced += HandleOnEventTriggered;
        }


        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggered;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTriggered;
        }

        private void Update()
        {
            if (!_canMove) return;

            if (_input.IsForceUp && !_fuel.isEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(0.01f);
            }
            _LeftRight = _input.LeftRight;
        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }
            _rotator.FixedTick(_LeftRight);
        }

        private void HandleOnEventTriggered()
        {
            _canMove = false;
            _canForceUp = false;
            _LeftRight = 0f;
            _fuel.FuelIncrease(0f);
        }
    }
}
