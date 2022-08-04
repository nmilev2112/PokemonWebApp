using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GraphQL;


namespace PokemonBackend.Core.GraphQLs
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(Query query, Mutation mutation, Subscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = resolver.GetService<Subscription>();
            DependencyResolver = resolver;
        }
    }
}
