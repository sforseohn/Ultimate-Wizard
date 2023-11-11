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
    public GameObject gameOverSet;


    private void Update()
    {

        
    }

    public void UpdateLifeIcon(int life)
    {
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe",3f);
       // player.transform.position = Vector3.down * 3.5;
        player.SetActive(true);
    }

    public void RespawnPlayerExe(bool attack)
    {
        attack = true;

       // player.transform.position = Vector3.down * 3.5;
       // player.SetActive(true);

        // player.transform.position = Vector3.down * 3.5;
        // player.SetActive(true);

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHurt = false;

    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }
}
