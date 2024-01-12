using System;
using System.Collections.Generic;
using System.Text;

namespace AgaiEngine.Creatures.Pets
{
    public class Pet : Creature, ICreatable
    {
        public string Id { get; set; }

        public uint Version { get; set; }

        public string Creator { get; set; }

        public string LastEditBy { get; set; }

        public string Name { get; set; }
    }
}
