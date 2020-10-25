using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public PlayerPlacer Player;
  public BaseAgent AI;
  // Start is called before the first frame update
  void Start()
  {
    AI.enabled = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartGame()
  {
    Player.StartGame();
    AI.enabled = true;
  }
}
