using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions {
    public class StoryText1 : MonoBehaviour
    {
        [SerializeField] private GameObject storyText;
        [SerializeField] private GameObject interactionText;
        [SerializeField] private Inventory inventory;

        public void ShowText(string str)
        {
            storyText.GetComponent<Text>().text = str;
            storyText.SetActive(true);
            interactionText.SetActive(false);

        }
        public void DestroyText()
        {
            storyText.SetActive(false);
        }
    
    }
}
