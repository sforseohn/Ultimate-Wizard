using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject btn;
    // Start is called before the first frame update
    void Start() {
        string param = "";
        if(btn.CompareTag("Main")) {
            param = "0_Main";
        } else if(btn.CompareTag("Re")) {
            param = "2_DummySelect";
        }
        btn.GetComponent<Button>().onClick.AddListener(delegate {btnClicked(param);});
    }

    public void btnClicked(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }
}
