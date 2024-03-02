using Sistema.Bico.Domain.Generics.Entities;
using System.Collections.Generic;

namespace Sistema.Bico.Domain.Entities
{
	public class Client : Base
    {
        public string Name { get;  set; }
        public string Email { get;  set; }

		public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
	}
}
