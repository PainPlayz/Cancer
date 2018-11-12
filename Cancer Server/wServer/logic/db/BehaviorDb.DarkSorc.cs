using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DarkSorc = () => Behav()

                  .Init("Darkened Sorcerer",
                new State(
                    new TransformOnDeath("Blue Bag loot balloon", probability: 0.1),
                    new RealmPortalDrop(),
                    new State(
                        new PlayerWithinTransition(12, "transition1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffff, 0.25, 12),
                        new Wander(0.1),
                        new State("transition1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffff, 0.25, 12),
                            new TimedTransition(1000, "spiral")
                            ),
                        new State("transition2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffff, 0.25, 12),
                            new TimedTransition(1000, "ring")
                            ),
                        new State("transition3",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffff, 0.25, 12),
                            new TimedTransition(1000, "quiet")
                            ),
                        new State("transition4",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffff, 0.25, 12),
                            new TimedTransition(1000, "spawn")
                            )
                        ),
                    new State("spiral",
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 0),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 200),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 400),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 600),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 800),
                        new TimedTransition(10000, "transition2")
                        ),
                    new State("ring",
                        new Shoot(10, 12, projectileIndex: 3, fixedAngle: 0, coolDown: 2000),
                        new Shoot(10, 12, projectileIndex: 3, fixedAngle: 24, coolDown: 4000),
                        new Shoot(10, 12, projectileIndex: 3, fixedAngle: 48, coolDown: 6000),
                        new Shoot(10, 12, projectileIndex: 3, fixedAngle: 72, coolDown: 8000),
                        new Shoot(10, 12, projectileIndex: 3, fixedAngle: 96, coolDown: 10000),
                        new TimedTransition(10000, "transition3")
                        ),
                    new State("quiet",
                        new Shoot(10, 8, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, coolDownOffset: 500, angleOffset: 22.5, coolDown: 1000),
                        new Shoot(8, 3, shootAngle: 20, projectileIndex: 2, coolDown: 2000),
                        new TimedTransition(10000, "transition4")
                        ),
                    new State("spawn",
                        new Shoot(8, 3, shootAngle: 0, projectileIndex: 1, coolDown: 500),
                        new Shoot(8, 3, shootAngle: 10, projectileIndex: 1, coolDown: 1000),
                        new Shoot(8, 3, shootAngle: 20, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8, 3, shootAngle: 30, projectileIndex: 1, coolDown: 3000),
                        new Shoot(8, 3, shootAngle: 40, projectileIndex: 1, coolDown: 4000),
                        new Shoot(8, 3, shootAngle: 50, projectileIndex: 1, coolDown: 5000),
                        new TimedTransition(10000, "transition1")
                        )
                ),
                new GoldLoot(100, 200),
                new Threshold(0.032, /* Maximum 3 wis, minimum 0 wis */
                    new ItemLoot("Greater Potion of Speed", 5),
                    new ItemLoot("Greater Potion of Attack", 5),
                    new ItemLoot("Greater Potion of Vitality", 5),
                    new ItemLoot("Potion of Wisdom", 5)
                ),
                new Threshold(0.01,
                    
                    new ItemLoot("Wine Cellar Incantation", 0.005),
                    new ItemLoot("Sword of Dark Magic", 0.012),
                    new ItemLoot("Armor of Darkened Power", 0.012),
                    new ItemLoot("Staff of the Dark Lightning", 0.013),

                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.1),
                    new TierLoot(7, ItemType.Weapon, 0.2),
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.15),
                    new TierLoot(5, ItemType.Ability, 0.1)
                ),
                new Threshold(0.2
                )
            )
         .Init("Fire Blight",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Wander(0.13),
                    new State("shoot1",
                        new Shoot(20, 1, 0, 0, 0),
                        new Shoot(10, 1, 20, angleOffset: 0 / 1, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(2000, "shoot2")
                        ),
                    new State("shoot2",
                        new Shoot(20, 1, 0, 0, 45),
                        new TimedTransition(2000, "shoot1")
                        )
                    )
                        );


    }
}
