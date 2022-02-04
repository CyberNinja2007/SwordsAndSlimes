using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SwordsAndSlimes.WEB.Controllers
{
    [Authorize]
    public class FilterController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost,ActionName("Filter")]
        public IActionResult Filter(string query)
        {
            using (var conn = new SqlConnection(
                       "Data Source=localhost;Initial Catalog=Courseach;Trusted_Connection=True;MultipleActiveResultSets=True"))
            {
                conn.Open();
                var cmd = new SqlCommand(query,conn);
                
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var model = Read(reader).ToList();
                        return PartialView("Filtered",model);
                    }
                }
                catch (Exception e)
                {
                    var model = new List<object[]> { new string[]{e.Message.ToString()} };
                    return PartialView("Filtered",model);
                }
            }
        }
        
        private static IEnumerable<object[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetValue(i));
                }
                yield return values.ToArray();
            }
        }
    }
}