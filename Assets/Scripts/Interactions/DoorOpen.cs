using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Interactions {
    public class DoorOpen : MonoBehaviour
    {

        private Animator doorAnim;
        private bool isDoorOpen = false;

        [SerializeField] private Inventory inventory = null;
        [SerializeField] private GameObject textObject;
        private bool firstTime = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
            textObject.GetComponent<Text>().text = "";
        }
        // Update is called once per frame

        public void PlayAnimation()
        {
            textObject.SetActive(true);
            if (inventory.hasKey)
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
