using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RocketGame.Managers;
using RocketGame.Controllers;

namespace RocketGame.Abstracts.Controllers
{
    public abstract class WallController : MonoBehaviour
    {

        public void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player != null && player.CanMove)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}
