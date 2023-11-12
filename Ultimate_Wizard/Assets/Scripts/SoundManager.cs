using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    [SerializeField] private AudioSource bgm;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            if(instance != this) {
                Destroy(this.gameObject);
            }
        }

        bgm.Play();
    }

    public void SetBgm(AudioSource bgm) {
        this.bgm = bgm;
    }

    // Start is called before the first frame update
    void Start() {
        // bgm.Play();
    }

    public void DestroyBgm() {
        Debug.Log($"gameObject: '{gameObject}'");
        bgm.Stop();
    }

    public void Clap(AudioSource audio) {
        audio.Play();
    }
}