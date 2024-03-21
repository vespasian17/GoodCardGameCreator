using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using Color = UnityEngine.Color;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float _distanceForSwipeCommit = 400;
    [SerializeField] private Color _swipeReadyColor = Color.grey;
    private Vector3 _initialPosition;
    private bool? _swipeLeft;
    private float _distanceMoved;
    private bool _isDragged = false;
    private bool _isColorChanged = false;
    private Color _defaultColor;

    
    public delegate void CardMovedToLeftHandler(bool? isLeft);
    public event CardMovedToLeftHandler CardMoved;

    private void Awake()
    {
        _defaultColor = GetComponent<SpriteRenderer>().color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if (transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30,
                (_initialPosition.x + transform.localPosition.x)/(Screen.width/2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30,
                (_initialPosition.x - transform.localPosition.x)/(Screen.width/2)));
        }
        
        if (Mathf.Abs(transform.localPosition.x) > _distanceForSwipeCommit)
        {
            if (!_isColorChanged)
            {
                transform.GetComponent<SpriteRenderer>().color = _swipeReadyColor;
                _isColorChanged = true;
                Debug.Log("color change to new");
            }
        }
        else if (_isColorChanged)
        {
            Debug.Log("color change to default");
            _isColorChanged = false;
            transform.GetComponent<SpriteRenderer>().color = _defaultColor;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Utils.GetCurrentScreenWidth();
        _initialPosition = transform.localPosition;
        _isDragged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        if (_distanceMoved < _distanceForSwipeCommit)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
            }
            else
            {
                _swipeLeft = true;
            }
            _isDragged = false;
            CardMoved?.Invoke(_swipeLeft);
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while (_isDragged)
        {
            time += Time.deltaTime;
            if (_swipeLeft == true)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x - Screen.width, 4* time), transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x + Screen.width, 4* time), transform.localPosition.y, 0);
            }
            yield return null;
        }
        Debug.Log("Destoy this card");
        Destroy(gameObject);
    }
}
