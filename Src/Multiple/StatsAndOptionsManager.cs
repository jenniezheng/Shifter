using UnityEngine;
using UnityEngine.UI;

namespace Shifter.AllScenes
{
    public class StatsAndOptionsManager : MonoBehaviour
    {
        public Slider volumeSlider;
        public Slider graphicsOptionsSlider;
        public Text deathsText;
        public Text assimilationsText;
        public Text friendlyKillsText;
        public Text enemyKillsText;
        [Tooltip("Default panel open")] public GameObject currentPanel;


        #region built in messages 
        void Start() {
             
            if (PlayerPrefsManager.firstTimePlay())
            {
                resetOptions();
                resetStats();
            }
            else
            {
                QualitySettings.SetQualityLevel(PlayerPrefsManager.getGraphicsQuality(), false);
                displayOptions();
                displayStats();
            }
        }
        #endregion

        #region UI called messages

        public void onVolumeChanged()
        {
            AudioListener.volume = volumeSlider.value;
            PlayerPrefsManager.setMasterVolume(volumeSlider.value);
        }

        public void onQualityChanged()
        {
            QualitySettings.SetQualityLevel((int)graphicsOptionsSlider.value, false);
            PlayerPrefsManager.setGraphicsQuality((int)graphicsOptionsSlider.value);

        }

        public void resetOptions()
        {
            volumeSlider.value = (volumeSlider.maxValue+ volumeSlider.minValue)/2;
            graphicsOptionsSlider.value = (1+graphicsOptionsSlider.maxValue + graphicsOptionsSlider.minValue) / 2;
            AudioListener.volume = volumeSlider.value;
            QualitySettings.SetQualityLevel((int)graphicsOptionsSlider.value, false);
            PlayerPrefsManager.setMasterVolume(volumeSlider.value);
            PlayerPrefsManager.setGraphicsQuality((int)graphicsOptionsSlider.value);
        }

        public void resetStats()
        {
            deathsText.text = "0";
            assimilationsText.text = "0";
            friendlyKillsText.text = "0";
            enemyKillsText.text = "0";
            PlayerPrefsManager.setTotalAssimilations(0);
            PlayerPrefsManager.setTotalDeaths(0);
            PlayerPrefsManager.setTotalFriendlyKills(0);
            PlayerPrefsManager.setTotalEnemyKills(0);
        }
        public void displayOptions()
        {
            volumeSlider.value = PlayerPrefsManager.getMasterVolume();
            graphicsOptionsSlider.value = PlayerPrefsManager.getGraphicsQuality();
        }
        public void displayStats()
        {
            deathsText.text = PlayerPrefsManager.getTotalDeaths() + "";
            assimilationsText.text = PlayerPrefsManager.getTotalAssimilations() + "";
            friendlyKillsText.text = PlayerPrefsManager.getTotalFriendlyKills() + "";
            enemyKillsText.text = PlayerPrefsManager.getTotalEnemyKills() + "";
        }

        public void togglePanel(GameObject newPanel)
        {
            if (newPanel == currentPanel) return;
            currentPanel.SetActive(false);
            newPanel.SetActive(true);
            currentPanel = newPanel;
        }
        
        #endregion

        #region Test
        void TestStats()
        {
            PlayerPrefsManager.setTotalAssimilations(100);
            PlayerPrefsManager.setTotalDeaths(50);
            PlayerPrefsManager.setTotalFriendlyKills(2);
            PlayerPrefsManager.setTotalEnemyKills(1);
        }
        void ResetAll()
        {
            PlayerPrefs.DeleteAll();
        }
        #endregion
    };
}