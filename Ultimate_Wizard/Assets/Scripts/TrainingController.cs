using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingController : MonoBehaviour
{
    // 훈련 내용
    [SerializeField] private GameObject ui;
    [SerializeField] private Text train_1;
    [SerializeField] private Text train_2;
    [SerializeField] private Text train_3;

    [SerializeField] private Narrator[] options;
    private int count = 0; // 대화 얼마나 진행되었는지

    // 훈련 결과
    // 순서대로 스피드, 공격력, 체력
    private List<int> types;
    private List<int> candidates = new List<int>();
    private List<string> type_name = new List<string>() {"스피드", "공격", "체력"};

    // 결과 화면[SerializeField]
    [SerializeField] private dummy dummy;
    [SerializeField] private GameObject EvolutionUI;
    private textchange textChangeInstance;
    Sprite selectedSpritebody;

    [SerializeField] private Sprite Sonic;
    [SerializeField] private Sprite Hercules;
    [SerializeField] private Sprite Zombie;

    // 초기 세팅
    private void Awake() {
        textChangeInstance = FindObjectOfType<textchange>();
        EvolutionUI.SetActive(false);
        ShowTrain(false);
    }

    private void ShowTrain(bool flag) {
        types = new List<int>() {0, 0, 0};
        candidates = new List<int>();
        count = 0;
        ui.gameObject.SetActive(flag);
    }

    public void NextButton() {
        ShowTrain(true);
        count = 0;

        Choice();
    }

    public void Choice() {
        // 선택지 남아있을 경우
        if(count < options.Length) {
            // 3개 선택지 출력
            train_1.text = options[count++].dialogue;
            train_2.text = options[count++].dialogue;
            train_3.text = options[count++].dialogue;
        } else { // 선택지 출력 끝난 경우
            DummyResult();
        }
    }

    public void CreateDummy(int type) {
        types[type]++;
    }

    private void DummyResult() {
        // 최댓값 받기
        int maxVal = types.Max();

        // types 배열에서 최댓값에 해당하는 인덱스 번호 저장
        for (int i = 0; i < types.Count; i++){
            if(maxVal == types[i]) {
                candidates.Add(i);
            }
        }

        // 결과 반환
        int random = Random.Range(0, candidates.Count);
        Debug.Log($"result(0 스피드, 1 공격력, 2 체력): '{type_name[candidates[random]]}'");
        
        SelectDummy(candidates[random]);
        textchange_(candidates[random]);
    }

    public void textchange_(int candidates) {
        dummy.changeText(candidates);
    }

    public void Evolution_dummy() {
        EvolutionUI.SetActive(true);
    }

    public void SelectDummy(int candidates) {
        selectedSpritebody = null;
        PlayerPrefs.SetInt("dum", candidates);

        switch (candidates){
            case 0:
                selectedSpritebody = Sonic;
                dummy.ChangeDummyImage(selectedSpritebody);
                Evolution_dummy();
                break;

            case 1:
                selectedSpritebody = Hercules;
                dummy.ChangeDummyImage(selectedSpritebody);
                Evolution_dummy();
                break;

            case 2:
                selectedSpritebody = Zombie;
                dummy.ChangeDummyImage(selectedSpritebody);
                Evolution_dummy();
                break;
            
            default:
                selectedSpritebody = Sonic;
                dummy.ChangeDummyImage(selectedSpritebody);
                Evolution_dummy();
                break;
        }

        dummy.GetComponent<dummy>().MoveToPosition(0f, 0f);
    }

    public void NextScene(string scene_name) {
        // 화면 전환
        SceneManager.LoadScene(scene_name);
    }

    public void Retry() {
        ShowTrain(false);
    }
}
