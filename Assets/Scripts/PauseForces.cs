using UnityEngine;

public class PauseForces : MonoBehaviour
{
  public float Length = 1f;
  private float StartedTime;
  // Start is called before the first frame update
  void Start()
  {
    StartedTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time - StartedTime > Length)
    {
      GetComponent<Rigidbody>().isKinematic = false;
      Destroy(this);
    }
  }
}
