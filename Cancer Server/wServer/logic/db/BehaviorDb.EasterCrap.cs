using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ EasterCrap = () => Behav()
            .Init("EasterEgg Chest",
                new State(
                    new State("None",
                        new Taunt("I have special treats! Break me!")
                        )
                        
                    ),
                new GoldLoot(100, 200),
                new MostDamagers(10,
                    new ItemLoot("Bunny Skin Armor", 0.01),
                    new ItemLoot("Greater Potion of Vitality", 1.0),
                    new ItemLoot("Candy of Vitality", 0.012)
                ),
                new MostDamagers(10,
                    new ItemLoot("Harden Bunny Armor", 0.01),
                    new ItemLoot("Greater Potion of Defense", 1.0),
                    new ItemLoot("Candy of Defense", 0.012)
                ),
                new MostDamagers(10,
                    new ItemLoot("Soft Bunny Pajamas", 0.01),
                    new ItemLoot("Greater Potion of Dexterity", 1.0),
                    new ItemLoot("Candy of Dexterity", 0.012)
                )
            )
        

            ;
    }
}