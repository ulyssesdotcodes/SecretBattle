using UnityEngine;

public class OnDeathDestroy : MonoBehaviour
{
  public string HealthReferenceTag = "health";
  private FloatReference healthReference;
  public void Start()
  {
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
      BaseAgent baseAgent = GetComponent<BaseAgent>();
      if (baseAgent != null)
      {
        baseAgent.EndEpisode();
        GameObject.Destroy(gameObject, Time.fixedDeltaTime);
      }
      else
      {
        GameObject.Destroy(gameObject);
      }
    }
  }
}