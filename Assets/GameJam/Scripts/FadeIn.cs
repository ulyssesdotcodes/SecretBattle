using UnityEngine;
using System.Collections;
public class FadeIn : MonoBehaviour
{
  public SkinnedMeshRenderer AnimatedGO;
  public float FadeTime = 4f;
  private Material animatedMaterial;
  private float Visibility = 1;
  private MaterialPropertyBlock materialPropertyBlock;
  private GameObject bluePlayer;
  private bool FadeOutActive;

  public void Start()
  {
    animatedMaterial = AnimatedGO.materials[0];
    FadeOutMaterial();
    materialPropertyBlock = new MaterialPropertyBlock();
    bluePlayer = GameObject.FindGameObjectWithTag("blueplayer");
  }

  public void FadeInMaterial()
  {
    StartCoroutine(StartFadeIn());

  }
  public void FadeOutMaterial()
  {
    StartCoroutine(StartFadeOut());
  }

  public void Update()
  {
    AnimatedGO.GetPropertyBlock(materialPropertyBlock);
    materialPropertyBlock.SetFloat("_Visible", Visibility);
    AnimatedGO.SetPropertyBlock(materialPropertyBlock);

    if ((bluePlayer.transform.position - transform.position).sqrMagnitude < 2 && Visibility < 1)
    {
      FadeInMaterial();
    }
    else if ((bluePlayer.transform.position - transform.position).sqrMagnitude > 2 && Visibility > 0)
    {
      FadeOutMaterial();
    }
  }

  public IEnumerator StartFadeIn()
  {
    int i = 0;
    while (i < 300 && Visibility < 1)
    {
      i++;
      Visibility += Time.deltaTime * (1 / FadeTime);
      yield return new WaitForFixedUpdate();
    }
  }

  public IEnumerator StartFadeOut()
  {
    if (!FadeOutActive)
    {
      FadeOutActive = true;
      int i = 0;
      while (i < 300 && Visibility > 0)
      {
        i++;
        Visibility -= Time.deltaTime * (1 / FadeTime);
        yield return null;
      }
      FadeOutActive = false;
    }
  }
}