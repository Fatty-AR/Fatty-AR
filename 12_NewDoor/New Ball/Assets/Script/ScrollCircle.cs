using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollCircle : ScrollRect {
    float radius = 0;
    public Vector2 distance;
	// Use this for initialization
	void Start () {
        distance = new Vector2();
        radius = (transform as RectTransform).sizeDelta.x * 0.45f;
	}

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        Vector2 pos = content.anchoredPosition;
        if (pos.magnitude > radius)
        {
            pos = pos.normalized * radius;
            SetContentAnchoredPosition(pos);
        }
    }

    // Update is called once per frame
    void Update () {
        distance = this.content.localPosition / radius;
        //Debug.Log(distance);
	}
}
