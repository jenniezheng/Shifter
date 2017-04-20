using UnityEngine;
using UnityEngine.UI;
using Shifter.AllScenes;

namespace shifter.preconnect
{
    public class Name: MonoBehaviour
    {
        public InputField nameInput;

        #region built in messages 
        void Start()
        {
            string playerName = PlayerPrefsManager.getPlayerName();
            nameInput.interactable = (playerName==""|| playerName == "No_Name");
            if (playerName != "") nameInput.text = playerName;
        }
        #endregion


        #region UI Called
        public void onNameChange()
        {
            string playerName = nameInput.text;
            Debug.Log("Player name is " + playerName);
            if (playerName != "") PlayerPrefsManager.setPlayerName(playerName);
            else PlayerPrefsManager.setPlayerName("No_Name");
        }

        public void resetName()
        {
            PlayerPrefsManager.setPlayerName("No_Name");
            nameInput.interactable = true;
        }
        #endregion
    };

}
