using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField] private int _exp;
    [SerializeField] private int _gold;
    
    public int Exp { get { return _exp; } set { _exp = value; }}
    public int Gold { get { return _gold; } set { _gold = value; }}
    void Start()
    {
        _level = 1;
        _hp = 200;
        _maxHp = 200;
        _attack = 25;
        _defence = 5;
        _moveSpeed = 5.0f;
        _exp = 0;
        _gold = 0;
    }

    void Update()
    {
        
    }

    protected override void OnDead(Stat attacker)
    {
        Debug.Log("P_Dead");
    }
}
