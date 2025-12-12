using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public List<UnitInstance> party = new List<UnitInstance>(6);
    public List<EnemyInstance> enemies = new List<EnemyInstance>();

    public int TargetEnemyIndex = 0;

    public List<bool> CanAct = new List<bool>();

    public bool PlayerTurn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //Setup UI  
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTurn && CanAct.All(value => value == false) && party.All(value => value.IsAnimatorComplete() == true)) {
            PlayerTurn = false;            
            
            //Enemy turn
            for (int i = 0;i < enemies.Count;i++){
                //todo implement enemy AI
                BasicAttack(enemies[i], party[0]);
            }
        }

        if(!PlayerTurn && enemies.All(value => value.IsAnimatorComplete() == true)){
            StartTurn();
        }

    }

    public void OnUnitButtonClick(int buttonIndex)
    {
        if (PlayerTurn && CanAct[buttonIndex])
        {
            //attack logic
            BasicAttack(party[buttonIndex], enemies[TargetEnemyIndex]);
            CanAct[buttonIndex] = false;
        }
    }

    public void StartTurn(){
        
        PlayerTurn = true;

        for (int i = 0; i < CanAct.Count; i++)
        {
            CanAct[i] = true;
        }
    }

    public void BasicAttack(Unit Attacker, Unit Defender){
        //Damage calc
        Attacker.SetAnimatorTrigger("Attack");
        Attacker.AnimationStarted();
        float damage = Mathf.Pow(Attacker.Attack.Value, 2)/Defender.Defense.Value;
        Debug.Log(Attacker.name + " hit " + Defender.name + " for " + damage);
        Defender.HP -= damage;
    }
}
