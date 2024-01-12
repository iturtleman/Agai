namespace AgaiEngine.Characters;
using Agai;
using System.Collections.Generic;
public interface ICharacterDefinition
{
    string Name { get; }
    string Portrait { get; }
    string Description { get; }
    string CharacterSheet { get; }

    List<BaseElement> WeakElements { get; }
    List<BaseElement> StandardElements { get; }
    List<BaseElement> FavoriteElements { get; }

    uint Bonding { get; }
    uint MaxPets { get; }
    /** Pet ids */
    List<string> SelectedPets { get; }
    /** Pet ids */
    List<Creature> Pets { get; }
}