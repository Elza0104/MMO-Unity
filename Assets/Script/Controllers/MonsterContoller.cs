using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class MonsterContoller : BaseController
{
    private Stat _stat;

    [SerializeField] private float _scanRange = 10;
    [SerializeField] private float _attackRange = 2;
    void Start()
    {
        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateIdle()
    {
        GameObject player = Managers.GM.GetPlayer();
        if (player == null)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockOnTarget = player;
            State = Define.State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_lockOnTarget != null)
        {
            _destPos = _lockOnTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                State = Define.State.Skill;
                
                return;
            }   
        }
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
            return;
        } 
        NavMeshAgent nma = gameObject.GetAddComponent<NavMeshAgent>();
        nma.SetDestination(_destPos);
        nma.speed = _stat.MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 
            10 * Time.deltaTime);
    }
    protected override void UpdateSkill()
    {
        if (_lockOnTarget != null)
        {
            Vector3 dir = _lockOnTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }

    private void OnHitEvent()
    {
        if (_lockOnTarget != null)
        {
            Stat targetStat = _lockOnTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);
            
            if (targetStat.Hp > 0)
            {
                float distance = (_lockOnTarget.transform.position - transform.position).magnitude;
                if (distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Idle;
            }
            
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
