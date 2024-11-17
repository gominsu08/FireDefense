using UnityEngine;

public class AgentMovement : MonoBehaviour, IAgentComponent
{
    private Agent _agnet;
    private Vector2 _velocity;
    public void SetVelocity(Vector2 velocity)
    {
        _velocity = velocity;

        FlipCheck();
    }
    private void FlipCheck()
    {
        bool isFlipToLeft = _velocity.x > 0 && _agnet.IsFacingRight == false;
        bool isFlipRight = _velocity.x < 0 && _agnet.IsFacingRight;

        if (isFlipRight || isFlipToLeft)
        {
            _agnet.Flip();
        }
    }
    private void FixedUpdate()
    {
        _agnet.RbCompo.velocity = _velocity;
    }

    public void Initialize(Agent agent)
    {
        _agnet = agent;
    }
}
