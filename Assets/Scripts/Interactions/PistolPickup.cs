using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interactions
{
    public class PistolPickup : MonoBehaviour
    {
        public void Ending()
        {
            SceneManager.LoadScene("Intro", LoadSceneMode.Single);
        }
    }
}
