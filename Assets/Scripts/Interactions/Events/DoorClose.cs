using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions 
{
    public class DoorClose : MonoBehaviour
    {
        [SerializeField] private GameObject doorObj;
        [SerializeField] private GameObject notificationText;
        private string text;
        
        public void DoorSlam()
        {
            doorObj.GetComponent<AudioSource>().Play();
            doorObj.GetComponent<Animator>().Play("MainDoorClose");
            text = "The main door closed!";
            StartCoroutine(Notification());
        }

        private IEnumerator Notification()
        {
            notificationText.SetActive(true);
            notificationText.GetComponent<Text>().text = text;

            yield return new WaitForSeconds(2.0f);
            notificationText.SetActive(false);
            notificationText.GetComponent<Text>().text = "";
        }
        public void MainDoorInteraction()
        {
            text = "Door is locked!!";
            StartCoroutine(Notification());
        }
    }
}


