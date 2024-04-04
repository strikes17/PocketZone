using PocketZone.Game;

namespace PocketZone.Gui
{
    public class ShootButton : AbstractButton
    {
        protected AbstractShootBehaviour shootBehaviour = default;

        protected override void OnButtonClicked()
        {
            shootBehaviour.TryMakeShot();
        }

        public void Construct(AbstractShootBehaviour shooter)
        {
            shootBehaviour = shooter;
        }
    }
}
