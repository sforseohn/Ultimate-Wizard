using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float power;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isHurt;

    public GameManager manager;

    public int life = 3;
    private bool attack = true;

    //총알 속도 조정
    public float maxShotDelay;
    public float curShotDelay;



    private bool isDragActive = false;
    //터치 시작점
    private Vector2 touchStart;


    public GameObject bulletObjA;


    //Animator anim;



    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();

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
        if ((curShotDelay < maxShotDelay)||(attack = false))
            return;
        

        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.left * 15, ForceMode2D.Impulse);

        curShotDelay = 0;
    
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
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

               

             }
         }

         else if (collision.gameObject.tag == "MonsterBullet")
        {
<<<<<<< Updated upstream
=======
            Destroy(collision.gameObject);

>>>>>>> Stashed changes
            if (isHurt)
            {
                return;
            }
            isHurt = true;
<<<<<<< Updated upstream
            attack = false;
=======

>>>>>>> Stashed changes
            life--;
            manager.UpdateLifeIcon(life);
            manager.RespawnPlayer();// 애니메이션 재생, 공격x, 3초 무적 필요



            if (life ==0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                manager.GameOver();
            }
            else
            {
                manager.RespawnPlayer();
                
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
