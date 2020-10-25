using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class PlayerPlacer : MonoBehaviour
{
  public GameObject Agent;
  public Vector3 StartArea;
  public Vector3 EndArea;
  public Vector3 Rotation;
  private Vector3 TransformedStartArea;
  private Vector3 TransformedEndArea;
  private bool GameStarted = false;
  private FloatReference health;

  public void Start()
  {
    foreach (FloatReference reference in GetComponents<FloatReference>())
    {
      if (reference.ReferenceTag == "health")
      {
        health = reference;
      }
    }
  }

  public void StartGame()
  {
    GameStarted = true;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0) && GameStarted && health.Value > 0)
    {
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (
          Physics.Raycast(ray, out hit, 100f) &&
          hit.collider.tag == "ground" &&
          hit.point.z < 0
        )
      {
        health.Set(health - 1);

        GameObject.Instantiate(Agent, hit.point + Vector3.up * 0.5f, transform.rotation, transform.parent);
      }
    }
  }
}
