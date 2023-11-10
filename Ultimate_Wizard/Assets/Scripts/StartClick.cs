using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour
{
    // 게임 시작
    public void OnClick() {
        SceneManager.LoadScene("1_Story");
    }
}
