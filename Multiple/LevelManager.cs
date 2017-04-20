using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shifter.AllScenes
{
    public class LevelManager : MonoBehaviour
    {


        public void loadLevel(int lvl) //for buttons
        {
            SceneManager.LoadScene(lvl);
        }

        public static void loadLevelStatic(int lvl)
        {
            SceneManager.LoadScene(lvl);
        }

    }
}
