using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_26_06_2022
{
    [Serializable] [DataContract]
    public class User
    {
        private string name;
        private string description;

        public User() { }
        public User(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Description { get => description; set => description = value; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   name == user.name &&
                   description == user.description;
        }
    }
}
