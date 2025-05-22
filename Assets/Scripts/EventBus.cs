using System;
using System.Collections.Generic;

public static class EventBus
{
    // Ÿ�� ��� �̺�Ʈ ����
    private static Dictionary<Type, Delegate> typedEventTable = new();

    // ���ڿ� ��� �̺�Ʈ ����
    private static Dictionary<string, Action<object>> stringEventTable = new();
    
    // Ÿ�� ��� ����
    public static void Subscribe<T>(Action<T> callback)
    {
        if (typedEventTable.TryGetValue(typeof(T), out var del))
            typedEventTable[typeof(T)] = Delegate.Combine(del, callback);
        else
            typedEventTable[typeof(T)] = callback;
    }

    // Ÿ�� ��� ���� ����
    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (typedEventTable.TryGetValue(typeof(T), out var del))
        {
            var currentDel = Delegate.Remove(del, callback);
            if (currentDel == null)
                typedEventTable.Remove(typeof(T));
            else
                typedEventTable[typeof(T)] = currentDel;
        }
    }

    // Ÿ�� ��� ����
    public static void Publish<T>(T evt)
    {
        if (typedEventTable.TryGetValue(typeof(T), out var del))
        {
            var callback = del as Action<T>;
            callback?.Invoke(evt);
        }
    }

    // ���ڿ� ��� ����
    public static void Subscribe(string eventName, Action<object> callback)
    {
        if (stringEventTable.TryGetValue(eventName, out var existing))
            stringEventTable[eventName] = existing + callback;
        else
            stringEventTable[eventName] = callback;
    }

    // ���ڿ� ��� ���� ����
    public static void Unsubscribe(string eventName, Action<object> callback)
    {
        if (stringEventTable.TryGetValue(eventName, out var existing))
        {
            existing -= callback;
            if (existing == null)
                stringEventTable.Remove(eventName);
            else
                stringEventTable[eventName] = existing;
        }
    }

    // ���ڿ� ��� ����
    public static void Publish(string eventName, object param = null)
    {
        if (stringEventTable.TryGetValue(eventName, out var callback))
        {
            callback?.Invoke(param);
        }
    }

    //��� ���� ���� �ʱ�ȭ
    public static void Clear()
    {
        typedEventTable = new();
        stringEventTable = new();
    }
}