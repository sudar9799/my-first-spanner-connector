using System;
using System.Collections.Generic;

namespace my_first_spanner_connector.entitymodel
{
    public partial class student_details
    {
        public long? rollnumber { get; set; }
        public string? student_name { get; set; }
        public string? department { get; set; }
        public string? grade { get; set; }
    }
}
