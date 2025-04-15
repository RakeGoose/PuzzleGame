using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{

    public float attackRadius = 0.5f;
    public LayerMask breakableLayer;

    private Animator anim;
    private bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        anim.SetTrigger("HammerAttack");

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, breakableLayer);
        foreach (Collider2D col in hits)
        {
            BreakablePlatforms bp = col.GetComponent<BreakablePlatforms>();
            if (bp != null)
            {
                bp.Break();
            }
        }

        

        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
