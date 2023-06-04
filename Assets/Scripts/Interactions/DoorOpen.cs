using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Interactions {
    public class DoorOpen : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Animator doorAnim;
        private bool isDoorOpen = false;
        private RayManager whichDoor;

        [SerializeField] private Inventory inventory = null;
        [SerializeField] private GameObject textObject;
        
        private bool firstTime = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
            textObject.GetComponent<Text>().text = "";
        }
        // Update is called once per frame

        public void KeyRoom()
        {
            textObject.GetComponent<Text>().text = "";
            textObject.SetActive(true);
            if (inventory.hasKeyRoom)
            {
                if (!isDoorOpen)
                {                   
                    doorAnim.Play("RoomOpen", 0, 0.0f);
                    isDoorOpen = true;               
                }
                else
                {
                    textObject.GetComponent<Text>().text = "";
                    doorAnim.Play("RoomClose", 0, 0.0f);
                    isDoorOpen = false;
                }       
            }
            else
            {
                textObject.GetComponent<Text>().text = "Door is locked";
                StartCoroutine(TextDestroy());

            }
        }
        public void KeyBedroom()
        {
            textObject.GetComponent<Text>().text = "";
            textObject.SetActive(true);
            if (inventory.hasKeyBedroom)
            {
                if (!isDoorOpen)
                {
                    doorAnim.Play("Bedroom", 0, 0.0f);
                    isDoorOpen = true;
                }
                else
                {
                    textObject.GetComponent<Text>().text = "";
                    doorAnim.Play("BedroomClose", 0, 0.0f);
                    isDoorOpen = false;
                }
            }
            else
            {
                textObject.GetComponent<Text>().text = "Door is locked";
                StartCoroutine(TextDestroy());

            }
        }
        private IEnumerator TextDestroy()
        {
            textObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            textObject.SetActive(false);
        }

        public void NoKeyDoor()
        {
            if (!isDoorOpen)
            {
                doorAnim.Play("DoorBthOpen", 0, 0.0f);
                isDoorOpen = true;
            }
            else
            {
                doorAnim.Play("DoorBthClose", 0, 0.0f);
                isDoorOpen = false;
            }
        }
                
    }
}
