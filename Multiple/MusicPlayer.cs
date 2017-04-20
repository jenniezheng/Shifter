using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shifter.AllScenes
{
    public class MusicPlayer : MonoBehaviour
    {
        public AudioClip BGM;
        public AudioClip SplashSFX;
        public AudioClip RoomSFX;
        public AudioClip GameSFX;
        public AudioClip ScoreSFX;
        AudioSource musicSource;
        AudioSource sfxSource;

        void Awake()
        {
            GameObject.DontDestroyOnLoad(gameObject);
            AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
            if (audioSources.Length < 2)
            {
                Debug.LogError("Need two audio sources on Music Player!");
                Destroy(gameObject);
            }

            if (Shifter.AllScenes.PlayerPrefsManager.firstTimePlay()) AudioListener.volume = .5f;
            else AudioListener.volume = Shifter.AllScenes.PlayerPrefsManager.getMasterVolume();

            musicSource = audioSources[0];
            musicSource.loop = true;
            musicSource.clip = BGM;
            sfxSource = audioSources[1];
            sfxSource.loop = false;

            SceneManager.sceneLoaded += onSceneLoaded;
        }

        void onSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "Preconnect" || scene.name == "Room")
            {
                if (!musicSource.isPlaying)
                    musicSource.Play();
            }
            else musicSource.Stop();

            if (sfxSource.clip != null) sfxSource.Stop();

            if (scene.name == "Splash") sfxSource.clip = SplashSFX;
            else if (scene.name == "Room") sfxSource.clip = RoomSFX;
            else if (scene.name.Contains("Game")) sfxSource.clip = GameSFX;
            else if (scene.name == "Score") sfxSource.clip = ScoreSFX;
            else sfxSource.clip = null;

            if (sfxSource.clip != null) sfxSource.Play();
        }

    };

}
