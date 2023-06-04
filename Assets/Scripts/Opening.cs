using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
