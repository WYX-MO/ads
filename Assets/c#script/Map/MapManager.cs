using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapManager : MonoBehaviour
{
    private static MapManager instance;
    public static MapManager Instance {  get { return instance; } }

    public GameObject mapblockfab;
    public List<GameObject> maps = new List<GameObject>();
    public Vector3 BlockOffest = new Vector3(18, 18, 0);
    public MapBlock currrentBlock;
    public List<GameObject>hadCreatedMap = new List<GameObject> ();
    public GameObject player;
    public float DelDistance = 48f;
    private void Awake()
    {
        BlockOffest = new Vector3(18, 18, 0);
        DelDistance = 48f;
        instance = this;
        CreateMapBlock();
    }
    //创建地图块做准备
    void CreateMapBlock()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject map = GameObject.Instantiate(mapblockfab);
            map.transform.parent = this.transform;
            //隐藏
            map.SetActive(false);
            maps.Add(map);
        }
    }
    public bool CheckNeedCreateMap(Vector3 target, float radius = 1.5f)
    {
        if (Physics2D.OverlapCircle(target, radius, LayerMask.GetMask("Map")))
        {
            return false;
        }
        return true;
    }
    public void GetTargetBlockFramDir(Vector3 tiggerPos,PlayerMoveDir dir,Vector3 offest)
    {
        Vector3 targetPos = Vector3.zero;
        switch (dir)
        {
            case PlayerMoveDir.Up:
                targetPos = tiggerPos + new Vector3(0,offest.y,0);
                if(CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.Down:
                targetPos = tiggerPos + new Vector3(0, -offest.y, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.Left:
                targetPos = tiggerPos + new Vector3(-offest.x, 0, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.Right:
                targetPos = tiggerPos + new Vector3(offest.x, 0, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.UpLeft:
                targetPos = tiggerPos + new Vector3(-offest.x, offest.y, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.UpRight:
                targetPos = tiggerPos + new Vector3(offest.x, offest.y, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.DownLeft:
                targetPos = tiggerPos + new Vector3(-offest.x, -offest.y, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
            case PlayerMoveDir.DownRight:
                targetPos = tiggerPos + new Vector3(offest.x, -offest.y, 0);
                if (CheckNeedCreateMap(targetPos) == true)
                {
                    SetMapBlockPosition(dir, BlockOffest);
                }
                break;
        }
    }
    public GameObject TryGetBlock()
    {
        GameObject go = null;
        if(maps.Count > 0)
        {
            go = maps.Find(a => !a.activeInHierarchy);
            go.SetActive(true);
            go.transform.parent = null;

            maps.Remove(go);
            return go;
        }
        Debug.Log("kon");
        return null;
    }
    public void SetMapBlockPosition(PlayerMoveDir dir, Vector3 offest)
    {
    Vector3 nowOffest = Vector3.zero;
        switch (dir)
        {
            case PlayerMoveDir.Up:
                nowOffest = new Vector3 (0,offest.y,0); break;
            case PlayerMoveDir.Down:
                nowOffest = new Vector3(0,-offest.y,0); break;
            case PlayerMoveDir.Left:
                nowOffest = new Vector3(-offest.x, 0, 0); break;
            case PlayerMoveDir.Right:
                nowOffest = new Vector3(offest.x, 0, 0); break;

            case PlayerMoveDir.UpLeft:
                nowOffest = new Vector3(-offest.x, offest.y, 0); break;
            case PlayerMoveDir.UpRight:
                nowOffest = new Vector3(offest.x, offest.y, 0); break;
            case PlayerMoveDir.DownLeft:
                nowOffest = new Vector3(-offest.x, -offest.y, 0); break;
            case PlayerMoveDir.DownRight:
                nowOffest = new Vector3(offest.x, -offest.y, 0); break;

        }
        GameObject go = TryGetBlock();
        if (go != null)
        {
            go.transform.position = currrentBlock.transform.position + nowOffest;
            go.SetActive(true);
            hadCreatedMap.Add(go);
        }  
    }
    public void Check(Transform tf)
    {
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.Down, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.Up, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.Right, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.Left, BlockOffest);

        GetTargetBlockFramDir(tf.position, PlayerMoveDir.UpLeft, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.DownLeft, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.UpRight, BlockOffest);
        GetTargetBlockFramDir(tf.position, PlayerMoveDir.DownRight, BlockOffest);
    }
    public void Reuse()
    {
        List<GameObject> tempList = new List<GameObject> ();
        for (int i = 0; i < hadCreatedMap.Count; i++)
        {
            if (Vector3.Distance(player.transform.position, hadCreatedMap[i].transform.position) >= DelDistance)
            {
                tempList.Add(hadCreatedMap[i]);
            }
        }
        for(int i = 0;i < tempList.Count; i++)
        {
            GameObject temp = tempList[i];
            maps.Add(temp);
            temp.SetActive(false);
            temp.transform.parent = this.transform;
            temp.transform.localPosition = Vector3.zero;
            hadCreatedMap.Remove(temp);
        }
    }
}
