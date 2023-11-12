using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    // 순서대로 opening, dummy, shooting, ending
    [SerializeField] private AudioSource[] audios;
    private AudioSource bgm;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            if(instance != this) {
                Destroy(this.gameObject);
            }
        }
    }

    public void BgmPlay(int scene) {
        this.bgm = audios[scene];
        StartBgm();
    }

    private void SetBgm(AudioSource bgm) {
        this.bgm = bgm;
    }

    private void StartBgm() {
        bgm.Play();
    }

    public void DestroyBgm() {
        Debug.Log($"gameObject: '{gameObject}'");
        bgm.Stop();
    }

    public void Clap(AudioSource audio) {
        audio.Play();
    }
}