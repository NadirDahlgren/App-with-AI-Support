namespace App_med_AI_stöd
{

    internal class Character
    {
        // Private properties used for character attributes. 
        private string Name { get; set; }
        private int Strength { get; set; }
        private int Stamina { get; set; }
        private int Health { get; set; }
        private int ResourceAmount { get; set; }
        private CharacterClass Class { get; set; }
        private SpecialAbility Ability { get; set; }
        private ResourceType Resource { get; set; }

        public Character(string name) // Constructor for creating a new character. 
        {
            Name = name;
            Class = GenerateClass(); // Randomly selects a class based on the generated number.
            Ability = GenerateAbility(Class); // Randomly selects one of three abilities based on the character class.

            switch (Class) // This segment was influenced by ChatGPT. I had help with setting the fixed amounts on a Class. I learned that switch can also use enum values, not just integers!
            {
                 case CharacterClass.Warrior:
                    Strength = 90;
                    Stamina = 100;
                    Health = 150;
                    Resource = ResourceType.Rage;
                    ResourceAmount = 0;
                    break;

                 case CharacterClass.Mage:
                    Strength = 25;
                    Stamina = 65;
                    Health = 45;
                    Resource = ResourceType.Mana;
                    ResourceAmount = 100;
                    break;

                 case CharacterClass.Rogue:
                    Strength = 55;
                    Stamina = 85;
                    Health = 90;
                    Resource = ResourceType.Energy;
                    ResourceAmount = 100;
                    break;
            }
        }

        public void DisplayCharacter() // Print character info. 
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Class: {Class}\n" +
                $"Strength: {Strength}\n" +
                $"Stamina: {Stamina}\n" +
                $"Health: {Health}\n" +
                $"Resource: {Resource} ({ResourceAmount}/100)\n" +
                $"Ability: {Ability}\n");
        }
        private SpecialAbility GenerateAbility(CharacterClass characterClass) // This method was influenced by ChatGPT. I had help with structuring the random selection of abilities. 
        {
            switch (characterClass) // Randomly selects one of three abilities based on the character class.
            {
                case CharacterClass.Warrior:
                    SpecialAbility[] warriorAbilities =
                    {
                    SpecialAbility.Taunt,
                    SpecialAbility.Charge,
                    SpecialAbility.Slam
                    };
                    return warriorAbilities[Random.Shared.Next(warriorAbilities.Length)];

                case CharacterClass.Mage:
                    SpecialAbility[] mageAbilities =
                    {
                    SpecialAbility.Frostbolt,
                    SpecialAbility.LightningStrike,
                    SpecialAbility.Meteor
                    };
                    return mageAbilities[Random.Shared.Next(mageAbilities.Length)];

                case CharacterClass.Rogue: 
                    SpecialAbility[] rogueAbilities =
                    {
                    SpecialAbility.Backstab,
                    SpecialAbility.PickPocket,
                    SpecialAbility.VenomStrike
                    };
                    return rogueAbilities[Random.Shared.Next(rogueAbilities.Length)];
            }
            throw new ArgumentOutOfRangeException(nameof(characterClass)); // ChatGPT suggested this exception to handle invalid character classes and ensure all code paths are covered.
        }
        private CharacterClass GenerateClass() // Generates a random class for the character. 
        {
            int randomNumber = Random.Shared.Next(0, 3);

            if (randomNumber == 0)
            {
                return CharacterClass.Warrior;
            }
            else if (randomNumber == 1)
            {
                return CharacterClass.Mage;
            }
            else
            {
                return CharacterClass.Rogue;
            }
        }

    }

    // I chose enums to define a fixed set of options
    // instead of using strings.
    public enum CharacterClass  
    {
        Warrior,
        Mage,
        Rogue,
    }
    public enum SpecialAbility  
    {
        Taunt,
        Charge,
        Slam,

        Frostbolt,
        LightningStrike,
        Meteor,

        Backstab,
        PickPocket,
        VenomStrike
    }
    public enum ResourceType 
    {
        Rage,
        Mana,
        Energy,
    }
}
