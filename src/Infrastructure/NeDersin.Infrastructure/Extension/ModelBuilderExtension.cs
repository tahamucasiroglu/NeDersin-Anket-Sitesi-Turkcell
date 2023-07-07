using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Extension
{
    static public class ModelBuilderExtension
    {
        static public ModelBuilder UseTurkishCollection(this ModelBuilder builder) => builder.UseCollation("Turkish_CS_AS");
    }
}
