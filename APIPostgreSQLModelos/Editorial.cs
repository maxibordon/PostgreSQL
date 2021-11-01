using System;
using System.Collections.Generic;
using System.Text;

namespace APIPostgreSQLModelos
{
    public class Editorial
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Summary { get; set; }
    }
}
