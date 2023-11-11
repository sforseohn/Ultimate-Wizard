using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 대화 클래스
[System.Serializable]
public class Character {
    public string name;
    [TextArea] public string dialogue;
    public Sprite image;
}
