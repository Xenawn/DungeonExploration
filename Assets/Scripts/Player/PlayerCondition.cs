using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition  uiCondition;
    Condition health { get { return uiCondition.health; } }
  //  Condition hunger { get { return uiCondition.hunger  ; } } 
    Condition stamina { get { return uiCondition.stamina; } }

    // Update is called once per frame
    void Update()
    {
        health.Add(health.passiveValue *Time.deltaTime);
        stamina.Add(stamina.passiveValue *Time.deltaTime);

        if(health.curValue == 0f)
        {
            Die();
        }
        
    }
    public void HealStamina(float amount)
    {
        stamina.Add(amount);
        StartCoroutine(SpeedUp()); // 코루틴 실행
    }

    IEnumerator SpeedUp()
    {
        yield return CharacterManager.Instance.Player.controller.moveSpeed *= 3; // 속력이 3배로 빨라짐
    }

    public void Die()
    {
        Debug.Log("Die");
    }
}
