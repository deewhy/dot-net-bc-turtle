using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetTurtle.Models
{
    public class Events : BaseDataObject
    {

        public string evid { get; set; }
        public string evday { get; set; }
        public string evdate { get; set; }
        public string evtime { get; set; }
        public string evloc { get; set; }
        public string evbrief { get; set; }
        //public string evbriefdesc { get; set; }
        public string evdetail { get; set; }

    }
}
