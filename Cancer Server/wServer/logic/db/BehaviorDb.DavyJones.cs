#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.realm;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DavyJones = () => Behav()
            .Init("Davy Jones",
                new State(
                    new State("Speak 1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Hello, You're not prepared for a fight like this."),
                        new TimedTransition(2000, "Speak 2")
                        ),
                    new State("Speak 2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Very well."),//tadahhh
                        new TimedTransition(2000, "Attack1")
                        ),

                    new State("Attack1",
                        new ConditionalEffect(ConditionEffectIndex.Armored, true),
                        new Shoot(5, count: 6, fixedAngle: 10, coolDown: 500),
                        new Shoot(25, count: 12, fixedAngle: 10, coolDown: 500),
                        new TimedTransition(6000, "Attack2")
                        ),

                    new State("Attack2",
                        new ConditionalEffect(ConditionEffectIndex.Armored, true),
                        new Shoot(10, 5, 10, 0, coolDown: 1000),
                        new Shoot(10, 1, 10, 1, coolDown: 2500),
                        new TimedTransition(6000, "Speak 4")
                        ),
                    new State("Speak 4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Let's see how well you can hold this attack."),//tadahhh
                        new TimedTransition(1500, "Attack3")
                        ),
                    new State("Attack3",
                        new ConditionalEffect(ConditionEffectIndex.Armored, true),
                        new Shoot(10, 5, 10, 0, coolDown: 1500),
                        new Shoot(10, 1, 10, 1, coolDown: 3500),
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 500),
                        new TimedTransition(6000, "Attack1"),
                        new HpLessTransition(10.0, "Suicide1")
                        ),
                    new State("Suicide1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You've proven your strength Hero."),
                        new TimedTransition(2000, "Suicide")
                        ),
                    new State("Suicide",
                        new Suicide()
                        )
                    ),
                new GoldLoot(170, 190),

            new MostDamagers(15,
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
                new ItemLoot("Greater Potion of Wisdom", 1),
                new ItemLoot("Greater Potion of Attack", 1),
                new ItemLoot("Spirit Dagger", 0.012),
                new ItemLoot("Spectral Cloth Armor", 0.012),
                new ItemLoot("Ghostly Prism", 0.012),
                new ItemLoot("Captain's Ring", 0.01),
                new ItemLoot("Ghost Haunting Trap", 0.0071),
                new ItemLoot("Ghostly Leather Hide", 0.0071),
                new ItemLoot("Wine Cellar Incantation", 0.01)
                )

            )
            
            .Init("Ghost Lanturn Off",
                new State(
                    new TransformOnDeath("Ghost Lanturn On")
                    )
            )
            .Init("Ghost Lanturn On",
                new State(
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "deactivate")
                        ),
                    new State("deactivate",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Ghost Lanturn Off", 10, "shoot"),
                        new TimedTransition(10000, "gone")
                        ),
                    new State("shoot",
                        new Shoot(10, 6, coolDown: 9000001, coolDownOffset: 100),
                        new TimedTransition(1000, "gone")
                        ),
                    new State("gone",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Transform("Ghost Lanturn Off")
                        )
                    )
                    ).Init("GhostShip PurpleDoor Rt",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Purple Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip PurpleDoor Lf",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Purple Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("Lost Soul",
                new State(
                    new State("Default",
                        new Prioritize(
                            new Orbit(0.3, 3, 20, "Ghost of Roger"),
                            new Wander(0.1)
                            ),
                        new PlayerWithinTransition(4, "Default1")
                        ),
                    new State("Default1",
                       new Charge(0.5, 8, coolDown: 2000),
                       new TimedTransition(2200, "Blammo")
                        ),
                     new State("Blammo",
                       new Shoot(10, count: 6, projectileIndex: 0, coolDown: 2000),
                       new Suicide()
                    )
                )
            ).Init("Ghost of Roger",
                new State(
                    new State("spawn",
                        new Spawn("Lost Soul", 3, 1, 5000),
                        new TimedTransition(100, "Attack")
                    ),
                    new State("Attack",
                        new Shoot(13, 1, 0, 0, coolDown: 10),
                        new TimedTransition(20, "Attack2")
                    ),
                    new State("Attack2",
                        new Shoot(13, 1, 0, 0, coolDown: 10),
                        new TimedTransition(20, "Attack3")
                    ),
                    new State("Attack3",
                        new Shoot(13, 1, 0, 0, coolDown: 10),
                        new TimedTransition(20, "Wait")
                    ),
                    new State("Wait",
                        new TimedTransition(1000, "Attack")
                    )
                )
            )
            .Init("GhostShip GreenDoor Rt",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Green Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip GreenDoor Lf",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Green Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip YellowDoor Rt",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Yellow Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip YellowDoor Lf",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Yellow Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip RedDoor Rt",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Red Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("GhostShip RedDoor Lf",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Red Key", 500, "Cycle")

                    ),
                    new State("Cycle",
                        new PlayerWithinTransition(2, "Cycle2")

                    ),
                    new State("Cycle2",
                        new Decay(1000)
                    )
               //248, 305
               )
            )
            .Init("Purple Key",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(1, "Cycle")

                    ),
                    new State("Cycle",
                        new Taunt(true, "Purple Key has been found!"),
                        new Decay(200)



                    )
                )
            )
            .Init("Red Key",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(1, "Cycle")

                    ),
                    new State("Cycle",
                        new Taunt(true, "Red Key has been found!"),
                        new Decay(200)



                    )
                )
            )
            .Init("Green Key",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(1, "Cycle")

                    ),
                    new State("Cycle",
                        new Taunt(true, "Green Key has been found!"),
                        new Decay(200)



                    )
                )
            )
            .Init("Yellow Key",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(1, "Cycle")

                    ),
                    new State("Cycle",
                        new Taunt(true, "Yellow Key has been found!"),
                        new Decay(200)



                    )
                )
            )
  .Init("Lil' Ghost Pirate",
                new State(
                    new ChangeSize(30, 120),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                    new State("Default",
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Wander(0.1)
                            ),
                        new TimedTransition(2850, "Default1")
                        ),
                    new State("Default1",
                       new StayBack(0.2, 3),
                       new TimedTransition(1850, "Default")
                    )
                )
            )
                 .Init("Zombie Pirate Sr",
                new State(
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                    new State("Default",
                        new Prioritize(
                            new Follow(0.3, 8, 1),
                            new Wander(0.1)
                            ),
                        new TimedTransition(2850, "Default1")
                        ),
                    new State("Default1",
                       new ConditionalEffect(ConditionEffectIndex.Armored),
                       new Prioritize(
                            new Follow(0.3, 8, 1),
                            new Wander(0.1)
                            ),
                        new TimedTransition(2850, "Default")
                    )
                )
            )
           .Init("Zombie Pirate Jr",
                new State(
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2500),
                    new State("Default",
                        new Prioritize(
                            new Follow(0.4, 8, 1),
                            new Wander(0.1)
                            ),
                        new TimedTransition(2850, "Default1")
                        ),
                    new State("Default1",
                       new Swirl(0.2, 3),
                       new TimedTransition(1850, "Default")
                    )
                )
            )
        .Init("Captain Summoner",
                new State(
                    new State("Default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        )
                )
            )
           .Init("GhostShip Rat",
                new State(
                    new State("Default",
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1750),
                        new Prioritize(
                            new Follow(0.55, 8, 1),
                            new Wander(0.1)
                            )
                        )
                )
            )
        .Init("Violent Spirit",
                new State(
                    new State("Default",
                        new ChangeSize(35, 120),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1750),
                        new Prioritize(
                            new Follow(0.25, 8, 1),
                            new Wander(0.1)
                            )
                        )
                )
            )
           .Init("School of Ghostfish",
                new State(
                    new State("Default",
                        new Shoot(10, count: 3, shootAngle: 18, projectileIndex: 0, coolDown: 4000),
                        new Wander(0.35)
                        )
                )
            );
    }
}