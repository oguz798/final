using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{ 
    public class KitchenEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent myTriggerEnter;
        [SerializeField] private UnityEvent myTriggerExit;
        [SerializeField] private GameObject note;


        [SerializeField] private bool isTriggered = false;

        private Animator doorAnim;

        private void OnTriggerEnter(Collider other)
        {
            if (!isTriggered && note.GetComponent<NotePickup>().triggerEvent)
            {
                //doorSlam.Play();
                //doorAnim.Play("MainDoorClose");
                myTriggerEnter.Invoke();
                isTriggered = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (isTriggered)
            {
                myTriggerExit.Invoke();

            }

        }


    }
}
