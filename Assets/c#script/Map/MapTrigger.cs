using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            MapManager.Instance.currrentBlock = transform.root.gameObject.GetComponent<MapBlock>();
            MapManager.Instance.Check(transform);
            MapManager.Instance.Reuse();
        }
    }

}
