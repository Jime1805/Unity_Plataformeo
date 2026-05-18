using System;
using UnityEngine;
[DefaultExecutionOrder(-1000)]

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static Action OnAddPoints;
    public float Amount{get {return _instance._amount;}}
    [SerializeField] private float _amount;
    public static CoinManager Instance
    {
        get {return _instance;}
    }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public static void AddAmount(float amount)
    {
        if(_instance != null)
        {
            Instance.AddAmountInternal(amount);
            OnAddPoints?.Invoke();
        }
    }
    private void AddAmountInternal(float amount)
    {
        _amount += amount;
    }
}
