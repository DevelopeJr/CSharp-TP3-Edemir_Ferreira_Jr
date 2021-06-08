using System;


namespace Domain
{
   public class ProdutoModel
    {
        private Guid _id = Guid.NewGuid();
        public string _NomeProduto;
        public DateTime _Fabricacao;
        public string _Caracteristicas;
        public int _Armazenamento;
        public int _Quantidade;

        public Guid GetId()
        {
            return _id;
        }

        public string GetNomeProduto()
        {
            return _NomeProduto;
        }

        private void SetNomeProduto(string value)
        {
            _NomeProduto = value;
        }


        public DateTime GetFabricacao()
        {
            return _Fabricacao;
        }

        private void SetFabricacao(DateTime value)
        {
            _Fabricacao = value;
        }


        public string GetCaracteristicas()
        {
            return _Caracteristicas;
        }

        private void SetCaracteristicas(string value)
        {
            _Caracteristicas = value;
        }


        public int GetArmazenamento()
        {
            return _Armazenamento;
        }

        private void SetArmazenamento(int value)
        {
            _Armazenamento = value;
        }

        public int GetQuantidade()
        {
            return _Quantidade;
        }

        private void SetQuantidade(int value)
        {
            _Quantidade = value;
        }
    }
}
