﻿using Sistema.Bico.Domain.Enums;
using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public byte[] FotoBase64 { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Pureza { get; set; }
        public int Tetrazolio { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public void RealizarVenda(decimal quantidadeVendida)
        {
            Quantidade = Quantidade - quantidadeVendida;
        }

        public void Atualizar(string nome, string descricao, string observacao, byte[] fotoBase64, TipoProduto tipoProduto,
         decimal quantidade, decimal pureza, int tetrazolio, Guid fornecedorId)
        {
            Nome = nome;
            Descricao = descricao;
            Observacao = observacao;
            FotoBase64 = fotoBase64;
            TipoProduto = tipoProduto;
            Quantidade = quantidade;
            Pureza = pureza;
            Tetrazolio = tetrazolio;
            FornecedorId = fornecedorId;
            Update = DateTime.Now;
        }
        public void AtivarDesativar()
        {
            Ativo = Ativo ? false : true;
        }
    }
}
