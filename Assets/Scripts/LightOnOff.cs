using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
  Light light;
  public float Added = 0;
  private float intensity;
  // Start is called before the first frame update
  void Start()
  {
    light = GetComponent<Light>();
    intensity = light.intensity;
  }

  // Update is called once per frame
  void Update()
  {
    light.intensity = (Mathf.Floor(Time.time + Added) % 2) * 16f;
  }
}
