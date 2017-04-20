using UnityEngine;
using System.Collections;

namespace Shifter.AllScenes
{
   
    public class ToggleWithEsc : MonoBehaviour
    {
        
        CanvasGroup cg;
        bool active = false;
        void Start()
        {
            cg = gameObject.GetComponent<CanvasGroup>();
            if (cg == null) Debug.LogError("Missing canvas group.");
            else
            {
                cg.alpha = 0;
                cg.interactable = false;
                cg.blocksRaycasts = false;
            }
        }
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                active = !active;
                if (active)
                {
                    cg.alpha = 1;
                    cg.interactable = true;
                    cg.blocksRaycasts = true;
                }
                else
                {
                    cg.alpha = 0;
                    cg.interactable = false;
                    cg.blocksRaycasts = false;
                }
            }
        }
    }
}
