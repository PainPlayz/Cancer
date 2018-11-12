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
        private _ Biff = () => Behav()
        .Init("Biff the Buffed Bunny",
            new State(
                new State("Start",
                    new PlayerWithinTransition(5, "0")
                    ),
                new State("0",
                    new Taunt("You have come to steal my eggs? This is unacceptable!"),
                    new TimedTransition(2000, "1")
                    ),
                new State("1",
                    new Wander(0.1),
                    new StayCloseToSpawn(5),
                    new Shoot(10, projectileIndex: 0, count: 15, shootAngle: 24, coolDown: 1500),
                    new HpLessTransition(0.8, "2")
                    ),
                new State("2",
                    new Wander(0.1),
                    new StayCloseToSpawn(5),
                    new Shoot(10, projectileIndex: 0, count: 10, shootAngle: 36, coolDown: 1000),
                    new Shoot(5, projectileIndex: 3, count: 3, shootAngle: 16, coolDown: 500),
                    new HpLessTransition(0.6, "3")
                    ),
                new State("3",
                            new Taunt("Nice try, but this should kill you!"),
                            new Wander(0.1),
                            new StayCloseToSpawn(5),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 8, projectileIndex: 1, coolDown: 4575, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 1, coolDown: 4575, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new HpLessTransition(0.4, "4")
                    ),
                new State("4",
                    new Wander(0.1),
                    new StayCloseToSpawn(5),
                        new Shoot(10, projectileIndex: 0, count: 10, shootAngle: 36, coolDown: 1000),
                    new Shoot(50, projectileIndex: 2, count: 5, coolDown: 4000, coolDownOffset: 0, fixedAngle: 0, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 7, coolDown: 4000, coolDownOffset: 400, fixedAngle: 0, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 800, fixedAngle: 0, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 1200, fixedAngle: 0, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 1600, fixedAngle: 0, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 5, coolDown: 4000, coolDownOffset: 0, fixedAngle: 180, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 7, coolDown: 4000, coolDownOffset: 400, fixedAngle: 180, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 800, fixedAngle: 180, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 1200, fixedAngle: 180, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 1600, fixedAngle: 180, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 5, coolDown: 4000, coolDownOffset: 2000, fixedAngle: 90, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 7, coolDown: 4000, coolDownOffset: 2400, fixedAngle: 90, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 2800, fixedAngle: 90, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 3200, fixedAngle: 90, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 3600, fixedAngle: 90, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 5, coolDown: 4000, coolDownOffset: 2000, fixedAngle: 270, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 7, coolDown: 4000, coolDownOffset: 2400, fixedAngle: 270, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 2800, fixedAngle: 270, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 3200, fixedAngle: 270, shootAngle: 9),
                    new Shoot(50, projectileIndex: 2, count: 9, coolDown: 4000, coolDownOffset: 3600, fixedAngle: 270, shootAngle: 9),
                    new HpLessTransition(0.2, "dying")
                    ),
                new State("dying",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Wander(0.1),
                    new StayCloseToSpawn(5),
                    new Flash(0xFF0000, 0.2, 3),
                    new Taunt("NOOOOOO!!!!!!!!!!!!!!!"),
                    new TimedTransition(4000, "dead")
                    ),
                new State("dead",
                    new Spawn("biff's grave", initialSpawn: 1, maxChildren: 1, coolDown: 450000000),
                    new Suicide()
                    )
                )
            )

               .Init("biff's grave",
                new State(
                    new State("1",
                        new SetAltTexture(1),
                        new HpLessTransition(0.8, "2")
                        ),
                    new State("2",
                        new SetAltTexture(2),
                        new HpLessTransition(0.6, "3")
                        ),
                    new State("3",
                        new SetAltTexture(3),
                        new ChangeSize(13, 270),
                        new HpLessTransition(0.4, "4")
                        ),
                    new State("4",
                        new Spawn("Biff the Resurrected Bunny", initialSpawn: 1, maxChildren: 1, coolDown:450000000),
                        new Suicide()
                        )
                    )
            )
        .Init("Biff the Resurrected Bunny",
            new State(
                new State("1",
                    new SetAltTexture(0),
                    new Taunt("I will have my revenge right here hero..."),
                    new TimedTransition(4000, "2")
                    ),
                new State("2",
                  new Wander(0.1),
                  new StayCloseToSpawn(5),
                  new Shoot(30, projectileIndex: 2, count: 7, coolDown: 1000, shootAngle: 360 / 7),
                  new Shoot(30, projectileIndex: 3, count: 7, coolDown: 1000, shootAngle: 360 / 7),
                  new StayCloseToSpawn(0.1, 6),
                  new Wander(0.5),
                  new HpLessTransition(0.8, "fun")
                    ),
                new State("fun",
                    new Taunt("HAHAHA LETS HAVE SOME FUN HERE!"),
                    new ReturnToSpawn(),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 0, fixedAngle: 0, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 1, fixedAngle: 5 * 1, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 2, fixedAngle: 5 * 2, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 3, fixedAngle: 5 * 3, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 4, fixedAngle: 5 * 4, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 5, fixedAngle: 5 * 5, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 6, fixedAngle: 5 * 6, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 7, fixedAngle: 5 * 7, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 8, fixedAngle: 5 * 8, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 9, fixedAngle: 5 * 9, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 10, fixedAngle: 5 * 10, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 11, fixedAngle: 5 * 11, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 12, fixedAngle: 5 * 12, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 13, fixedAngle: 5 * 13, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 14, fixedAngle: 5 * 14, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 15, fixedAngle: 5 * 15, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 16, fixedAngle: 5 * 16, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 17, fixedAngle: 5 * 17, shootAngle: 60),
                  new Shoot(50, projectileIndex: 1, count: 6, coolDown: 200 * 20, coolDownOffset: 200 * 18, fixedAngle: 5 * 18, shootAngle: 60),
                  new HpLessTransition(0.55, "3")
                    ),
                new State("3",
                    new Taunt("DIE!!!"),
                    new Wander(0.1),
                    new StayCloseToSpawn(5),
                    new Shoot(10, projectileIndex: 0, count: 10, shootAngle: 36, coolDown: 1000),
                    new Shoot(5, projectileIndex: 3, count: 3, shootAngle: 16, coolDown: 500),
                    new Shoot(12, projectileIndex: 2, count: 5, shootAngle: 10, coolDown: 1000),
                    new HpLessTransition(0.4, "dying")
                    ),
                new State("dying",
                    new Taunt("NO!!! THIS ISN'T HOW IT'S SUPPOSED TO GO!!! ARGHH!!!"),
                    new Flash(0xFF0000, 0.2, 3),
                    new SetAltTexture(1),
                    new TimedTransition(2000, "4")
                    ),
                new State("4",
                    new Flash(0xFF0000, 0.2, 3),
                    new SetAltTexture(0),
                    new TimedTransition(2000, "5")
                    ),
                new State("5",
                    new Flash(0xFF0000, 0.2, 3),
                    new SetAltTexture(1),
                    new TimedTransition(2000, "4")
                    )

                ),
                new Threshold(0.001,
                    new ItemLoot("Bow of Vernal Florals", 0.01),
                    new ItemLoot("Quiver of Hanami Petals", 0.01),
                    new ItemLoot("Armor of Springly Youth", 0.01),
                    new ItemLoot("Ring of Blossoms", 0.01),
                    new ItemLoot("Easter Egg Ring", 0.01),
                    new ItemLoot("Spell of Trickery", 0.01),
                    new ItemLoot("Robe of the Easter Bunny", 0.01),
                    new ItemLoot("The Bunny's Jester Staff", 0.01),
                    new ItemLoot("Greater Potion of Life", 0.5),
                    new ItemLoot("Greater Potion of Mana", 0.5),
                    new ItemLoot("Greater Potion of Wisdom", 0.8),
                    new ItemLoot("Greater Potion of Defense", 0.8),
                    new ItemLoot("Greater Potion of Attack", 0.8),
                    new ItemLoot("Greater Potion of Speed", 0.8),
                    new ItemLoot("Greater Potion of Vitality", 0.8),
                    new ItemLoot("Greater Potion of Dexterity", 0.8)
                    )                                    
            )
        
        ;
        }
}