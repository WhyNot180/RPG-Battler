namespace RPG_Battler
{
    public abstract class PlayerType
    {
        public Stats BaseStats {  get; set; }

        public AnimatedSprite IdleAnimation {  get; protected set; }
        public AnimatedSprite AttackAnimation { get; protected set; }
        public AnimatedSprite HurtAnimation { get; protected set; }
        public AnimatedSprite DeathAnimation { get; protected set; }


    }
}
