using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dummy : MonoBehaviour
{



    // Start is called before the first frame update

    //public SpriteRenderer dummyRenderer;
    [SerializeField]
    private Text text;
    private Vector2 initialPosition;  // �ʱ� ��ġ ���� ����

    
    void Start()
    {
     
        initialPosition = transform.position;
    }

    public void changeText(int candidates)
    {
        switch (candidates)
        {
            case 0:
                text.text = "더미가 소닉으로 진화했어!";
                break;

            case 1:
                text.text = "더미가 헤라클레스로 진화했어!";
                break;

            case 2:
                text.text = "더미가 좀비로 진화했어!";
                break;
        }

    }

    public void MoveToPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    public void ChangeDummyImage(Sprite newSprite)
        {
        SpriteRenderer dummyRenderer = gameObject.GetComponent<SpriteRenderer>();
        dummyRenderer.sprite = newSprite;
       
    }




}
