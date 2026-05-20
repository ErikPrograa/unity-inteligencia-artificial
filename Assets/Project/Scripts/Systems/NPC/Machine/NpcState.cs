
public abstract class NpcState : IState
{
    protected NpcController _controller;

    public NpcState(NpcController controller)
    {
        _controller = controller;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate(float deltaTime);
    public abstract void OnExit();
}