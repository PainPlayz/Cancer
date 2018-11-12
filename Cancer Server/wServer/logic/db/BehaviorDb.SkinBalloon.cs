using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SkinBalloon = () => Behav()

            .Init("Stat Baloon",
                new State(
                    new Prioritize(
                        new Wander(0.25)
                        )
                    ),
                new Threshold(0.01,
                    new ItemLoot("Slime Knight Skin", 0.01),
                    new ItemLoot("Slime Archer Skin", 0.01),
                    new ItemLoot("Slime Wizard Skin", 0.01),
                    new ItemLoot("Slime Assassin Skin", 0.01),
                    new ItemLoot("Slime Paladin Skin", 0.01),
                    new ItemLoot("Slime Warrior Skin", 0.01),
                    new ItemLoot("Slime Sorcerer Skin", 0.01),
                    new ItemLoot("Slime Necromancer Skin", 0.01),
                    new ItemLoot("Slime Priest Skin", 0.01),

                    //--------------------BAD---------------------

                    new ItemLoot("Stanley the Spring Bunny Skin", 0.009),
                    new ItemLoot("Holy Avenger Skin", 0.009),
                    new ItemLoot("Nexus no Miko Skin", 0.009),
                    new ItemLoot("Drow Trickster Skin", 0.009),
                    new ItemLoot("B.B. Wolf Skin", 0.009),
                    new ItemLoot("Lil Red Skin", 0.009),
                    new ItemLoot("King Knifeula Skin", 0.009),
                    new ItemLoot("Ranger Skin", 0.009),
                    new ItemLoot("Platinum Knight Skin", 0.009),
                    new ItemLoot("Platinum Warrior Skin", 0.009),
                    new ItemLoot("Platinum Rogue Skin", 0.009),
                    new ItemLoot("Witch Skin", 0.009),
                    new ItemLoot("Jester Skin", 0.009),
                    new ItemLoot("Puppet Master Skin", 0.009),
                    new ItemLoot("Ghost Huntress Skin", 0.009),

                    //-----------------okay-------------------

                    new ItemLoot("Skeleton Warrior Skin", 0.007),
                    new ItemLoot("Infected Skin", 0.007),
                    new ItemLoot("Demon Spawn Skin", 0.007),
                    new ItemLoot("Dark Elf Huntress Skin", 0.007),
                    new ItemLoot("Hunchback Skin", 0.007),
                    new ItemLoot("Vampiress Skin", 0.007),
                    new ItemLoot("Frankensteins Monster Skin", 0.007),
                    new ItemLoot("Jack the Ripper Skin", 0.007),
                    new ItemLoot("Death Skin", 0.007),
                    new ItemLoot("Tiny Avatar Skin", 0.007),
                    new ItemLoot("Zombie Nurse Skin", 0.007),
                    new ItemLoot("Mischievous Imp Skin", 0.007),
                    new ItemLoot("Vampire Hunter Skin", 0.007),
                    new ItemLoot("Santa Skin", 0.007),
                    new ItemLoot("Little Helper Skin", 0.007),
                    new ItemLoot("Iceman Skin", 0.007)

                    )
            )
        
            
        
            ;
    }
}