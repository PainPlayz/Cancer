using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class BalloonCave : World
    {
        public BalloonCave()
        {
            Name = "Balloon Cave";
            ClientWorldName = "Balloon Cave";
            Background = 0;
            Difficulty = 1;
            AllowTeleport = false;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.HauntedCemeteryGraves.jm", MapType.Json);
        }
    }
}