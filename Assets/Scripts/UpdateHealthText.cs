using UnityEngine;
using TMPro;

public class UpdateHealthText : MonoBehaviour
{
  public TextMeshProUGUI text;
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

  public void Update()
  {
    text.text = health.Value.ToString();
  }
}