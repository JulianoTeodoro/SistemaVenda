﻿using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        double LerValorProduto(int id);
    }
}
