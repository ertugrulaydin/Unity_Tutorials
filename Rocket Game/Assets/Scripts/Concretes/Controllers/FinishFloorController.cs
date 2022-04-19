using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RocketGame.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject finishFireworks;
        [SerializeField] GameObject finishLights;

        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player == null) return;

            if (other.GetContact(0).normal.y == -1)
            {
                finishFireworks.gameObject.SetActive(true);
                finishLights.gameObject.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

