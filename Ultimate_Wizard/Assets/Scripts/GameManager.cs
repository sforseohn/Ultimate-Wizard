using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Player player;

    public Image[] lifeImage;
    public Sprite fulllife;
    public Sprite emptylife;

    public static GameManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            if (instance != this) {
                Destroy(this.gameObject);
            }
        }
    }

    public void GameClear() {
        Time.timeScale = 0f;
        Debug.Log("GameManager 호출 성공");
        // TODO: Ending 씬 불러오기
    }

    public void GameOver() {
        Time.timeScale = 0f;
        UIManager ui = GameObject.FindObjectOfType<UIManager>();
        ui.ShowGameOverUI();        
    }

    public void Letsgo(string scene_name) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene_name);
    }
}