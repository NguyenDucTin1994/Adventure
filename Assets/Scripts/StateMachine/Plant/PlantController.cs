using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private Animator _ani;
    private EnemyLookingAtPlayer _enemyLookingAtPlayer;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        _ani=GetComponent<Animator>();
        _enemyLookingAtPlayer=GetComponent<EnemyLookingAtPlayer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        _ani.SetBool("isAttack",_enemyLookingAtPlayer.detectPlayer);
    }
}
