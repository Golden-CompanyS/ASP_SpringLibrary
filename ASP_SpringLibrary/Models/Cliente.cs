using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASP_SpringLibrary.Models
{
    public class Cliente
    {
        public int idCli { get; set; }
        public string nomUsuCli { get; set; }
        public string senhaCli { get; set; }
        public string nomCli { get; set; }
        public int celCli { get; set; }
        public string emailCli { get; set; }
        public int CEPCli { get; set; }
        public int numEndCli { get; set; }
        public string compEndCli { get; set; }
    }
}