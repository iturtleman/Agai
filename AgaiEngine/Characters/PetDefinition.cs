using Agai;
using System.Collections.Generic;

namespace AgaiEngine.Characters
{
    public class PetDefinition : ICreatable
    {

        public string Creator { get; set; }
        public uint Version { get; set; }

        public string Name { get; set; }
        public string Id { get; set; }

        public string LastEditBy { get; set; }

        public string Portrait { get; set; }
        public string Description { get; set; }
        public BaseElement[] FavoriteElements { get; set; }

        public HashSet<string> Abilities { get; set; } = new HashSet<string>();

        public HashSet<string> CreatureType { get; set; } = new HashSet<string>();
    }
}