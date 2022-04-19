using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RocketGame.Managers;

namespace RocketGame.Controllers
{
    public class WallController : MonoBehaviour
    {

        public void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}
