using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    private bool isDragActive = false;
    //터치 시작점
    private Vector2 touchStart;


    public GameObject bulletObjA;
    

    //Animator anim;

    // Update is called once per frame
    void Update()
    {
        Fire();

        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭한 지점 저장
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // 마우스 클릭한 지점과 현재 마우스 위치의 차이를 계산
            Vector2 delta = (Vector2)Input.mousePosition - touchStart;

            // 캐릭터 이동
            MoveCharacter(delta);

            // 마우스 클릭한 지점 업데이트
            touchStart = Input.mousePosition;
        }
 

    }

    void MoveCharacter(Vector2 delta)
    {
        if (isTouchTop && delta.y>0 || isTouchBottom && delta.y<0)
        {
   
            speed = 0;
        }
        else
        {
     
            speed = 2; 
        }
        transform.position += new Vector3(0, delta.y * speed * Time.deltaTime, 0);

    }


    void Fire()
    {

        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.left * 15, ForceMode2D.Impulse);
        //위로 쏘는 부분 up 좌우로 할거면 여기를 바꿔 left로 바꿔보자
    }



    void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Border")
         {
             switch (collision.gameObject.name)
             {
                 case "Top":
                     isTouchTop = true;
                     break;
                 case "Bottom":
                     isTouchBottom = true;

                     break;

               /*  case "Left":
                     isTouchLeft = true;

                     break;

                 case "Right":
                     isTouchRight = true;

                     break;*/

             }
         }
     }

    void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Border")
         {
             switch (collision.gameObject.name)
             {
                 case "Top":
                     isTouchTop = false;
                     break;
                 case "Bottom":
                     isTouchBottom = false;

                     break;

               /*  case "Left":
                     isTouchLeft = false;

                     break;

                 case "Right":
                     isTouchRight = false;

                     break;*/

             }
         }
     }
}
