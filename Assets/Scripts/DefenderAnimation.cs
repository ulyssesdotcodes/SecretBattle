using UnityEngine;

public class DefenderAnimation : MonoBehaviour
{
  public BoolReference attacking;
  public FloatReference health;
  public Animator animator;
  private Rigidbody rb;

  public void Start()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();

    foreach (BoolReference reference in GetComponents<BoolReference>())
    {
      if (reference.ReferenceTag == "attacking")
      {
        attacking = reference;
      }
    }

    foreach (FloatReference reference in GetComponents<FloatReference>())
    {
      if (reference.ReferenceTag == "health")
      {
        health = reference;
      }
    }

  }

  public void Update()
  {
    animator.SetBool("attacking", attacking.Value);
    animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

    if (health <= 0)
    {
      animator.SetBool("dead", true);
      GetComponent<BaseAgent>().enabled = false;
    }
  }

  public void TakeDamage()
  {
    animator.SetTrigger("hit");
  }
}