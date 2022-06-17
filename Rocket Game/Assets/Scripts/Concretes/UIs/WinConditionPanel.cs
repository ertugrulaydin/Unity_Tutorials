using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RocketGame.Managers;


namespace RocketGame.UIs
{
    public class WinConditionPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }
    }
}


