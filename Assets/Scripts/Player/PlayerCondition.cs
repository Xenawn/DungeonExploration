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
        CharacterManager.Instance.Player.controller.moveSpeed *= 3; // �ӷ��� 3��� ������
    }

   

    public void Die()
    {
        Debug.Log("Die");
    }
}
