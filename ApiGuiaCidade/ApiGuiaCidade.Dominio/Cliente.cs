﻿using System;

namespace ApiGuiaCidade.Dominio
{
    public class Cliente
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Email { get; set; }
            public string senha { get; set; }
    }
}
