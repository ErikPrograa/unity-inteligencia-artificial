using UnityEngine;
using UnityEngine.Serialization;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform doorHinge;
    [SerializeField] private float closedAngleY;
    [SerializeField] private float openAngleY = 90f;
    [FormerlySerializedAs("openCloseDuration")]
    [SerializeField] private float openingDuration = 1f;
    [SerializeField] private float closingDuration = 1f;
    [SerializeField] private float timeClosedBeforeOpen = 2f;
    [SerializeField] private float timeOpenBeforeClose = 2f;

    private DoorMachine _machine;

    private bool _openRequested;
    private bool _closeRequested;

    public Transform DoorHinge => doorHinge;
    public float ClosedAngleY => closedAngleY;
    public float OpenAngleY => openAngleY;
    public float OpeningDuration => openingDuration;
    public float ClosingDuration => closingDuration;
    public float TimeClosedBeforeOpen => timeClosedBeforeOpen;
    public float TimeOpenBeforeClose => timeOpenBeforeClose;

    private void Awake()
    {
        var graph = new UnorderedGraph<StateObject, StateTransition>();
        _machine = new DoorMachine(graph, this);
    }

    private void Update()
    {
        _machine.Update();
    }

    public void RequestOpen()
    {
        _openRequested = true;
    }

    public void RequestClose()
    {
        _closeRequested = true;
    }

    public bool OpenRequestPending => _openRequested;
    public bool CloseRequestPending => _closeRequested;

    public void ClearOpenRequest()
    {
        _openRequested = false;
    }

    public void ClearCloseRequest()
    {
        _closeRequested = false;
    }

    public void SetDoorAngleY(float angleY)
    {
        if (doorHinge == null)
            return;

        var e = doorHinge.localEulerAngles;
        e.y = angleY;
        doorHinge.localEulerAngles = e;
    }
}
