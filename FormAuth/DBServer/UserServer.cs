using FormAuth.Models;
using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FormAuth.DBServer
{
    public class UserServer : DBService
    {
        public UserServer(string connStr)
            :base(connStr)
        {            
        }

        public bool CheckUser(string userName, string pwd,out User model)
        {
            model = new User();
            string sql = string.Empty;
            sql = "select * from [dbo].[user] where Name=@userName and Pwd=@pwd ;";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@userName", userName);
                    comm.Parameters.AddWithValue("@pwd", pwd);
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            model.Id = DBConvert.ToInt(r["Id"]);
                            model.Name = DBConvert.ToString(r["Name"]);
                            model.RoleId = DBConvert.ToInt(r["RoleId"]);
                        }
                    }
                    if (model != default(User))
                        return true;
                    else
                        return false;
                }
            }            
        }
        public Role GetRoleById(int roleId)
        {
            Role role = new Role();
            role.PList = new List<Permission>();
            string sql = string.Empty;
            int rId = 0;
            string roleName = string.Empty;
            sql = @"select r.Id rId,r.name rName,p.Id pId,p.CId pCId,p.CName pCName,p.AId pAId,p.AName pANmae 
                    from  [dbo].[role] r  
                        left join[dbo].[RolePermission] rp on r.Id = rp.RoleId
                        left join[dbo].[Permission] p on rp.PerId = p.Id where r.id=@roleId";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ruleId", roleId);
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            rId = DBConvert.ToInt(r["rId"]);
                            roleName = DBConvert.ToString(r["rName"]);
                            role.PList.Add(new Permission {
                                Id = DBConvert.ToInt(r["pId"]),
                                CId = DBConvert.ToInt(r["pCId"]),
                                CName = DBConvert.ToString(r["pCName"]),
                                AId = DBConvert.ToInt(r["pAId"]),
                                AName = DBConvert.ToString(r["pName"])
                            });
                        }
                        role.Id = rId;
                        role.Name = roleName;
                    }
                }
            }
            return role;
        }
        
    }
}