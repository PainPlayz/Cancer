#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ CandyGoddess = () => Behav()
              .Init("Candy Goddess",
                new State(

                    new DropPortalOnDeath("Candyland Portal", 75),
                    new State("Wait",
                       new PlayerWithinTransition(8, "Start"),
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Well, Seems like I've teleported myself outside of my castle."),
                        new TimedTransition(1000, "Start2")
                      ),
                    new State("Start2",
                        new Taunt("If you wish to attack me then you wish to die."),
                        new HpLessTransition(0.96, "Attack")
                      ),
                    new State("Attack",
                    new Taunt("Keep trying, I still have {HP} health left"),
                    new Grenade(6, 150, range: 9, coolDown: 2200),
                    new Shoot(0, 2, shootAngle: 15, projectileIndex: 2, fixedAngle: 45),
                    new Shoot(0, 2, shootAngle: 15, projectileIndex: 2, fixedAngle: 135),
                    new Shoot(0, 2, shootAngle: 15, projectileIndex: 2, fixedAngle: 225),
                    new Shoot(0, 2, shootAngle: 15, projectileIndex: 2, fixedAngle: 315),
                    new Shoot(25, 3, 10, 0, coolDown: 1000),
                    new HpLessTransition(0.06, "Dead"),
                    new TimedTransition(7000, "Attack2")
                        ),
                    new State("Attack2",
                    new Grenade(6, 120, range: 9, coolDown: 1500),
                        new Shoot(count: 5, coolDown: 500, projectileIndex: 1, radius: 7, shootAngle: 10, coolDownOffset: 2000),
                        new Shoot(25, 3, 10, 0, coolDown: 1000),
                    new TimedTransition(7000, "Attack3")
                        ),
                    new State("Attack3",
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 1000),
                        new TimedTransition(7000, "Attack")
                        ),
                     new State("Dead",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Taunt("i've failed to protect my babys!"),
                         new TimedTransition(1500, "Suicide")
                         
                         ),

                     new State("Suicide",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Taunt("Dammit!"),
                         new Shoot(count: 30, coolDown: 1500, projectileIndex: 16, radius: 7, shootAngle: 10, coolDownOffset: 2000),
                         new Suicide()
                         )

                ),
                new Threshold(0.001,
                    new EggLoot(EggRarity.Common, 0.1),
                    new EggLoot(EggRarity.Uncommon, 0.05),
                    new EggLoot(EggRarity.Rare, 0.013),
                    new EggLoot(EggRarity.Legendary, 0.01),
                    new TierLoot(6, ItemType.Weapon, 0.2),
                    new TierLoot(7, ItemType.Weapon, 0.1),
                    new TierLoot(7, ItemType.Armor, 0.2),
                    new TierLoot(8, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.1),
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 1),
                    new ItemLoot("Yellow Gumball", 0.3),
                    new ItemLoot("Green Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Red Gumball", 0.3),
                    new ItemLoot("Purple Gumball", 0.3),
                    new ItemLoot("Rock Candy", 0.2),

                    new ItemLoot("Wine Cellar Incantation", 0.01),
                    new ItemLoot("Blow Pop Kiwi Berry Blast", 0.01),
                    new ItemLoot("Wand of Green Gumballs", 0.01)
                )
               
            );

    }
}
