using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaveUp : MonoBehaviour
{

    public Button targetButton;
    public Button targetButton2;
    private bool showCondition = false;

    private void Update()
    {
        // 根据特定条件更新显示状态
        if (SomeSpecificConditionMet())
        {
            showCondition = true;
        }
        else
        {
            showCondition = false;
        }

        targetButton.gameObject.SetActive(showCondition);
       
        targetButton2.gameObject.SetActive(showCondition);
    }

    private bool SomeSpecificConditionMet()
    {
       if (Time.timeScale == 0) return true;
       return false;
    }

}
