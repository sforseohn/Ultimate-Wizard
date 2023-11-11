using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 대화 클래스
[System.Serializable]
public class Dialogue {
    public string name;
    [TextArea] public string dialogue;
    public Sprite image;
}

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private Text character_name; // 캐릭터 이름
    [SerializeField] private Text sentence; // 대화 내용
    [SerializeField] private SpriteRenderer sprite_character; // 캐릭터 이미지 제어 변수
    [SerializeField] private Image dialogue_box; // 다이얼로그 박스 제어 변수

    private bool isDialogue = false; // 대화가 진행중인지
    private int count = 0; // 대화 얼마나 진행되었는지

    [SerializeField] private Dialogue[] dialogues;
    public string text = "";

    private void Start() {
        ShowDialogue();
    }

    public void ShowDialogue() {
        // 대화 시작
        StartDialogue(true);
        count = 0;
        // 다음 대화 진행
        StartCoroutine("Next");
    }

    private void StartDialogue(bool flag) {
        sprite_character.gameObject.SetActive(flag);
        dialogue_box.gameObject.SetActive(flag);
        isDialogue = flag;
    }

    // 다이얼로그 시작
    IEnumerator Next() {
        // 아직 스크립트 남아있을 경우
        if(count < dialogues.Length) {
            // 캐릭터 이름
            character_name.text = dialogues[count].name;
            // 캐릭터 이미지
            sprite_character.sprite = dialogues[count].image;
            

            // 텍스트 타이핑 효과
            string s = dialogues[count].dialogue;
            count++;
            text = "";

            for (int i = 0; i < s.Length; i++) {
                text += s[i];
                sentence.text = text;
                yield return new WaitForSeconds(0.05f);
            }
        } else {
            StartDialogue(false); // 대화 종료
        }
    }

    // 다이얼로그 창 누르면 전체 대화 출력
    public void DialogueOnClick() {
        StopCoroutine("Next");
        sentence.text = dialogues[--count].dialogue;
        count++;
    }

    public void NextButton() {
        // 전체 대화 출력 후 다음 대화로 넘어가기
        DialogueOnClick();
        StartCoroutine("Next");
    }

    public void End() {
        SceneManager.LoadScene("0_Main");
    }

    public void Skip() {
        SceneManager.LoadScene("2_DummySelect");
    }
}