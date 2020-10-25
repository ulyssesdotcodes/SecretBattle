using UnityEngine;
using Unity.MLAgents;

public class OnDeathReset : MonoBehaviour
{
  public string HealthReferenceTag = "health";
  private FloatReference healthReference;
  private PersonalityQuarksArea area;
  public void Start()
  {
    area = GetComponentInParent<PersonalityQuarksArea>();
    foreach (FloatReference reference in GetComponents<FloatReference>())
    {
      if (reference.ReferenceTag == HealthReferenceTag)
      {
        healthReference = reference;
      }
    }
  }

  public void FixedUpdate()
  {
    if (healthReference <= 0)
    {
      area.ResetAgents();
      area.ResetArea();
    }
  }
}