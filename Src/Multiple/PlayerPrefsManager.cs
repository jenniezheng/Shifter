using UnityEngine;
using System.Collections;

namespace Shifter.AllScenes
{
    public class PlayerPrefsManager : MonoBehaviour {

        #region keys
        static string MASTER_VOLUME_KEY = "master_volume";
        static string GRAPHICS_QUALITY_KEY = "graphics_quality";
        static string TOTAL_DEATHS_KEY = "total_deaths";
        static string TOTAL_ASSIMILATIONS_KEY = "total_assimilations";
        static string TOTAL_FRIENDLY_KILLS_KEY = "total_friendly_kills";
        static string TOTAL_ENEMY_KILLS_KEY = "total_enemy_kills";
        static string PLAYER_NAME_KEY = "player_name";
        #endregion




        #region Public Methods
        public static bool firstTimePlay()
        {
            return !PlayerPrefs.HasKey(MASTER_VOLUME_KEY);
        }

        public static string getPlayerName()
        {
            return PlayerPrefs.GetString(PLAYER_NAME_KEY);
        }

        public static void setPlayerName(string name)
        {
            if (name !="")
                PlayerPrefs.SetString(PLAYER_NAME_KEY, name);
            else Debug.Log("Player name invalid.");
        }

        public static float getMasterVolume()
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }

        public static void setMasterVolume(float volume)
        {
            if (volume >= 0 && volume <= 1)
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            else Debug.LogError("Master volume out of range.");
        }

        public static int getGraphicsQuality()
        {
            return PlayerPrefs.GetInt(GRAPHICS_QUALITY_KEY);
        }

        public static void setGraphicsQuality(int quality)
        {
            if (quality >= 0 && quality <= 5)
                PlayerPrefs.SetInt(GRAPHICS_QUALITY_KEY, quality);
            else Debug.LogError("graphics quality out of range.");
        }

        public static float getTotalDeaths()
        {
            return PlayerPrefs.GetInt(TOTAL_DEATHS_KEY);
        }

        public static void setTotalDeaths(int num)
        {
            if (num >= 0)
                PlayerPrefs.SetInt(TOTAL_DEATHS_KEY, num);
            else Debug.LogError("Total deaths out of range.");
        }

        public static float getTotalAssimilations()
        {
            return PlayerPrefs.GetInt(TOTAL_ASSIMILATIONS_KEY);
        }

        public static void setTotalAssimilations(int num)
        {
            if (num >= 0)
                PlayerPrefs.SetInt(TOTAL_ASSIMILATIONS_KEY, num);
            else Debug.LogError("Total assimilates out of range.");
        }

        public static float getTotalFriendlyKills()
        {
            return PlayerPrefs.GetInt(TOTAL_FRIENDLY_KILLS_KEY);
        }

        public static void setTotalFriendlyKills(int num)
        {
            if (num >= 0)
                PlayerPrefs.SetInt(TOTAL_FRIENDLY_KILLS_KEY, num);
            else Debug.LogError("Total friendly kills out of range.");
        }

        public static float getTotalEnemyKills()
        {
            return PlayerPrefs.GetInt(TOTAL_ENEMY_KILLS_KEY);
        }

        public static void setTotalEnemyKills(int num)
        {
            if (num >= 0)
                PlayerPrefs.SetInt(TOTAL_ENEMY_KILLS_KEY, num);
            else Debug.LogError("Total enemy kills out of range.");
        }
        #endregion


        #region Tests
        public static string prefsToString()
        {
            string s= "master_volume: ";
            s += getMasterVolume();
            return s;
        }
        #endregion


    };

}