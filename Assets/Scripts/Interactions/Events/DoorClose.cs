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
        [SerializeField] private GameObject altarnate;
        [SerializeField] private GameObject bedroomObj;
        private string text;
        
        public void DoorSlam()
        {
            doorObj.GetComponent<AudioSource>().Play();
            doorObj.GetComponent<Animator>().Play("MainDoorClose");
            
            text = "The door closed!";

            StartCoroutine(Notification());

        }
        public void BedroomDoor()
        {
            bedroomObj.GetComponent<AudioSource>().Play();
            bedroomObj.GetComponent<Animator>().Play("BedroomClose");
            text = "The door closed!";
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
        public void AltarnateAnimation()
        {
            altarnate.GetComponent<Animator>().Play("KitchenAltarnate");
            StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(1.0f);
            altarnate.SetActive(false);
        }
    }
}


