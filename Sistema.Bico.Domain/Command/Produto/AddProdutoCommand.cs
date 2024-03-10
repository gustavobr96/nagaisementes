﻿using Ardalis.Result;
using MediatR;
using Sistema.Bico.Domain.Enums;
using System;

namespace Sistema.Bico.Domain.Command
{
    public class AddProdutoCommand : IRequest<Result>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] FotoBase64 { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitarioCompra { get; set; }
        public decimal Pureza { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid MenuId { get; set; }
        public string Observacao { get; set; }
        public string Lote { get; set; }
        public int Tetrazolio { get; set; }
    }
}
