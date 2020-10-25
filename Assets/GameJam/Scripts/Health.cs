using UnityEngine;

public class Health : MonoBehaviour
{
  public string HealthReferenceTag = "health";
  private FloatReference healthReference;
  private bool Started = false;
  public void Start()
  {
    if (!Started)
    {
      Started = true;
      foreach (FloatReference reference in GetComponents<FloatReference>())
      {
        if (reference.ReferenceTag == HealthReferenceTag)
        {
          healthReference = reference;
        }
      }

    }
  }
  public void TakeDamage(float amount)
  {
    Start();
    healthReference.Start();
  }

  }