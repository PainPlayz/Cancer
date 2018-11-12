using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ EnragedPuppetMaster = () => Behav()
          .Init("Enraged Puppet Master",
                new State(
                    new NoPlayerWithinTransition(8, "wait"),
                    new TransformOnDeath("White Bag loot balloon", probability: 0.1),
                    new DropPortalOnDeath("Oryx Hideout", 75),
                    new State("wait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x000000, 1, 3),
                         new TimedTransition(3000, "basic")
                    ),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(10, "basic1")
                        ),
                    new State("basic1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You don't understand what you're getting into."),
                        new TimedTransition(2100, "basic2")
                    ),
                    new State("basic2",
                        new Flash(0x000000, 1, 3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You have placed yourself in your own grave!"),
                        new TimedTransition(2100, "basic")
                    ),
                    new State("basic",
                        new Prioritize(
                           new Shoot(8.8, count: 8, shootAngle: 360 / 8, projectileIndex: 0, coolDown: 500),
                           new Wander(0.1)
                        ),
                        new Taunt("You will live no longer!"),
                        new ReturnToSpawn(true, 0.5),
                        new Flash(0xff0000, 0.2, 3),
                        new Shoot(10, projectileIndex: 4, count: 4, shootAngle: 10, angleOffset: 30, predictive: 0.5, coolDown: 1900, coolDownOffset: 100),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 10, predictive: 0, coolDown: 1700, coolDownOffset: 200),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 20, predictive: 0, coolDown: 1600, coolDownOffset: 400),
                        new Shoot(10, projectileIndex: 4, count: 4, shootAngle: 10, angleOffset: 40, predictive: 0.5, coolDown: 1900, coolDownOffset: 600),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 50, predictive: 0, coolDown: 1700, coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 60, predictive: 0, coolDown: 1600, coolDownOffset: 900),
                        new Shoot(10, projectileIndex: 4, count: 4, shootAngle: 10, angleOffset: 70, predictive: 0.5, coolDown: 1900, coolDownOffset: 1100),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 80, predictive: 0, coolDown: 1700, coolDownOffset: 1200),
                        new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 60, angleOffset: 90, predictive: 0, coolDown: 1600, coolDownOffset: 1400),
                        new Shoot(10, projectileIndex: 0, predictive: 1, count: 6, coolDown: 500),
                        new Shoot(10, projectileIndex: 0, predictive: 0, shootAngle: 60, count: 6, coolDown: 500),
                        new TimedTransition(10000, "shrink")
                        ),
                    new State("shrink",
                        new Shoot(10, projectileIndex: 1, predictive: 1, count: 5, coolDown: 500, shootAngle: 72),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "smallAttack")
                        ),
                    new State("smallAttack",
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, angleOffset: 45),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, angleOffset: 135),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, angleOffset: 225),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, angleOffset: 315),
                        new TimedTransition(10000, "grow")
                        ),
                    new State("grow",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1050, "bigAttack")
                        ),
                    new State("bigAttack",
                        new Shoot(9, 3, projectileIndex: 0, shootAngle: 10, coolDown: 100),
                        new Shoot(9, count: 6, fixedAngle: 0, projectileIndex: 2, coolDown: 600),
                        new TimedTransition(10000, "normalize")
                        ),
                    new State("normalize",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "basic")
                        )
                    ),
                    new GoldLoot(100, 400),
                    new Threshold(0.0025,
                    
                    new TierLoot(13, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(14, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),

                    new ItemLoot("Enraged Puppet Helm", 0.01),
                    new ItemLoot("Necklace of Torment", 0.01),
                    new ItemLoot("Enraged leather Hide", 0.01),

                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Dexterity", 1),
                    new ItemLoot("Greater Potion of Wisdom", 1),
                    new ItemLoot("Greater Potion of Speed", 1),
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Mana", 1)
                    )
            );
    }
}
