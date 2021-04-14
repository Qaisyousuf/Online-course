using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISlug
    {
        bool SlugExists(string slug);

        bool SlugExists(int? id, string slug);
    }
}
