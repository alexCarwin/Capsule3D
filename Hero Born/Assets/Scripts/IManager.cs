using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager{
    string State{get; set;}
    void Initialize();
}

public abstract class BaseManager
{
    protected string _state;
    public abstract string State { get; set; }
    public abstract void Initialize();
}
//пример реализации абстрактного класса
public class Combatmanager: BaseManager {
    public override string State {
        get { return _state;}
        set { _state = value;}
    }
    public override void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);
    }
}