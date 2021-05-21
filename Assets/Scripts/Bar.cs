using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    private float _maxWidth;

    private void Start() {
        _maxWidth = _rectTransform.rect.width;
        Debug.Log("width = " + _maxWidth);
    }

    public void UpdateValue(float value)
    {
        Debug.Log("value = " + value);
        Debug.Log("width = " + _maxWidth);
        // _value.rectTransform.sizeDelta = new Vector2(value * _maxWidth, _value.sprite.rect.height);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,  value * _maxWidth);
    }
}
