using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.Utils
{
    public class DescriptionAttribute :Attribute
    {
        public DescriptionAttribute(int id, string name,string cnName,int parentId)
        {
            this.Id = id;
            this.Name = name;
            this.CnName = cnName;
        }
        public string Name  {get; private set; }
        public string CnName { get; private set; }
        public int Id { get; private set; }
        public int ParentId { get; private set; }
    }
}