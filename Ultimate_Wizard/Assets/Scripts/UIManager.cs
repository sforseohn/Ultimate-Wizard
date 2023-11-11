using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] lifeImage;
    public Sprite fulllife;
    public Sprite emptylife;
    public GameObject gameOverSet;

    public GameObject GameoverUI;
    private int dum = -1;

    // Start is called before the first frame update
    void Awake() {
        lifeImage[3].gameObject.SetActive(false);
        dum = PlayerPrefs.GetInt("dum");
        // 좀비인 경우
        if(dum == 2) {
            lifeImage[3].gameObject.SetActive(true);
        }
        HideGameOverUI();
        
    }

    public void HideGameOverUI()
    {
        gameOverSet.SetActive(false);
        GameoverUI.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        gameOverSet.SetActive(true);
        GameoverUI.SetActive(true);
    }

    public void UpdateLifeIcon(int life)
    {
        foreach (Image img in lifeImage)
        {
            img.sprite = emptylife;
            for (int index = 0; index < life; index++)
            {
                lifeImage[index].sprite = fulllife;
            }
        }
    }
}
