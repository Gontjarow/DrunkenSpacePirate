using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Rigidbody2D projectile;

    [Tooltip("Seconds before first shot")]
    public float firstAttack;

    [Tooltip("Seconds between each shot")]
    public float nextAttack;

    [Tooltip("0 = single, 1 = fan, 2 = shotgun")]
    public int pattern;

    private enum Type { single, fan, shotgun };

    // Use this for initialization
    void Start()
    {
        if((Type)pattern == Type.single)
        {
            StartCoroutine(SingleProjectile());
        }
        else if ((Type)pattern == Type.fan)
        {
            StartCoroutine(FanProjectiles(4));
        }
        else if ((Type)pattern == Type.shotgun)
        {
            StartCoroutine(ShotgunProjectiles(4));
        }
    }

    void IncrementalArcProjectile(int pNum, float initial_angle, float angle_inc, Vector3 offset)
    {
        Quaternion localRot = Quaternion.Euler(0, 0, initial_angle + angle_inc * pNum);
        Vector3 localPos = transform.position + transform.rotation * (localRot) * offset;
        Instantiate(projectile, localPos, transform.rotation * localRot);
    }

    IEnumerator SingleProjectile()
    {
        while(true)
        {
            Vector3 localPos = transform.position + transform.rotation * (Quaternion.identity) * Vector3.up;
            Instantiate(projectile, localPos, transform.rotation * Quaternion.identity);
            yield return new WaitForSeconds(nextAttack);
        }
        yield break;
    }

    IEnumerator FanProjectiles(int projectiles)
    {
        --projectiles; // Projectile count starts from 0.
        float arc = 45;
        float initial_angle = -(arc / 2);
        float angle_inc = arc / projectiles;

        while (true)
        {
            // initial distance from parent
            Vector3 offset = Vector3.up;

            for (int i = 0; i <= projectiles; ++i)
            {
                IncrementalArcProjectile(i, initial_angle, angle_inc, offset);
                if (i != projectiles) yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(nextAttack);
        }
        yield break;
    }

    IEnumerator ShotgunProjectiles(int projectiles)
    {
        --projectiles; // Projectile count starts from 0.
        float arc = 45;
        float initial_angle = -(arc / 2);
        float angle_inc = arc / projectiles;

        while (true)
        {
            // initial distance from parent
            Vector3 offset = Vector3.up;

            for (int i = 0; i <= projectiles; ++i)
            {
                IncrementalArcProjectile(i, initial_angle, angle_inc, offset);
            }

            yield return new WaitForSeconds(nextAttack);
        }
        yield break;
    }


}
