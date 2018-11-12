using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ EnragedOryxPuppet = () => Behav()
                    .Init("Enraged Oryx Puppet",
                new State(
                    new TransformOnDeath("White Bag loot balloon", probability: 0.1),
                    new State("idle",
                        new SetAltTexture(1),
                        new Wander(0.1),
                        new DamageTakenTransition(2000, "pause")
                        ),
                    new State("pause",
                         new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "start")
                        ),
                      new State("start",
                           new SetAltTexture(0),
                      new TimedTransition(15000, "midfight"),
                       new State("2",
                        new SetAltTexture(0),
                        new Prioritize(
                             new Wander(0.45),
                             new StayBack(0.3, 5)
                            ),
                        new Shoot(8.4, count: 1, projectileIndex: 4, coolDown: 450),
                        new Shoot(8.4, count: 3, projectileIndex: 1, shootAngle: 40, coolDown: 1750),
                        new TimedTransition(3250, "1")
                        ),
                     new State("1",
                       
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(once: false, speed: 0.4),
                        new Shoot(8.4, count: 1, projectileIndex: 4, coolDown: 450),
                        new Shoot(8.4, count: 3, projectileIndex: 1, shootAngle: 20, coolDown: 1750),
                        new TimedTransition(1500, "2")
                         )
                        ),


                       new State("midfight",
                      new TimedTransition(10000, "countdown"),
                       new State("2",
                        new SetAltTexture(0),
                        new ReturnToSpawn(once: false, speed: 0.4),
                        new Wander(0.5),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                     new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new TimedTransition(3000, "1")
                        ),
                     new State("1",
                        new Prioritize(
                             new Follow(0.45, 8, 1),
                             new Wander(0.3)
                            ),
                        new Taunt(1.00, "This is the end for you!"),
                        new Shoot(8.4, count: 2, shootAngle: 25, projectileIndex: 1, coolDown: 3850),
                        new Shoot(8.4, count: 6, projectileIndex: 0, shootAngle: 10, coolDown: 2750),
                        new TimedTransition(4000, "2")
                         )
                        ),
                    new State("countdown",
                        new Wander(0.1),
                        new Timed(1000,
                            new Taunt(1.00, "Get Ready!")
                            ),
                         new Timed(2000,
                            new Taunt(1.00, "HAHAHA! DIE!!!")
                            ),
                        new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 450),
                        new Shoot(8.4, count: 3, projectileIndex: 0, shootAngle: 20, coolDown: 750),
                        new TimedTransition(2000, "fire")
                        ),
                    new State("fire",
                       new Prioritize(
                             new Follow(0.36, 8, 1),
                             new Wander(0.12)
                            ),
                        new Wander(0.5),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                     new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new TimedTransition(3400, "midfight")
                        )

               ),
                new GoldLoot(440, 670),
                new MostDamagers(90,
                    new ItemLoot("Greater Potion of Wisdom", 1.0),
                    new ItemLoot("Greater Potion of Dexterity", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Speed", 1),
                    new ItemLoot("Greater Potion of Defense", 1)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new ItemLoot("Reinforced Ruby Shield", 0.01),
                    new ItemLoot("Robe of the Defeated King", 0.01),
                    new ItemLoot("Wand of Awakening", 0.01),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.05),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.04),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.04),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new TierLoot(5, ItemType.Ring, 0.02),
                    new EggLoot(EggRarity.Common, 0.05),
                    new EggLoot(EggRarity.Uncommon, 0.025),
                    new EggLoot(EggRarity.Rare, 0.02),
                    new EggLoot(EggRarity.Legendary, 0.005)
                )
            )



        ;
    }
}