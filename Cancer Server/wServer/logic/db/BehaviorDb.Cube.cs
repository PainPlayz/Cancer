using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        _ CubeGod = () => Behav()
            .Init("Cube God",
                new State(
                    new TransformOnDeath("Cyan Bag loot balloon", probability: 0.1),
                    new StayCloseToSpawn(0.3, range: 7),
                    new State(
                       new State("spiral1"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xffffff, 0.25, 12),
                            new TimedTransition(2000, "spiral2")
                            ),
                            new State("spiral2"),
                            new Wander(1)
                        ),
                new GoldLoot(70, 150),
                new Threshold(0.07,
                    
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(7, ItemType.Armor, 0.2),
                    new TierLoot(8, ItemType.Weapon, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(8, ItemType.Armor, 0.1),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(9, ItemType.Armor, 0.03),
                    new TierLoot(5, ItemType.Ability, 0.03),
                    new TierLoot(9, ItemType.Weapon, 0.03),
                    new TierLoot(10, ItemType.Armor, 0.02),
                    new TierLoot(10, ItemType.Weapon, 0.02),
                    new TierLoot(11, ItemType.Armor, 0.01),
                    new TierLoot(11, ItemType.Weapon, 0.01),
                    new TierLoot(5, ItemType.Ring, 0.01),
                    new ItemLoot("Dirk of Cronus", 0.01),
                    new ItemLoot("Ultra Dirk of Cronus", 0.007),
                    new ItemLoot("Cheese", 0.1),

                    new ItemLoot("Potion of Dexterity", 5),
                    new ItemLoot("Potion of Attack", 0.5)
                )
            )
            .Init("Cube Overseer",
                new State(
                    new StayCloseToSpawn(0.3, range: 7),
                             new Wander(1),
                             new Shoot(10, count: 4, predictive: 0.9, projectileIndex: 0, coolDown: 1250)
                )
            )
            .Init("Cube Defender",
                new State(
                    new Wander(0.5),
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 1, coolDown: 1000, predictive: 0.9, projectileIndex: 0)
                )
            )
            .Init("Cube Blaster",
                new State(
                    new Wander(0.5),
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 2, predictive: 0.9, projectileIndex: 0, coolDown: 1500),
                             new Shoot(10, count: 1, predictive: 0.9, projectileIndex: 0, coolDown: 1500)
                )
            );
    }
}
