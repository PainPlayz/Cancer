﻿#region

using wServer.logic.behaviors;
using wServer.logic.loot;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ RedDemon = () => Behav()
            .Init("Red Demon",
                new State(
                    new TransformOnDeath("Blue Bag loot balloon", probability: 0.1),
                    new DropPortalOnDeath("Dragons Lair Portal", 45),
                    new Shoot(10, projectileIndex: 0, count: 5, shootAngle: 5, predictive: 1, coolDown: 1200),
                    new Shoot(11, projectileIndex: 1, coolDown: 1400),
                    new Prioritize(
                        new StayCloseToSpawn(0.8, 5),
                        new Follow(1, range: 7),
                        new Wander(0.4)
                        ),
                    new Spawn("Imp", 5, coolDown: 10000),
                    new Spawn("Demon", 3, coolDown: 14000),
                    new Spawn("Demon Warrior", 3, coolDown: 18000),
                    new Taunt(0.7, 10000,
                        "I will deliver your soul to Oryx, {PLAYER}!",
                        "Oryx will not end our pain. We can only share it... with you!",
                        "Our anguish is endless, unlike your lives!",
                        "There can be no forgiveness!",
                        "What do you know of suffering? I can teach you much, {PLAYER}",
                        "Would you attempt to destroy us? I know your name, {PLAYER}!",
                        "You cannot hurt us. You cannot help us. You will feed us.",
                        "Your life is an affront to Oryx. You will die."
                        )
                    ),
                new GoldLoot(50, 150),//idk if its yours or somthign else i added... wait
                new Threshold(0.003,
                new ItemLoot("Golden Sword", 0.04),
                //1 sec
                new ItemLoot("Orb of Melted Demise", 0.04),
                new ItemLoot("Potion of Speed", 0.03),
                new ItemLoot("Steel Helm", 0.04)
            )
            )
            .Init("Imp",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Wander(0.8)
                        ),
                    new Shoot(10, predictive: 0.5, coolDown: 200)
                    ),
                new ItemLoot("Missile Wand", 0.02),
                new ItemLoot("Serpentine Staff", 0.02),
                new ItemLoot("Fire Bow", 0.02)
            )
            .Init("Demon",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Follow(1.4, range: 7),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 2, 7, predictive: 0.5)
                    ),
                new ItemLoot("Fire Bow", 0.03)
            )
            .Init("Demon Warrior",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Follow(1, range: 2.8),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 3, 7, predictive: 0.5)
                    ),
                new ItemLoot("Obsidian Dagger", 0.03),
                new ItemLoot("Steel Shield", 0.02)
            )
            ;
    }
}