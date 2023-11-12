using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    [SerializeField] private AudioSource clap;
    [SerializeField] private Image image; // 페이드아웃 효과에 쓰일 이미지
    [SerializeField] private float delay_time = 1.5f;


    [SerializeField] private GameObject start; // 시작 배경
    [SerializeField] private GameObject end; // 끝 배경

    private void Awake() {
        end.SetActive(false);
        image.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start() {
        Debug.Log("4_Ending 진행 시작");
        // 배경 이미지 페이드 인 효과
        StartCoroutine("FadeOutCoroutine");
    }

    IEnumerator FadeOutCoroutine() {
        // 처음 알파값
        float fadeCount = 1;

        while(fadeCount > 0.0f) {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.1f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        // 애니메이션 끝날 때 까지 기다림
        yield return new WaitForEndOfFrame();
        start.SetActive(false);
        end.SetActive(true);


        // 애니메이션 딜레이
        yield return new WaitForSeconds(delay_time);
        Debug.Log("End");
        End();
        StopCoroutine("FadeOutCoroutine");
    }

    public void End()
    {
        SoundManager.instance.DestroyBgm();
        SceneManager.LoadScene("0_Main");
    }
}
