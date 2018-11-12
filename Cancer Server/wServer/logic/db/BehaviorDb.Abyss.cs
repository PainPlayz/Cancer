using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Abyss = () => Behav()
            .Init("Archdemon Malphas",
                new State(
                    new TransformOnDeath("Blue Bag loot balloon", probability: 0.1),
                    new OnDeathBehavior(new ApplySetpiece("AbyssDeath")),
                    new State("None",
                        new PlayerWithinTransition(8, "Talk")),
                    new State("Talk",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Your life is in my hands, walk away now!"),
                        new TimedTransition(2000, "Talk2")),
                    new State("Talk2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("If you decide to stay then farewell."),
                        new TimedTransition(2000, "Talk3")),
                    new State("Talk3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You'll join me and be apart of my hell!"),
                        new TimedTransition(2000, "SummonMinions")),
                    new State("SummonMinions",//summons minions
                        new Taunt("Minions! Destroy thoes mortals!"),
                        new Reproduce("Malphas Flamer Deux", 2.5, 8, coolDown: 750),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Attack2")),
                    new State("Attack2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(50, "Attack3", "Malphas Flamer Deux")),
                    new State("Attack3",
                        new Taunt("Augh! Fine, I'll kill them myself!"),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 500),
                        new Grenade(2.5, 100, 10, coolDown: 1500),
                        new TimedTransition(6000, "Attack4")),
                    new State("Attackmid",
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 500),
                        new Grenade(2.5, 170, 10, coolDown: 1500),
                        new TimedTransition(6000, "Attack4")),
                    new State("Attack4",
                        new Grenade(2.5, 170, 10, coolDown: 1500),
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 1000),
                        new HpLessTransition(.6, "NewTalk"),//mid fight
                        new TimedTransition(6000, "Attackmid")),
                    new State("NewTalk",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("HaHaHaHa!"),
                        new TimedTransition(1500, "NewTalk2")),
                    new State("NewTalk2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Did you really think it would be that easy?"),
                        new TimedTransition(1500, "NewTalk3")),
                    new State("NewTalk3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Give me your soul!"),
                        new TimedTransition(1500, "NewAttack")),
                    new State("NewAttack",
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, coolDown: 500, angleOffset: 45),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, coolDown: 500, angleOffset: 135),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, coolDown: 500, angleOffset: 225),
                        new Shoot(21, count: 2, shootAngle: 25, projectileIndex: 2, coolDown: 500, angleOffset: 315),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 0, coolDown: 1000,
                            coolDownOffset: 400),
                    new TimedTransition(11000, "NewAttack2")),
                    new State("NewAttack2",
                        new Shoot(10, projectileIndex: 3, coolDown: 400),
                        new Shoot(10, projectileIndex: 2, count: 1, shootAngle: 15, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, projectileIndex: 2, count: 2, shootAngle: 10, predictive: 0.5, coolDown: 1000,
                            coolDownOffset: 700),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 8.5, predictive: 0.5, coolDown: 1000,
                            coolDownOffset: 1400),
                        new Shoot(10, projectileIndex: 2, count: 4, shootAngle: 7, predictive: 0.5, coolDown: 1000,
                            coolDownOffset: 2100),
                        new HpLessTransition(.06, "Death"),
                    new TimedTransition(11000, "NewAttack")),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I supppose I'll let you live for now"),
                        new TimedTransition(1700, "Death2")),
                    new State("Death2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("After I die I want you to leave this abyss at once!"),
                        new TimedTransition(1700, "Suicide")),
                    new State("Suicide",
                        new Suicide()
                        )
                        
                    ),
                new GoldLoot(200, 420),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(7,
                    new ItemLoot("Greater Potion of Vitality", 1.0)
                ),
                new MostDamagers(7,
                    new ItemLoot("Greater Potion of Defense", 1.0)
                ),
                new Threshold(0.025,
                    
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Demon Blade", 0.015),
                    new ItemLoot("Quiver of Infinite Degrees", 0.009),
                    new ItemLoot("Burning Leather Armor", 0.009),
                    new ItemLoot("Wand of Flaming Obsidian", 0.009)
                )
            )
        
            .Init("Malphas Missile",
                new State(
                    new State(
                        new Prioritize(
                            new Follow(0.4, range: 4),
                            new Wander(0.5)
                        ),
                        new HpLessTransition(0.5, "die"),
                        new TimedTransition(2000, "die")
                    ),
                    new State("die",
                        new Flash(0xFFFFFF, 0.2, 5),
                        new TimedTransition(1000, "explode")
                        ),
                    new State("explode",
                        new Shoot(10, 8),
                        new Decay(100)
                        )
                    )
            )
            .Init("Imp of the Abyss",
                new State(
                    new Wander(0.875),
                    new Shoot(8, 5, 10, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1),
                new Threshold(0.5,
                    new ItemLoot("Cloak of the Red Agent", 0.01),
                    new ItemLoot("Felwasp Toxin", 0.01)
                    )
            )
          .Init("Malphas Flamer",
                new State(
                    new Wander(0.875),
                    new Shoot(8, 5, 10, coolDown: 1000)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1),
                new Threshold(0.5,
                    new ItemLoot("Cloak of the Red Agent", 0.01),
                    new ItemLoot("Felwasp Toxin", 0.01)
                    )
            )
                  .Init("Malphas Flamer Deux",
                new State(
                    new Wander(0.875),
                    new Shoot(10, 8),
                    new Grenade(2.5, 100, 10),
                    new Shoot(8, 5, 10, coolDown: 1000)
                    )
            )

         .Init("Bomb Father",
                new State(

                    new Shoot(8, 5, 10, coolDown: 1000)
                    )
            )

            .Init("Demon of the Abyss",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)
                    ),
                new ItemLoot("Fire Bow", 0.05),
                new Threshold(0.5,
                    new ItemLoot("Mithril Armor", 0.01)
                    )
            )
            .Init("Demon Warrior of the Abyss",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)
                    ),
                new ItemLoot("Fire Sword", 0.025),
                new ItemLoot("Steel Shield", 0.025)
            )
            .Init("Demon Mage of the Abyss",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)
                    ),
                new ItemLoot("Fire Nova Spell", 0.02),
                new Threshold(0.1,
                    new ItemLoot("Wand of Dark Magic", 0.01),
                    new ItemLoot("Avenger Staff", 0.01),
                    new ItemLoot("Robe of the Invoker", 0.01),
                    new ItemLoot("Essence Tap Skull", 0.01),
                    new ItemLoot("Demonhunter Trap", 0.01)
                    )
            )
            .Init("Brute of the Abyss",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 500)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new Threshold(0.1,
                    new ItemLoot("Obsidian Dagger", 0.02),
                    new ItemLoot("Steel Helm", 0.02)
                    )
            )
            .Init("Brute Warrior of the Abyss",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 500)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Glass Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
            ;
    }
}