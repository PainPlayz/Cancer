using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ WhiteDragonLord = () => Behav()
            .Init("White Dragon Lord",
            new State(
                new State("default",
                    new Taunt("You've doomed yourself! DIE!"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new PlayerWithinTransition(1500, "basic")
                        ),
                    new State("basic",
                        new Prioritize(
                            new Wander(0.1)
                            ),
                        new Shoot(45, 2, projectileIndex: 2,  predictive: 1, coolDown: 800),
                        new Shoot(10, 4, projectileIndex: 3, predictive: 1, coolDown: 3000),
                        new TimedTransition(10000, "shrink")
                        ),
                    new State("shrink",
                        new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "smallAttack")
                        ),
                    new State("smallAttack",
                        new Prioritize(
                            new Follow(1, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Flash(0x66FF00, 0.6, 9),
                        new Shoot(10, predictive: 1, coolDown: 750),
                        new Shoot(10, 9, projectileIndex: 1, predictive: 1, coolDown: 1000),
                        new TimedTransition(10000, "grow")
                        ),
                    new State("grow",
                        new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1050, "bigAttack")
                        ),
                    new State("bigAttack",
                        new Prioritize(
                            new Follow(0.2),
                            new Wander(0.1)
                            ),
                        new Flash(0x66FF00, 0.6, 9),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDownOffset: 300, coolDown: 3000),
                        new Shoot(10, 4, projectileIndex: 1, predictive: 1, coolDownOffset: 100, coolDown: 4000),
                        new Shoot(10, 2, projectileIndex: 0, predictive: 1, coolDownOffset: 400, coolDown: 2000),
                        new TimedTransition(10000, "normalize")
                        ),
                    new State("normalize",
                        new Wander(0.3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "weakning")
                                                ),
                    new State("weakning",
                        new Taunt("Impudence! I am an immortal Dragon! This is your last warning"),
                        new Follow(0.2),
                            new Wander(0.1),
                        new Shoot(50, 5, projectileIndex: 3, coolDown: 6000, coolDownOffset: 2000),
                        new Shoot(20, 2, projectileIndex: 0, coolDown: 6000, coolDownOffset: 5200),
                        new Shoot(70, 2, projectileIndex: 3, coolDown: 6000, coolDownOffset: 2000),
                        new HpLessTransition(.70, "active")
                        ),
                    new State("active",
                        new Follow(0.2),
                            new Wander(0.1),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 5, projectileIndex: 1, coolDown: 3000, coolDownOffset: 1500),
                        new Shoot(50, 6, projectileIndex: 0, coolDown: 3100, coolDownOffset: 500),
                        new HpLessTransition(.55, "boomerang")
                        ),
                    new State("boomerang",
                        new ReturnToSpawn(true, 1),
                         new Taunt(0.75, "I will kill you with my brute strength!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 1500),
                        new Shoot(50, 1, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.40, "double shot")
                        ),
                    new State("double shot",
                        new Follow(0.2),
                            new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 1500),
                        new Shoot(50, 2, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.3, "triple shot")
                        ),
                    new State("triple shot",
                        new Follow(0.2),
                            new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 1500),
                        new Shoot(50, 3, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.2, "rage")
                        ),
                    new State("rage",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new ReturnToSpawn(true, 1),
                        new Flash(0x66FF00, 0.6, 9),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 3, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 2, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDownOffset: 300, coolDown: 2000),
                        new Shoot(10, 4, projectileIndex: 1, predictive: 1, coolDownOffset: 100, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, predictive: 1, coolDownOffset: 400, coolDown: 2000)
                        )


                        ),
                new GoldLoot(700, 1200),

                new Threshold(0.003,
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 1),
                    new ItemLoot("Greater Potion of Wisdom", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Speed", 1),
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Mana", 1),
                    new ItemLoot("Greater Potion of dexterity", 1)
                ),
                new Threshold(0.2,
                    new ItemLoot("Mythical Shield", 0.006),
                    new ItemLoot("Knights Trusted Armor", 0.011),
                    new ItemLoot("Sturdy Dragon Wings", 0.013),
                    new ItemLoot("Dragons Nail", 0.014)

                    )
            )

         .Init("Cyan Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(100, 140),
                new Threshold(0.03,
                    new ItemLoot("Almandine Armor of Anger", 0.0081),
                    new ItemLoot("Almandine Ring of Wrath", 0.0081),
                    new ItemLoot("Onyx Shield of the Mad God", 0.0081),
                    new ItemLoot("Sword of the Mad God", 0.0081),

                    new ItemLoot("Shendyt of Geb", 0.0081),
                    new ItemLoot("Geb's Ring of Wisdom", 0.0081),
                    new ItemLoot("Book of Geb", 0.0081),
                    new ItemLoot("Scepter of Geb", 0.0081),

                    new ItemLoot("Soulless Robe", 0.0081),
                    new ItemLoot("Ring of the Covetous Heart", 0.0081),
                    new ItemLoot("Soul of the Bearer", 0.0081),
                    new ItemLoot("The Phylactery", 0.0081),

                    new ItemLoot("Fairy Plate", 0.0081),
                    new ItemLoot("Ring of Pure Wishes", 0.0081),
                    new ItemLoot("Seal of the Enchanted Forest", 0.0081),
                    new ItemLoot("Pixie-Enchanted Sword", 0.0081)


                    )
            )

        .Init("Purple Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(100, 140),
                new Threshold(0.03,
                    new ItemLoot("Alice Blue Clothing Dye", 0.3),
                    new ItemLoot("Alice Blue Accessory Dye", 0.3),
                    new ItemLoot("Antique White Clothing Dye", 0.3),
                    new ItemLoot("Antique White Accessory Dye", 0.3),
                    new ItemLoot("Aqua Clothing Dye", 0.3),
                    new ItemLoot("Aqua Accessory Dye", 0.3),
                    new ItemLoot("Aquamarine Clothing Dye", 0.3),
                    new ItemLoot("Pirate Rum", 0.01),
                    new ItemLoot("Magic Mushroom", 0.01),
                    new ItemLoot("Aquamarine Accessory Dye", 0.3)

                    )
            )

         .Init("White Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(100, 140),
                new Threshold(0.03,
                    new ItemLoot("Greater Potion of Defense", 0.4),
                    new ItemLoot("Greater Potion of Attack", 0.4),
                    new ItemLoot("Greater Potion of Wisdom", 0.4),
                    new ItemLoot("Greater Potion of Vitality", 0.4),
                    new ItemLoot("Greater Potion of Speed", 0.4),
                    new ItemLoot("Greater Potion of Life", 0.4),
                    new ItemLoot("Greater Potion of Mana", 0.4),
                    new ItemLoot("Frozen pack", 0.02),
                    new ItemLoot("Lucky Pack", 0.02),
                    new ItemLoot("Greater Potion of dexterity", 0.3)
                ),
                new Threshold(0.2,
                    new ItemLoot("Candy of Defense", 0.0091),
                    new ItemLoot("Candy of Attack", 0.0091),
                    new ItemLoot("Candy of Wisdom", 0.0091),
                    new ItemLoot("Candy of Vitality", 0.0091),
                    new ItemLoot("Candy of Speed", 0.0091),
                    new ItemLoot("Candy of Life", 0.0091),
                    new ItemLoot("Candy of Mana", 0.0091),
                    new ItemLoot("Candy of dexterity", 0.0091)
                    )
            )

        .Init("Gold Red Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(200, 210),
                new Threshold(0.03,
                    new ItemLoot("1000 Gold", 0.3),
                     new ItemLoot("100 Gold", 0.3),
                      new ItemLoot("500 Gold", 0.3)

                    )
            )

         .Init("Gold Blue Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(200, 210),
                new Threshold(0.03,
                    new ItemLoot("500 Fame", 0.3),
                     new ItemLoot("100 Fame", 0.3),
                      new ItemLoot("1000 Fame", 0.3)

                    )
            )

        .Init("Blue Bag loot balloon",
            new State("1"
            ),
                new GoldLoot(100, 140),
                new Threshold(0.03,
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Potion of Attack", 0.3),
                    new ItemLoot("Potion of Wisdom", 0.3),
                    new ItemLoot("Potion of Vitality", 0.3),
                    new ItemLoot("Potion of Speed", 0.3),
                    new ItemLoot("Potion of Life", 0.3),
                    new ItemLoot("Potion of Mana", 0.3),
                    new ItemLoot("Potion of dexterity", 0.3)
       
                    )
            )

                    .Init("White Dragon Egg",
                new State(
                    new State("taunt1",
                    new Taunt("*Back away!*"),
                    new HpLessTransition(0.2, "Open"),
                    new TimedTransition(6000, "taunt2")
                        ),
                    new State("taunt2",
                    new Taunt("*Don't Crack the egg!*"),
                    new HpLessTransition(0.2, "Open"),
                    new TimedTransition(6000, "taunt1")
                        ),
                    new State("Open",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("*Cracks*"),
                        new Flash(0xffffff, 2, 5),
                    new TimedTransition(2000, "Open1")
                        ),
                    new State("Open1",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Transform("White Dragon Lord")

                        )
                )    
        
            );
    }
}