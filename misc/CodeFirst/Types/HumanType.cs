﻿using HotChocolate.Types;
using HotChocolate.Types.Relay;
using StarWars.Models;
using StarWars.Resolvers;

namespace StarWars.Types
{
    public class HumanType
        : ObjectType<Human>
    {
        protected override void Configure(IObjectTypeDescriptor<Human> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.AppearsIn)
                .Type<ListType<EpisodeType>>();

            descriptor.Field<SharedResolvers>(r => r.GetCharacter(default, default))
                .UsePaging<CharacterType>()
                .Name("friends");

            descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<EnumType<Unit>>())
                .Name("height");
        }
    }
}
