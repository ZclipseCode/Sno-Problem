using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintEvent : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image panel;
    [SerializeField] RectTransform eventTransform;
    [SerializeField] BlueprintEvent previousEvent;
    bool activated;

    private void Start()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag(targetTag))
        {
            if (previousEvent != null && !previousEvent.GetActivated())
            {
                previousEvent.Activate();
            }

            Activate();
        }
    }

    public void Activate()
    {
        activated = true;
        StartCoroutine(Slide());
        StartCoroutine(Display());
    }

    IEnumerator Slide()
    {
        float change = 50f;
        Vector3 endPosition = eventTransform.position;
        Vector3 startPosition = endPosition + new Vector3(0f, change);

        eventTransform.position = startPosition;

        float increment = 5f;
        while (eventTransform.position.y > endPosition.y)
        {
            eventTransform.position = Vector3.Lerp(eventTransform.position, endPosition, increment * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator Display()
    {
        float increment = 2f;

        while (text.color.a < 1f)
        {
            text.color += new Color(0f, 0f, 0f, increment * Time.deltaTime);
            
            if (panel.color.a < 0.38f)
            {
                panel.color += new Color(0f, 0f, 0f, increment * Time.deltaTime);
            }

            yield return new WaitForSeconds(0.001f);
        }
    }

    public bool GetActivated() => activated;
}
