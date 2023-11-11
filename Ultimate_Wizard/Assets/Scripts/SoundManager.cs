using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    private void Awake() {
        SoundManager[] soundManagers = FindObjectsOfType<SoundManager>();

        if(SceneManager.GetActiveScene().name == "1_StoryFirst"
            || SceneManager.GetActiveScene().name == "1_StorySecond"
            || SceneManager.GetActiveScene().name == "4_Ending_Char"
            || SceneManager.GetActiveScene().name == "4_Ending_Narr") {
            if(soundManagers.Length == 1) {
                DontDestroyOnLoad(gameObject);
                Debug.Log($"'{gameObject}'");
            } else {
                DestroyBgm();
            }
        }

        if(SceneManager.GetActiveScene().name == "2_DummySelect") {
            // Check if there is another SoundManager in the scene
            soundManagers = FindObjectsOfType<SoundManager>();
            if (soundManagers.Length == 0)
            {
                // If no SoundManager exists in the scene, create a new one
                Instantiate(gameObject);
            }

            // Play the BGM
            bgm.Play();
        }
    }

    // Start is called before the first frame update
    void Start() {
        // bgm.Play();
    }

    public void DestroyBgm() {
        Destroy(gameObject);
    }
}