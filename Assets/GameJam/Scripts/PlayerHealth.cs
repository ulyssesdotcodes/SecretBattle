using UnityEngine;
using System.Collections;

public class PlayerHealth : AreaResetComponent
{
  public float MaxHealth = 10f;
  private FloatReference healthReference;
  private PersonalityQuarksArea area;
  private bool Started = false;
  public void Start()
  {
    if (!Started)
    {
      Started = true;
      area = GetComponentInParent<PersonalityQuarksArea>();
      foreach (FloatReference reference in GetComponents<FloatReference>())
      {
        if (reference.ReferenceTag == "health")
        {
          healthReference = reference;
          healthReference.Set(MaxHealth);
        }
      }
    }
  }

  public void TakeDamage(float amount)
  {
    healthReference.Set(healthReference - amount);
    if (healthReference.Value <= 0)
    {
      StartCoroutine(HandleDead());
    }
  }

  public IEnumerator HandleDead()
  {
    // Have to wait for action to register reward
    yield return new WaitForFixedUpdate();
    yield return new WaitForFixedUpdate();
    yield return new WaitForFixedUpdate();
    yield return new WaitForFixedUpdate();
    yield return new WaitForFixedUpdate();
    yield return new WaitForFixedUpdate();
    area.ResetAgents();
    area.ResetArea();
  }

  public override void Reset()
  {
    healthReference.Set(MaxHealth);
  }
}