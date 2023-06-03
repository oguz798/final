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
            textObject.SetActive(true);
            if (inventory.hasKeyRoom)
            {
                if (!isDoorOpen)
                {
                    if (!firstTime) 
                    {
                        textObject.GetComponent<Text>().text = "Inserted the key";
                        firstTime = true;
                    }
                    
                    doorAnim.Play("RoomOpen", 0, 0.0f);
                    StartCoroutine(TextDestroy());
                    isDoorOpen = true;               
                }
                else
                {
                    textObject.GetComponent<Text>().text = "";
                    doorAnim.Play("RoomClose", 0, 0.0f);
                    isDoorOpen = false;
                    StartCoroutine(TextDestroy());
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
            textObject.SetActive(true);
            if (inventory.hasKeyBedroom)
            {
                if (!isDoorOpen)
                {
                    if (!firstTime)
                    {
                        textObject.GetComponent<Text>().text = "Inserted the key";
                        firstTime = true;
                    }

                    doorAnim.Play("DoorOpen", 0, 0.0f);
                    StartCoroutine(TextDestroy());
                    isDoorOpen = true;
                }
                else
                {
                    textObject.GetComponent<Text>().text = "";
                    doorAnim.Play("DoorClose", 0, 0.0f);
                    isDoorOpen = false;
                    StartCoroutine(TextDestroy());
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
            player.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            textObject.SetActive(false);
            player.SetActive(true);
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
