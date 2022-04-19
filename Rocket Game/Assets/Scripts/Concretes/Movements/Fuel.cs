using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RocketGame.Movements
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float maxFuel = 100f;
        [SerializeField] float currentFuel;
        [SerializeField] ParticleSystem _particleSystem;

        private void Awake()
        {

            currentFuel = maxFuel;

        }

        public void FuelIncrease(float increase)
        {

            currentFuel += increase;
            currentFuel = Mathf.Min(currentFuel, maxFuel);

            if (_particleSystem.isPlaying)
            {

                _particleSystem.Stop();

            }

        }

        public void FuelDecrease(float decrease)
        {
            currentFuel -= decrease;
            currentFuel = Mathf.Max(currentFuel, 0);

            if (_particleSystem.isStopped)
            {

                _particleSystem.Play();

            }
        }

        public bool isEmpty => currentFuel < 1f;



    }
}
