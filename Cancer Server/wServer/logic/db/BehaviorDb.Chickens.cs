using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Chickens = () => Behav()
            .Init("Xp gift spawner",
                new State(
                    new TransformOnDeath("Purple Bag loot balloon", probability: 0.1),
                     new State("invis",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Xp Gift A", 2, 90, 90000001, coolDownOffset: 0),
                        new TimedTransition(1000, "check")
                        ),
                    new State("check",
                        new Taunt("More coming up!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Xp Gift A", 20, "invis")
                    )
            )
            )
             .Init("Xp gift A",
                new State(
                    new TransformOnDeath("Purple Bag loot balloon", probability: 0.1),
                     new State("Wander",
                         new Wander(0.1),
                     new TimedTransition(4000, "talk")
                         ),
                     new State("talk",
                         new Taunt("Bock!")
                    )
            )
            )
        
        
            ;
    }
}