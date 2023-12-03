using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_State : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        // Player found
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPos = enemy.Player.transform.position;
        }
        // Player lost
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > enemy.waitForSearch)
            {
                // Finish Attack and go to Search
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        // Store reference to GunBarrel
        Transform gunbarrel = enemy.gunBarrel;

        // Instantiate bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);

        // Calculate direction to player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;

        // Add force rigitbody of the bullet
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * enemy.bulletSpeed;

        shotTimer = 2;
    }
}
