using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_boletim.Domains
{
    public class Aluno
    {
        public int idAluno { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public int Idade { get; set; }
    }
}
