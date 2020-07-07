using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    GameObject projectileParent;
    const String PROJECTILE_PARENT_NAME = "Projectiles";

    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParents();
    }

    private void CreateProjectileParents()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            print("Shoot");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            print("wait");
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newPRojectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newPRojectile.transform.parent = projectileParent.transform;
    }
}
