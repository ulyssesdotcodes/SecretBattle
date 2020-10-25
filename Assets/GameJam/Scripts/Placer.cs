using UnityEngine;

public class Placer : MonoBehaviour
{
  public GameObject Agent;
  public Vector3 StartArea;
  public Vector3 EndArea;
  public Vector3 Rotation;
  private FloatReference energy;
  public void Start()
  {
    foreach (FloatReference r in GetComponents<FloatReference>())
    {
      if (r.ReferenceTag == "health")
      {
        energy = r;
      }
    }
  }

  public void FixedUpdate()
  {
    if (Random.value < Time.fixedDeltaTime * 0.2f && energy.Value > 0f)
    {
      energy.Set(energy.Value - 1);
      Vector3 AdjustedStartArea = StartArea + transform.position;
      Vector3 AdjustedEndArea = EndArea + transform.position;
      Vector3 pos = new Vector3(Random.Range(AdjustedStartArea.x, AdjustedEndArea.x), transform.parent.position.y + 0.5f, Random.Range(AdjustedStartArea.z, AdjustedEndArea.z));
      Quaternion rot = Quaternion.Euler(Rotation.x, Rotation.y, Rotation.z);
      GameObject.Instantiate(Agent, pos, rot, transform.parent);
    }
  }
}