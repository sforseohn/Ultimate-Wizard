using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float power = 1.0f;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isHurt;

    public int life = 3;
    private bool attack = true;
    private int dum = -1;

    //public GameObject dummyHead;
    Sprite selectedSprite = null;

    public Sprite Sonic_h;
    public Sprite Hercules_h;
    public Sprite Zombie_h;

    public float maxShotDelay=0.4f;
    public float curShotDelay;

    private Vector2 touchStart;

    public GameObject bulletObjA;
    private UIManager ui;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private GameObject SoundManager;

    //Animator anim;

    private void Start() {
        ui = GameObject.FindObjectOfType<UIManager>();
        facechange();
    }

    // Update is called once per frame
    void Update() {
        Fire();
        Reload();

        if (Input.GetMouseButtonDown(0)) {
            touchStart = Input.mousePosition;
        } else if (Input.GetMouseButton(0)) {
            Vector2 delta = (Vector2)Input.mousePosition - touchStart;

            MoveCharacter(delta);

            touchStart = Input.mousePosition;
        }
    }

    void facechange() {
        dum = PlayerPrefs.GetInt("dum");
        switch (dum){
            case 0:
                selectedSprite = Sonic_h;
                ChangeDummyface(selectedSprite);
                maxShotDelay = 0.2f;
                break;

            case 1:
                selectedSprite = Hercules_h;
                ChangeDummyface(selectedSprite);
                power =2;
                break;
                
            case 2:
                selectedSprite = Zombie_h;
                ChangeDummyface(selectedSprite);
                life = 4;
                break;

            default:
                selectedSprite = Sonic_h;
                ChangeDummyface(selectedSprite);
                speed = 1.5f;
                break;
        }
    }

    public void ChangeDummyface(Sprite newSprite) {
        SpriteRenderer dummyRenderer = gameObject.GetComponent<SpriteRenderer>();
        dummyRenderer.sprite = newSprite;
    }

    void MoveCharacter(Vector2 delta) {
        float newSpeed;
        if (isTouchTop && delta.y > 0 || isTouchBottom && delta.y < 0) {
            newSpeed = 0;
        } else{
            newSpeed = speed;
        }

        transform.position += new Vector3(0, delta.y * newSpeed * Time.deltaTime, 0);
    }

    void Fire() {
        if ((curShotDelay < maxShotDelay) || (attack = false))
            return;

        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.left * power, ForceMode2D.Impulse);

        curShotDelay = 0;
    }

    void Reload() {
        curShotDelay += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Border") {
            switch (collision.gameObject.name) {
                case "Top":
                    isTouchTop = true;
                    break;

                case "Bottom":
                    isTouchBottom = true;
                    break;
            }
        } else if (collision.gameObject.tag == "MonsterBullet") {
            Destroy(collision.gameObject);

            if (isHurt) {
                return;
            }
            isHurt = true;

            life--;
            bgm.Play();
            ui.UpdateLifeIcon(life);
            RespawnPlayer();

            if (life == 0) {
                bgm.Play();
                Invoke("DestroyObject", 3f);
                SoundManager.GetComponent<SoundManager>().DestroyBgm();
                GameManager.instance.GameOver();
            } else {
                RespawnPlayer();
            }
        }
    }

    private void DestroyObject() {
        Destroy(this.gameObject);
        Time.timeScale = 0;
    }

    public void RespawnPlayer() {
        Invoke("RespawnPlayerExe", 3f);
        // player.transform.position = Vector3.down * 3.5;
        //player.SetActive(true);
    }

    public void RespawnPlayerExe() {
        Player playerLogic = gameObject.GetComponent<Player>();
        playerLogic.isHurt = false;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Border") {
            switch (collision.gameObject.name) {
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