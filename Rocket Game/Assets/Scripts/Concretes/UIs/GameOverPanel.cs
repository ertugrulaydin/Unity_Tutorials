using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RocketGame.Managers;


namespace RocketGame.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene();
        }
        public void NoClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}

