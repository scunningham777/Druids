using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimmer : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float fadeValue = 0.6f;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeIn()
    {
        StartCoroutine(SpriteFade(spriteRenderer, fadeValue, fadeDuration));
    }

    public IEnumerator SpriteFade(
        SpriteRenderer sr, 
        float endValue, 
        float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
}
