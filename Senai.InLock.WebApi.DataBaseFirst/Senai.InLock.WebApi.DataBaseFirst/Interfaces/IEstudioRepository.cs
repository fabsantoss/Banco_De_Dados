﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.InLock.WebApi.DataBaseFirst.Domains;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudios> Listar();

        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);
    }
}