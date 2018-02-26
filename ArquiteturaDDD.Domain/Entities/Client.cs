
using System;
using System.Collections.Generic;

namespace ArquiteturaDDD.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public bool SpecialClient(Client client)
        {
            return client.Active && DateTime.Now.Year - client.Created.Year >= 5;
        }

    }
}
