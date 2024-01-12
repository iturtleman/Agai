namespace AgaiEngine.Characters;

using Agai;
using System.Collections.Generic;

public class CharacterDefinition : ICharacterDefinition, ICreatable
{
    public string Name { get; set; }
    public string Portrait { get; set; }
    public string Description { get; set; }
    public string CharacterSheet { get; set; }

    public string Id { get; set; }

    public uint Version { get; set; }

    public string Creator { get; set; }

    public string LastEditBy { get; set; }

    public List<BaseElement> WeakElements { get; set; } = new List<BaseElement>();

    public List<BaseElement> StandardElements { get; set; } = new List<BaseElement>();

    public List<BaseElement> FavoriteElements { get; set; } = new List<BaseElement>();

    public uint Bonding { get; set; }
    public uint MaxPets { get; set; }

    public List<string> SelectedPets { get; set; } = new List<string>();

    public List<Creature> Pets { get; set; } = new List<Creature>();

    public PetDefinition InitialPetDef { get; set; }
}

