﻿using System;
using System.Collections.Generic;

namespace MIGHTVR_VS.ORM2;

public partial class TbServico
{
    public int Id { get; set; }

    public string TipoServico { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<TbAtendimento> TbAtendimentos { get; set; } = new List<TbAtendimento>();
}
