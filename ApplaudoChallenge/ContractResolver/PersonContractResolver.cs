using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApplaudoChallenge.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ApplaudoChallenge.ContractResolver
{
    public class PersonContractResolver : DefaultContractResolver
    {
        public PersonContractResolver():base()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Person) && property.PropertyName == nameof(Person.Disabled).ToLower())
            {
                property.ShouldSerialize = instance =>
                {
                    var person = (Person) instance;
                    return person.Disabled;
                };
            }
            return property;
        }
    }
}
