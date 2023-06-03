using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Interactions
{
    public class NotePickup : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private AudioSource noteSound;
       
        [Header("UI Text")]
        [SerializeField] private GameObject noteCanvas;
        [SerializeField] private TMP_Text noteTextUI;
        [SerializeField] private GameObject cameraOverlay;

        [SerializeField] [TextArea] private string noteText;

        public bool isOpen = false;
        public bool triggerEvent=false;

        public void ShowNote()
        {

            noteTextUI.text = noteText;
            noteCanvas.SetActive(true);
            cameraOverlay.SetActive(false);
            noteSound.Play();
            isOpen = true;
            player.SetActive(false);

        }

        public void DisableNote()
        {
            noteCanvas.SetActive(false);
            cameraOverlay.SetActive(true);
            isOpen = false;
            player.SetActive(true);
            triggerEvent = true;
        }
    }
}
