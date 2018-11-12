#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Jeebs = () => Behav()
              .Init("Jeebs",
                  new State(

                                            new State("PlayerChoice",
                          new Taunt("Hi, I'm Mr.Question"),

                        new TimedTransition(5000, "PlayerChoice2")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("I'll be spawning 1 boss for you!"),
                                                 new TimedTransition(3000, "PlayerChoice2")
                                                ),
                          new State("PlayerChoice2",
                          new Taunt("Pick a boss! Oryx, Sphinx, Thessal, or DragonLord!"),


                        new TimedTransition(500, "NOOOOOOWWWW")

                      ),
                          new State("NOOOOOOWWWW",
                               new ChatTransition("DragonLord Prep", "dragonlord"),
                        new ChatTransition("Thessal Prep", "thessal"),
                        new ChatTransition("Oryx the Mad God 2 Prep", "oryx"),
                        new ChatTransition("Grand Sphinx Prep", "sphinx"),



                              new ChatTransition("DragonLord Prep", "DragonLord"),
                              new ChatTransition("Thessal Prep", "Thessal"),
                        new ChatTransition("Oryx the Mad God 2 Prep", "Oryx"),
                        new ChatTransition("Grand Sphinx Prep", "Sphinx"),



                               new ChatTransition("DragonLord Prep", "DRAGONLORD"),
                        new ChatTransition("Thessal Prep", "THESSAL"),
                        new ChatTransition("Oryx the Mad God 2 Prep", "ORYX"),
                        new ChatTransition("Grand Sphinx Prep", "SPHINX")
                              ),
                                     
                          
                          //Thessal
                                      
                          
                          new State("Thessal Prep",
                              new Taunt("Thessal it is, you have 10 seconds to prepare!"),
                              new TimedTransition(0, "Thessal")
                              ),
                    new State("Thessal",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Thessal the Mermaid Goddess", 1, coolDown: 10000),
                        new TimedTransition(12000, "Thessal Check")
                        ),
                    new State("Thessal Check",
                        new EntityNotExistsTransition("Thessal the Mermaid Goddess", 10000, "suicide")
                        ),




                          //Dragon 



                          new State("DragonLord Prep",
                              new Taunt("DragonLord it is, you have 10 seconds to prepare!"),
                              new TimedTransition(0, "Dragon Lord")
                              ),
                    new State("Dragon Lord",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("White Dragon Lord", 1, coolDown: 10000),
                        new TimedTransition(12000, "Dragon Lord Check")
                        ),
                    new State("Dragon Lord Check",
                        new EntityNotExistsTransition("White Dragon Lord", 10000, "suicide")
                        ),
                        


                    //ORYX




                          new State("Oryx the Mad God 2 Prep",
                              new Taunt("Oryx 2 it is, you have 10 seconds to prepare"),
                              new TimedTransition(0, "Oryx")
                              ),
                      new State("Oryx",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Oryx the Mad God 2", 1, coolDown: 10000),

                        new TimedTransition(12000, "Oryx Check")
                        ),
                      new State("Oryx Check",
                        new EntityNotExistsTransition("Oryx the Mad God 2", 12000, "Oryx Check")
                        ),
                      new State("Oryx Check",
                        new EntityNotExistsTransition("Oryx the Mad God 2", 12000, "suicide")
                         ),



                      //Sphinx




                          new State("Grand Sphinx Prep",
                              new Taunt("Grand Sphinx  it is, you have 10 seconds to prepare"),
                              new TimedTransition(0, "Grand Sphinx")
                              ),
                      new State("Grand Sphinx",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Grand Sphinx", 1, coolDown: 10000),

                        new TimedTransition(12000, "Grand Sphinx Check")
                        ),
                      new State("Grand Sphinx Check",
                        new EntityNotExistsTransition("Grand Sphinx", 2000, "suicide")
                            ),

                        new State("suicide",
                        new Suicide()


                        )
                          )


            );
    }
}
