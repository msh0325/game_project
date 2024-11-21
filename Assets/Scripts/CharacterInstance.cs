public class CharacterInstance
{
    public string name;
    public int HP;
    public int defense;
    public int attack;
    public int speed;

    public CharacterInstance(CharacterStats stats){
        name = stats.characterName;
        HP = stats.HP;
        defense = stats.defense;
        attack = stats.attack;
        speed = stats.speed;
    }
}
