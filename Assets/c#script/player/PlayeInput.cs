using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerMoveDir
{
    Up, Down, Left, Right,
    UpLeft, UpRight,DownLeft, DownRight,
}
public class PlayerInput : MonoBehaviour
{
    public Vector2 playerDir;//用于储存输入的方向
    public float playerSpeed;//玩家速度
    public PlayerMoveDir dir;
    public GameObject biufab;
    public float shotInterval = 0.4f;
    public float LastTime;
    public int IsGaming;
    public int biuNum;
    public GameObject gun;
    public GameObject PlayerManager1;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6.0f;
        shotInterval = 0.4f;//射击间隔时间
        LastTime = Time.time;
        experience = 0;
        IsGaming = 1;
        biuNum = 8;
     audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputDir();
        GetDirBaseInput();
        TakeFire();
        skill();
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void GetInputDir()
    {
        float h = Input.GetAxis("Horizontal");
        //获得横向方向
        float v = Input.GetAxis("Vertical");
        //获得纵向方向
        playerDir = new Vector2(h, v).normalized;
        //存进playerDir
    }
    void Move()
    {
        if (playerDir == Vector2.zero)//如果无输入，返回0
        {
            return;
        }
        if (playerDir.x != 0 || playerDir.y != 0)//如果有输入，给予速度
        {
            transform.Translate(new Vector2(playerDir.x, playerDir.y) * Time.fixedDeltaTime * playerSpeed);//待了解Translate方法!!!!
        }
    }
    void GetDirBaseInput()
    {
        if (playerDir == Vector2.zero)
        {
            return;
        }
        if (playerDir.x < 0 && playerDir.y < 0)
        {
            dir = PlayerMoveDir.DownLeft;
        }
        if(playerDir.x < 0 && playerDir.y > 0)
        {
            dir = PlayerMoveDir.UpLeft;
        }
        if( playerDir.x > 0 &&playerDir.y > 0)
        {
            dir = PlayerMoveDir.UpRight;
        }
        if(playerDir.x >0&&playerDir.y < 0)
        {
            dir = PlayerMoveDir.DownRight;
        }
        if(playerDir.x == 0)
        {
            if (playerDir.y < 0)
            {
                dir = PlayerMoveDir.Down;
            }
            if(playerDir.y > 0)
            {
                dir = PlayerMoveDir.Up;
            }
        }
        if(playerDir.y == 0)
        {
            if (playerDir.x < 0)
            {
                dir = PlayerMoveDir.Left;
            }
            if (playerDir.x > 0)
            {
                dir = PlayerMoveDir.Right;
            }
        }
    }
    void TakeFire()
    {
        if (Input.GetMouseButton(0)&&Time.time - LastTime>shotInterval)
        {
            if (biuNum > 0)
            {
                GameObject biu = Instantiate(biufab, transform.position, Quaternion.identity);
                
                audioSource.Play();
                LastTime = Time.time;
                biuNum--;
            }if (biuNum == 0&&gun.GetComponent<gun>().IsReloading!=1)
            {
                float nowtime = Time.time;
                gun.GetComponent<gun>().ReLoading();
            }
        }
      
    }
    public bool isShooting;
    void skill()
    {
        if (Input.GetMouseButtonDown(1)&&biuNum ==8&& gun.GetComponent<gun>().IsReloading != 1)
        {
            isShooting = true;
            InvokeRepeating("SpawnBullet", 0f, 0.1f);
            Invoke("StopShooting", 0.8f);
            biuNum = 0;
        }
    }
    void SpawnBullet()
    {
        audioSource.Play();
        GameObject bullet = Instantiate(biufab, transform.position, Quaternion.identity);
    }

    void StopShooting()
    {
        isShooting = false;
        CancelInvoke("SpawnBullet");
    }

    public int experience = 0;

    public void AddExperience(int amount)
    {
        experience += amount;
        // 可以在这里添加经验增加后的处理逻辑，比如升级判断等。
    }
    public void SpeedUp()
    {
        playerSpeed += 1f;
        IsGaming = 1;
        Time.timeScale = 1.0f;
        Cursor.visible = false;

    }
    public void shutSpeedUp()
    {
        if(shotInterval >0.1)
        { 
        shotInterval *=0.85f;
        IsGaming = 1;
        Time.timeScale = 1.0f;
         Cursor.visible = false;

        }
    }
    
    private bool canDetect = true;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")&&canDetect){
            PlayerManager1.GetComponent<Heart>().heart--;
            canDetect = false;
        Invoke("ResetDetection", 1f);
        }
    }
    
    private void ResetDetection()
    {
         canDetect = true;
    }
}



