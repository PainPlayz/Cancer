#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Question = () => Behav()
              .Init("???",
                  new State(
                        new TransformOnDeath("???"),//dont die
                        new State("PlayerChoice",
                       // new Taunt("sAk tQniosue"),//ask question
                        new TimedTransition(500, "WOWWWW")
                              ),
                        new State("WOWWWW",
                        //new Taunt("ska a dogo ineotsuq"),//ask a good question
                        new TimedTransition(500, "PlayerChoice2")
                                                ),
                          new State("PlayerChoice2",
                        //  new Taunt("aks ylewsi"), //ask wisely

                        new TimedTransition(25, "what asked")
                        ),
                        new State("what asked",
                               new ChatTransition("Cube God Prep", "Why"),// asked Why
                               new ChatTransition("Cube God Prep", "Why?"),// asked Why?
                               new ChatTransition("Cube God Prep", "why?"),// asked why?
                               new ChatTransition("Cube God Prep", "why"),// asked why
                               new ChatTransition("Cube God Prep1", "wtf"),
                               new ChatTransition("Cube God Prep1", "Wtf?"),
                               new ChatTransition("Cube God Prep1", "wtf?"),
                               new ChatTransition("Cube God Prep1", "Wtf"),
                               new ChatTransition("Cube God Prep2", "Who are you?"),
                               new ChatTransition("Cube God Prep2", "Who are you"),
                               new ChatTransition("Cube God Prep2", "who are you"),
                               new ChatTransition("Cube God Prep2", "who are you?")
                            //   new ChatTransition("Cube God Prep3", "Nooo! this cannot be!"),
                              // new ChatTransition("Cube God Prep3", "Nooo! this cannot be"),
                               //new ChatTransition("Cube God Prep3", "nooo! this cannot be!"),
                               //new ChatTransition("Cube God Prep3", "nooo! this cannot be")


                      ),
                          new State("Cube God Prep",
                              new Taunt("hTta twno eb ndeerswa"), //???
                        new TimedTransition(3000, "1Check") 
                        ),
                    new State("1Check",
                        new EntityNotExistsTransition("Cube God", 2000, "what asked")
                        ),
                          new State("Cube God Prep1",
                              new Taunt("oyu otd'nhlsu ehva adkse"),// you shouldn't have asked
                              new TimedTransition(2000, "wtf")// V
                              ),
                          new State("wtf",// ^
                        new Shoot(20, 3, 10, 0, 160),//666 dmg
                        new Shoot(20, 4, 10, 0, 180, coolDownOffset: 200),//666 dmg
                        new Shoot(20, 3, 10, 0, 200, coolDownOffset: 400),//666 dmg
                        new Shoot(20, 3, 10, 0, 260, coolDownOffset: 600),//666 dmg
                        new Shoot(20, 5, 10, 0, 280, coolDownOffset: 800),//666 dmg
                        new Shoot(20, 3, 10, 0, 300, coolDownOffset: 1000),//666 dmg
                        new Shoot(20, 3, 10, 0, 0, coolDownOffset: 1200),//666 dmg
                        new Shoot(20, 4, 10, 0, 20, coolDownOffset: 1400),//666 dmg
                        new Shoot(20, 3, 10, 0, 40, coolDownOffset: 1600),//666 dmg
                        new Shoot(20, 3, 10, 0, 60, coolDownOffset: 1200),//666 dmg
                        new Shoot(20, 4, 10, 0, 80, coolDownOffset: 1400),//666 dmg
                        new Shoot(20, 3, 10, 0, 100, coolDownOffset: 1600),//666 dmg
                        new TimedTransition(2000, "2Check")//when dead it spawns again
                        ),
                    new State("2Check",
                        new EntityNotExistsTransition("Cube God", 2000, "what asked")
                        ),
                    new State("suicide",
                        new Suicide()
                        ),










                          new State("Cube God Prep2",
                              new Taunt("&$#%@"), //???
                        new TimedTransition(3000, "121")
                              ),
                             new State("121",
                              new Taunt("I'm a lost soul and I came from Down Under."), //???
                        new TimedTransition(3000, "1112")
                        ),
                    new State("1112",
                        new Taunt("kas orme!"),
                        new TimedTransition(1000, "what asked")
                        ),



                        new State("Cube God Prep3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                              new Taunt("Is that Oryx I hear?"), //???

                        new TimedTransition(2000, "5Check")
                        ),
                    new State("5Check",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("if so, I'm glad to hear that he's mad."),
                        new ChatTransition("what asked11", "Why?"),// asked Why
                        new ChatTransition("what asked11", "why?"),// asked Why
                        new ChatTransition("what asked11", "Why"),// asked Why
                        new ChatTransition("what asked11", "why"),// asked Why

                        new TimedTransition(11000, "what asked")
                        ),
                    new State("what asked11",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new TimedTransition(1000, "lulwut?")
                        ),
                        new State("lulwut?",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Maybe because he rules the world, spawns evil, and has even taken my Soul"),

                        new TimedTransition(3000, "what asked21")
                            ),
                        new State("what asked21",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Here Kid, if you could find oryx and tell him '??? wants his soul back' and i'll give you a reward. You have 30mins to come back or the deals off."),
                        new ChatTransition("Soul", "He should've asked a long time ago."),
                        new ChatTransition("Soul", "He should've asked a long time ago"),
                        new ChatTransition("Soul", "he should've asked a long time ago"),
                        new ChatTransition("Soul", "he should've asked a long time ago."),
                        new ChatTransition("Soul", "He should've asked a long time ago. I've given it back"),
                        new ChatTransition("Soul", "You should've asked a long time ago. I've given it back"),
                        new ChatTransition("Cancel", "No"),

                        new TimedTransition(1200000, "suicide")
                       ),
                        new State("Cancel",//cancel a quest
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        
                        new Taunt("Quest Canceled"),
                        new TimedTransition(2000, "what asked")
                            ),

                        new State("Soul",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("I'm not feeling anything..."),

                        new TimedTransition(1500, "Soul1")
                            ),
                        new State("Soul1",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("*$$&@ $&*$#"),

                        new TimedTransition(1500, "Soul2")
                            ),
                        new State("Soul2",

                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Transform("Known Human")
                            )
                      )
            )
                     .Init("Known Human",
                      new State(
                        new State("1",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new Taunt("Where am I?"),
                          new TimedTransition(1200, "2")
                          ),
                      new State("2",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new Taunt("I'm back!"),
                          new TimedTransition(1300, "3")
                          ),
                      new State("3",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new Taunt("As I promised"),
                          new TimedTransition(1300, "41")
                          ),
                      new State("41",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new Taunt("here is your reward!"),
                          new TimedTransition(1300, "4")
                          ),
                      new State("4",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new Taunt("Thank you hero!"),
                          new Spawn("1Quest Chest", 1, coolDown: 2000)

                          )
                      )
            )
                     .Init("1Quest Chest",
                         new State(
                             new State("4",
                                 new Taunt("*Shimmers*")
                        
                )
                ),
                new GoldLoot(100, 5000),
                new MostDamagers(10,
                    new ItemLoot("Oryx Quest Paper", 1)
                    )

            );

        
    }
}
