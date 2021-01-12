public interface IPlayerState
{
    void ReceiveDamage(AbstractPlayer player, int damageValue);
    void Heal(AbstractPlayer player, int healValue);
    void SetVisibleDamage(AbstractPlayer player);
}
