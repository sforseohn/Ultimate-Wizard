using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    public Image[] lifeImage;
    //수정
    public Sprite fulllife;
    public Sprite emptylife;
    //수정 끝
    public GameObject gameOverSet;

    public GameObject GamoverUI;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        gameOverSet.SetActive(false);
        GamoverUI.SetActive(false);
    }


    private void Update()
    {


    }

    public void UpdateLifeIcon(int life)
    {

        foreach(Image img in lifeImage)
        {
            img.sprite = emptylife;

            for(int index = 0; index < life; index++)
            {
                lifeImage[index].sprite = fulllife;
            }

        }
      
    }

    public void RespawnPlayer()
    {

        Invoke("RespawnPlayerExe", 3f);
        // player.transform.position = Vector3.down * 3.5;
        //player.SetActive(true);
    }

    public void RespawnPlayerExe()
    {

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHurt = false;
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
        GamoverUI.SetActive(true);

    }

    public void GameRetry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
