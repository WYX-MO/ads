using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int experienceToDrop = 20;
    public GameObject expPrefab;
    public float hp;
    
    public void RealDie()
    {
        if (hp<=0) {
            
            GameObject expOrb = Instantiate(expPrefab, transform.position, Quaternion.identity);
        expOrb.GetComponent<ExperienceOrb>().SetExperienceValue(experienceToDrop);
            moveSpeed = 0;
            StartCoroutine(WaitAndDoSomething());
            Destroy(gameObject); }
    }
    private System.Collections.IEnumerator WaitAndDoSomething()
    {
        // 等待一秒
        yield return new WaitForSeconds(1f);
        
    }
    public void Die()
    {
        hp-=20;
        Invoke("ContinueAfterOneSecond", 0.2f);
        moveSpeed = -1;
    }
    void ContinueAfterOneSecond()
    {
        moveSpeed = 3f;
        Debug.Log("Waited one second using Invoke and continued.");
    }
    public GameObject player;
    public float moveSpeed = 3f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        walk();
        hp = 80;
          
    }

    // Update is called once per frame
    void Update()
    {
       walk();
        RealDie();
    }


    private void walk()
    {
        if (player != null)
        {
            // 计算怪物到主角的方向
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // 移动怪物
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
 
}
