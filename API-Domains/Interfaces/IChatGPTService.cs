using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces;

public interface IChatGPTService
{
    Task<string> ChatGPTConsult(string query);
}
