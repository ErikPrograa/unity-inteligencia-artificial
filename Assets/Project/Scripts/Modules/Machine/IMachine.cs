using System.Collections;
using UnityEngine;

public interface IMachine
{
    public void SetState(IState state);
    public void Update(float deltaTime);
}