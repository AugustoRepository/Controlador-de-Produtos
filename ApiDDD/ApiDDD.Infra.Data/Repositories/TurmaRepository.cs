﻿using ApiDDD.Domain.Contracts.Repositories;
using ApiDDD.Domain.Entities;
using ApiDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDDD.Infra.Data.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        private readonly ITurmaRepository turmaRepository;
        public TurmaRepository(DataContext dataContext) : base(dataContext)
        {
            this.turmaRepository = turmaRepository;
        }
    }
}
