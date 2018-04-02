using FormAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FormAuth.Utils
{
    public class ControllerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CnName { get; set; }
    }
    public class SystemMenuInfo
    {               
        public static IList<Permission> GetMenuByAssembly(string assemboyName)
        {
            IList<Permission> pList = new List<Permission>();
            var types = Assembly.Load(assemboyName).GetTypes();
            foreach (var type in types)
            {
                if (type.BaseType.Name == "Controller")
                {
                    var conInfo = new ControllerInfo();
                    var attrsCon = type.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attrsCon.Length > 0)
                    {
                        //控制器信息
                        DescriptionAttribute conAttr = attrsCon[0] as DescriptionAttribute;
                        conInfo.Id = conAttr.Id;
                        conInfo.Name = conAttr.Name;
                        conInfo.CnName = conAttr.CnName;
                        var members = type.GetMethods();
                        foreach (var member in members)
                        {
                            var attrs = member.GetCustomAttributes(typeof(DescriptionAttribute), true);
                            if (attrs.Length > 0)
                            {//Action 信息
                                DescriptionAttribute actAttr = attrs[0] as DescriptionAttribute;
                                pList.Add(new Permission {
                                    CId  = conInfo.Id,
                                    CName = conInfo.Name,
                                    ConCnName = conInfo.CnName,
                                    AId = actAttr.Id,
                                    AName = actAttr.Name,
                                    ActCnName = actAttr.CnName
                                });
                            }
                        }
                    }
                }
            }
            return pList;
        }
    }
}