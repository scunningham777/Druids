using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    public float expandDuration = 0.5f;
    public float expandValue = 100f;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Expand()
    {
        StartCoroutine(AdjustWidth(rectTransform, expandValue, expandDuration));
    }

    public IEnumerator AdjustWidth(
        RectTransform rt, 
        float adjustmentValue, 
        float duration)
    {
        float elapsedTime = 0;
        float startValue = rt.rect.width;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newWidth = Mathf.Lerp(startValue, startValue + adjustmentValue, elapsedTime / duration);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
            yield return null;
        }
    }
}
