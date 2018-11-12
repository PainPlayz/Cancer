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
        private _ BellasEvent = () => Behav()


        .Init("Bella the plant",
                new State(
                    new DropPortalOnDeath("Belladonna's Garden Portal", 55, PortalDespawnTimeSec: 360),
                    new State("Start",
                        new Taunt("Hello wonderful hero"),
                        new Flash(0xffffff, 6, 12),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Start2")
                        ),
                    new State("Start2",
                        new Taunt("I'd never hurt a human! Just please don't attack me."),
                        new HpLessTransition(0.95, "Floating1")
                        ),
                    new State("Floating1",
                        new Taunt("Wow, humans really are evil."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Floating")
                        ),
                    new State("Floating",
                        new Shoot(10, 5, 10, 0, coolDown: 2500),
                        new Shoot(10, 1, 10, 1, coolDown: 500),
                        new TimedTransition(5000, "CheckOffLanterns")
                        ),


                        new State("CheckOffLanterns",
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 500),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDownOffset: 300, coolDown: 1000),
                        new Shoot(10, 4, projectileIndex: 1, predictive: 1, coolDownOffset: 100, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, predictive: 1, coolDownOffset: 400, coolDown: 3000),
                        new TimedTransition(10000, "Vunerable"),
                        new HpLessTransition(0.05, "Dead")
                        ),
                    new State("Vunerable",
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 1000),
                        new TimedTransition(7000, "deactivate")
                        ),
                    new State("deactivate",
                        new Shoot(10, 5, 10, 0, coolDown: 2500),
                        new Shoot(10, 1, 10, 1, coolDown: 500),
                        new TimedTransition(7000, "Floating")
                        ),
                    new State("Dead",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I never got a chance to say bye to my family!"),
                         new TimedTransition(1500, "Dead2")
                        ),
                    new State("Dead2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Suicide()

                        )

                    ),
                new GoldLoot(70, 150),

            new Threshold(0.0003,
                new TierLoot(3, ItemType.Ring, 0.2),
                new TierLoot(7, ItemType.Armor, 0.2),
                new TierLoot(8, ItemType.Weapon, 0.2),
                new TierLoot(4, ItemType.Ability, 0.1),
                new TierLoot(8, ItemType.Armor, 0.1),
                new TierLoot(4, ItemType.Ring, 0.05),
                new TierLoot(9, ItemType.Armor, 0.03),
                new TierLoot(5, ItemType.Ability, 0.03),
                new TierLoot(9, ItemType.Weapon, 0.03),
                new TierLoot(12, ItemType.Armor, 0.02),
                new TierLoot(11, ItemType.Weapon, 0.02),
                new TierLoot(13, ItemType.Armor, 0.01),
                new TierLoot(12, ItemType.Weapon, 0.01),
                new TierLoot(5, ItemType.Ring, 0.01)
                ),
            new Threshold(0.0003,
                new ItemLoot("Greater Potion of Wisdom", 1),
                new ItemLoot("Staff of Planted Cicuta", 0.016),
                new ItemLoot("Living Wood Robe", 0.016),
                new ItemLoot("Greater Potion of Attack", 1)
            )
                
            );
        
    }
}