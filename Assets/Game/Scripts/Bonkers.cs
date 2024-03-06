using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;

public class Bonkers : MonoBehaviour
{
    Dimmer dimmer;
    Expander expander;
    // Start is called before the first frame update
    void Start()
    {
        dimmer = GameObject.Find("Dimmer").GetComponent<Dimmer>();
        expander = FindObjectOfType<Expander>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            GetComponent<SortingGroup>().sortingLayerName = "Above";
            var other = collision.gameObject.GetComponent<SpriteRenderer>();
            other.sortingLayerName = "Above";
            GetComponent<CharacterPause>().PauseCharacter();
            dimmer.FadeIn();
            expander.Expand();
        }
    }
}
