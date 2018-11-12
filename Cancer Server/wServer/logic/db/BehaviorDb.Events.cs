#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Events = () => Behav()
            #region Skull Shrine

            .Init("Skull Shrine",
                new State(
                    new NoPlayerWithinTransition(15, "wait"),
                     
                    new TransformOnDeath("Cyan Bag loot balloon", probability: 0.1),
                    new State("Wait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("I'd never kill you while doing ./tq"),
                    new TimedTransition(2000, "attack")
                         ),
                        new State("wait",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x000000, 1, 3),
                        new TimedTransition(3000, "attack")
                        ),
                    new State("attack",
                    new Shoot(25, 9, 10, predictive: 1)
                )
                    ),
                new MostDamagers(3,
                    LootTemplates.StatIncreasePotionsLoot()
                ),
                new Threshold(0.05,
                    new TierLoot(8, ItemType.Weapon, 0.2),
                    new TierLoot(9, ItemType.Weapon, 0.03),
                    new TierLoot(10, ItemType.Weapon, 0.02),
                    new TierLoot(11, ItemType.Weapon, 0.01),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.01),
                    new TierLoot(7, ItemType.Armor, 0.2),
                    new TierLoot(8, ItemType.Armor, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.03),
                    new TierLoot(10, ItemType.Armor, 0.02),
                    new TierLoot(11, ItemType.Armor, 0.01),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.03),
                    new ItemLoot("Red-Bladed katana", 0.012),
                    new ItemLoot("Orb of Conflict", 0.011),
                    new ItemLoot("Bronze Plated Sword", 0.010)
                )
            )
            .Init("Red Flaming Skull",
                new State(
                    new Prioritize(
                        new Wander(.6),
                        new Follow(.6, 20, 3)
                        ),
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750)
                    )
            )
            .Init("Blue Flaming Skull",
                new State(
                    new Prioritize(
                        new Orbit(1, 20, target: "Skull Shrine", radiusVariance: 0.5),
                        new Wander(.6)
                        ),
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750)
                    )
            )
            #endregion

            #region Hermit God

            .Init("Hermit God",
                new State(
                    new DropPortalOnDeath("Ocean Trench Portal", 75),
                    new TransformOnDeath("Cyan Bag loot balloon", probability: 0.1),
                    new State("Wait",
                       new PlayerWithinTransition(8, "talk"),
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("talk",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("I can't wait to take everything from you!"),
                        new TimedTransition(1000, "talk1")
                            ),
                        new State("talk1",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("You wont even see it coming"),
                        new TimedTransition(1000, "invis")
                            ),
                    new State("invis",
                        new SetAltTexture(3),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new InvisiToss("Hermit God Tentacle", 5, 180, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 0, 90000001, coolDownOffset: 0),
                        new TimedTransition(1000, "check")
                        ),
                    new State("check",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Hermit God Tentacle", 20, "active")
                         ),
                        new State("wait",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x000000, 1, 3),
                        new TimedTransition(3000, "check")
                        ),
                    new State("active",
                        new SetAltTexture(2),
                        new TimedTransition(500, "active2")
                        ),
                    new State("active2",
                        new SetAltTexture(0),
                        new Taunt("The end is near for you mortals!"),
                        new Shoot(25, 8, projectileIndex: 1, coolDown: 2000),
                        new Shoot(25, 20, projectileIndex: 2, coolDown: 3000, coolDownOffset: 5000),
                        new Shoot(25, 3, 10, 0, coolDown: 200),
                        new Wander(.2),//
                        //new TossObject("Whirlpool", 6, 0, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 45, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 90, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 135, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 180, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 225, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 270, 90000001, 100),
                        //new TossObject("Whirlpool", 6, 315, 90000001, 100),
                        new TimedTransition(10000, "rage")
                        ),
                    new State("rage",
                        new SetAltTexture(4),
                        new Flash(0xfFF0000, .8, 9000001),
                        new Shoot(25, 2, projectileIndex: 3, coolDown: 500),
                        new Shoot(25, 8, projectileIndex: 1, coolDown: 2000),
                        new Shoot(25, 20, projectileIndex: 2, coolDown: 3000, coolDownOffset: 5000),
                        new TimedTransition(17000, "active2")
                                                )
                    ),
                new MostDamagers(3,
                    new OnlyOne(
                        new ItemLoot("Greater Potion of Dexterity", 1),
                        new ItemLoot("Greater Potion of Vitality", 1)
                    )
                ),
                new GoldLoot(100, 200),
                new Threshold(0.005,
                     new ItemLoot("Greater Potion of Dexterity", 1),
                     new ItemLoot("Blue-Water Sword", 0.01),
                     new ItemLoot("Skull of Drowned Heros", 0.01)

                    )
            )
            .Init("Whirlpool",
                new State(
                    new State("active",
                        new Shoot(25, 8, projectileIndex: 0, coolDown: 1000),
                        new Orbit(.5, 4, target: "Hermit God", radiusVariance: 0),
                        new EntityNotExistsTransition("Hermit God", 50, "despawn")
                        ),
                    new State("despawn",
                        new Suicide()
                        )
                    )
            )
            .Init("Hermit God Tentacle",
                new State(
                    new Shoot(25, 8, projectileIndex: 0, coolDown: 15000),
                    new Shoot(4, 8, projectileIndex: 1, coolDown: 500)
                    )
            )
            .Init("Hermit Minion",
                new State(
                    new Prioritize(
                        new Wander(.5),
                        new Follow(0.85, 3, 1, 2000, 0)
                        ),
                    new Shoot(5, 1, 1, 1, coolDown: 2300),
                    new Shoot(5, 3, 1, 0, coolDown: 1000)
                    )
            )
            .Init("Hermit God Drop",
                new State(
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Hermit God", 10, "despawn")
                        ),
                    new State("despawn",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    new OnlyOne(
                        new ItemLoot("Potion of Dexterity", 1),
                        new ItemLoot("Potion of Vitality", 1)
                    )
                ), 
                new GoldLoot(100, 200),
                new Threshold(0.05,
                     new ItemLoot("Potion of Dexterity", 1)
                )
            );
            #endregion
    }
}
