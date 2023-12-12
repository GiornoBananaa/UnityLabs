namespace Core
{
    public class ShootAttackState : AState
    {
        public override void Enter()
        {
            _owner.ChangeState<ShootAttackState>();
        }
    }
}
