using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ TroomOryx = () => Behav()
         .Init("Golden Oryx Effigy",
            new State(
                     new State("Attack",
                         new Taunt("Leave now!"),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                         new Shoot(40, 2, projectileIndex: 1, shootAngle: 10, coolDown: 600),
                         new Shoot(14, 2, projectileIndex: 1, shootAngle: 100, coolDown: 600),
                         new TimedTransition(10000, "Attack2")
                         ),
                     new State("Attack2",
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                         new Taunt("Your not welcome here!"),
                         new Shoot(40, 3, projectileIndex: 1, shootAngle: 70, coolDown: 1500),
                         new TimedTransition(10000, "Attack")

                         )
                )
            )

            .Init("Quiet Wizard",
               new State(
                        new State("Attack",
                            new Follow(0.4, 0.3),
                            new Wander(0.1),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("The dragon shall never die!"),
                         new Shoot(40, 4, projectileIndex: 0, shootAngle: 10, coolDown: 1500),
                         new Shoot(40, 1, projectileIndex: 1, shootAngle: 50, coolDown: 500)










                         )
                )
            
            );

    }
}