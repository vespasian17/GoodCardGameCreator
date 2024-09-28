using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventFlags
{
    private Dictionary<EventType, bool> _eventFlags = new(100);
    public Dictionary<EventType, bool> EventFlags => _eventFlags;
    
    public event Action OnEventHappens;

    public void FillEventsDictionary()
    {
        if (_eventFlags is null)
        {
            Debug.Log("StoryFlags is null");
            return;
        }
        
        foreach (EventType flags in Enum.GetValues(typeof(EventType)))
        {
            _eventFlags.Add(flags, false);
        }
    }

    public void EnableEvent(EventType eventType)
    {
        if (_eventFlags is not null)
            _eventFlags[eventType] = true;
        OnEventHappens?.Invoke();
    }
    
    public void DisableEvent(EventType eventType)
    {
        if (_eventFlags is not null)
            _eventFlags[eventType] = false;
    }

    public void DisableAllEvents()
    {
        if (_eventFlags is not null)
        {
            foreach (EventType flags in Enum.GetValues(typeof(EventType)))
            {
                _eventFlags[flags] = false;
            }
        }
        else Debug.Log("_storyFlags is null");
    }

    public bool CheckTrueCondition(EventType eventType)
    {
        return _eventFlags[eventType];
    }
}
