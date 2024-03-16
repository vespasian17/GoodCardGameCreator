using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    private bool _swipeLeft;
    private float _distanceMoved;
    private bool _isDragged = false;
    
    private GameManager gameManager;
    
    public delegate void CardMovedToLeftHandler(bool isLeft);
    public event CardMovedToLeftHandler CardMoved;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        gameManager.CurrentCardSwipe = this;
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
        if (_distanceMoved < 0.4f * Screen.width)
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
            if (_swipeLeft)
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
