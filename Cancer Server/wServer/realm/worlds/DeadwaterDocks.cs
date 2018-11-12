using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class DarkenCave : World
    {
        public DarkenCave()
        {
            Name = "Darken Cave";
            ClientWorldName = "Darken Cave";
            Background = 0;
            Difficulty = 5;
            AllowTeleport = true;
        }

        public override bool NeedsPortalKey => true;

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.ddocks.jm", MapType.Json);
        }
    }
}
