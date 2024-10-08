using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class excTiao : MonoBehaviour
{
    public GameObject player;
    
    PlayerInput playersc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playersc = player.GetComponent<PlayerInput>();
        if (player != null)
        {
            Follow();
            NeedReset();
        }
    }
    public void Follow()
    {
transform.position = player.transform.position + new Vector3((playersc.experience/10-56),12.2f,0);
            //¸úËæ
    }
    public void NeedReset()
    {
        if (playersc.experience >= 360)
        {
            playersc.experience = 40;
          
            Time.timeScale = 0.0f;
            Cursor.visible = true;
        }
      }
}
